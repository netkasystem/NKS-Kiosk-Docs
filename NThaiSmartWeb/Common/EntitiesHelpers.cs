using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using NThaiSmartWeb.EFModels;
using System.Data;
using System.Data.Common;
using System.Linq.Expressions;
using System.Reflection;

public static class EntitiesHelpers
{
    public static KioskContext DatabaseContext => NSDXHttpContextHelpers.HttpContextAccessor.HttpContext.RequestServices.GetService<KioskContext>();

    private static IOrderedQueryable<T> OrderingHelper<T>(IQueryable<T> source, string propertyName, bool descending, bool anotherLevel)
    {
        try
        {
            ParameterExpression param = Expression.Parameter(typeof(T), string.Empty); // I don't care about some naming
            MemberExpression property = Expression.PropertyOrField(param, propertyName) ?? null;
            LambdaExpression sort = Expression.Lambda(property, param);
            MethodCallExpression call = Expression.Call(
                typeof(Queryable),
                (!anotherLevel ? "OrderBy" : "ThenBy") + (descending ? "Descending" : string.Empty),
                new[] { typeof(T), property.Type },
                source.Expression,
                Expression.Quote(sort));
            return (IOrderedQueryable<T>)source.Provider.CreateQuery<T>(call);
        }
        catch (Exception ex)
        {
            return source.OrderBy(x => true);
        }
    }

    public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName)
    {
        return OrderingHelper(source, propertyName, false, false);
    }

    public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string propertyName)
    {
        return OrderingHelper(source, propertyName, true, false);
    }

    public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string propertyName)
    {
        return OrderingHelper(source, propertyName, false, true);
    }

    public static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> source, string propertyName)
    {
        return OrderingHelper(source, propertyName, true, true);
    }

    public static IQueryable<T> IQueryableFilter<T>(this IQueryable<T> queryable, string query, List<string> columnFilter = null)
    {
        // If the incoming request is empty, skip the search
        if (string.IsNullOrEmpty(query)) { return queryable; }

        // We get all properties with type of string marked with our attribute
        var properties = typeof(T).GetProperties().Where(p => p.PropertyType == typeof(string)).Select(x => x.Name).ToList();

        // If there are no such properties, skip the search
        if (!properties.Any()) { return queryable; }

        //Filter columns
        if (columnFilter != null && columnFilter.Any()) { properties = properties.Where(p => columnFilter.Contains(p)).ToList(); }

        // Get our generic object
        ParameterExpression entity = Expression.Parameter(typeof(T), "entity");

        // Get the Like Method from EF.Functions
        var efLikeMethod = typeof(DbFunctionsExtensions).GetMethod("Like", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, new[] { typeof(DbFunctions), typeof(string), typeof(string) }, null);

        // We make a pattern for the search
        var pattern = Expression.Constant($"%{query}%", typeof(string));

        // Here we will collect a single search request for all properties
        Expression body = Expression.Constant(false);

        foreach (var propertyName in properties)
        {
            // Get property from our object
            var property = Expression.Property(entity, propertyName);

            // Сall the method with all the required arguments
            Expression expr = Expression.Call(efLikeMethod, Expression.Property(null, typeof(EF), nameof(EF.Functions)), property, pattern);

            // Add to the main request
            body = Expression.OrElse(body, expr);
        }

        // Compose and pass the expression to Where
        var expression = Expression.Lambda<Func<T, bool>>(body, entity);
        return queryable.Where(expression);
    }

    public static IQueryable<T> GetIQueryableBySearch<T>(this IQueryable<T> source, string search, List<string> columnFilter = null)
    {
        return source.IQueryableFilter(search, columnFilter);
    }

    public static IEnumerable<T> GetIEnumerableBySearch<T>(this IEnumerable<T> source, string search, List<string> columnFilter = null)
    {
        return source.AsQueryable().IQueryableFilter(search, columnFilter).AsEnumerable();
    }

    public static IQueryable<T> IQueryableFilterSplitSearch<T>(this IQueryable<T> source, string ls_search, List<string> columnFilter = null)
    {
        if (string.IsNullOrEmpty(ls_search)) return source;
        var sourceQueryable = source;
        ls_search.Split(" ").ToList().ForEach(search => sourceQueryable = sourceQueryable.IQueryableFilter(search, columnFilter));
        return sourceQueryable;
    }

    public static IEnumerable<T> IEnumerableFilterSplitSearch<T>(this IEnumerable<T> source, string ls_search, List<string> columnFilter = null)
    {
        if (string.IsNullOrEmpty(ls_search)) return source;
        var sourceQueryable = source.AsQueryable();
        ls_search.Split(" ").ToList().ForEach(search => sourceQueryable = sourceQueryable.IQueryableFilter(search, columnFilter));
        return sourceQueryable.AsEnumerable();
    }

    public static IEnumerable<T> IEnumerableFilter<T>(this IEnumerable<T> source, string search, List<string> columnFilter = null)
    {
        return source.AsQueryable().IQueryableFilter(search, columnFilter).AsEnumerable();
    }

    public static IOrderedEnumerable<T> OrderBy<T>(this IOrderedEnumerable<T> source, string propertyName)
    {
        var property = Expression.PropertyOrField(Expression.Parameter(typeof(T), "type"), propertyName);
        return source.OrderBy(x => property);
    }

    public static IOrderedEnumerable<T> OrderByDescending<T>(this IOrderedEnumerable<T> source, string propertyName)
    {
        var property = Expression.PropertyOrField(Expression.Parameter(typeof(T), "type"), propertyName);
        return source.OrderByDescending(x => property);
    }

    public static string ToSql<TEntity>(this IQueryable<TEntity> query) where TEntity : class
    {
        using var enumerator = query.Provider.Execute<IEnumerable<TEntity>>(query.Expression).GetEnumerator();
        var relationalCommandCache = enumerator.Private("_relationalCommandCache");
        var selectExpression = relationalCommandCache.Private<SelectExpression>("_selectExpression");
        var factory = relationalCommandCache.Private<IQuerySqlGeneratorFactory>("_querySqlGeneratorFactory");

        var sqlGenerator = factory.Create();
        var command = sqlGenerator.GetCommand(selectExpression);

        string sql = command.CommandText;
        return sql;
    }

    public static bool HaveIntersect<T>(this List<T> list1, List<T> list2)
    {
        return list1.Intersect(list2).Any();
    }

    private static object Private(this object obj, string privateField) => obj?.GetType().GetField(privateField, BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(obj);

    private static T Private<T>(this object obj, string privateField) => (T)obj?.GetType().GetField(privateField, BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(obj);

    public static DbTransaction GetDbTransaction(this IDbContextTransaction source) => (source as IInfrastructure<DbTransaction>)?.Instance;
}