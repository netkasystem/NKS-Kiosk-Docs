using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Reflection;

public class JsonBooleanConverter : JsonConverter
{
    public override bool CanWrite => false;

    public override bool CanConvert(Type objectType) => objectType == typeof(Boolean);

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var value = reader?.Value?.ToString()?.ToLower()?.Trim();
        switch (value)
        {
            case "true":
            case "yes":
            case "y":
            case "1":
                return true;
        }
        return false;
    }
}

public static class ConvertHelpers
{
    public static List<TTo> ConvertList<TFrom, TTo>(this List<TFrom> list1) => JArray.FromObject(list1).ToObject<List<TTo>>();

    public static TTo ConvertObj<TTo>(this object data) => JObject.FromObject(data).ToObject<TTo>();

    public static TTo ConvertType<TTo>(this object data) => (TTo)Convert.ChangeType(data, typeof(TTo));

    public static TTo ConvertObj<TFrom, TTo>(this TFrom data) => JObject.FromObject(data).ToObject<TTo>();

    public static t Merge<t>(this object item1, object item2) => item1.Merge(item2).ConvertObj<t>();

    public static object Merge(this object target, object source)
    {
        var _JTarget = JObject.FromObject(target);
        var _JSource = JObject.FromObject(source);
        _JTarget.Merge(_JSource, new JsonMergeSettings { MergeArrayHandling = MergeArrayHandling.Union });
        return _JTarget.ToObject<object>();
    }

    public static object AdditionalObjectFromString(this object _Obj, string _Source)
    {
        var _JObj = JObject.FromObject(_Obj);
        var _key = _JObj.Properties().Select(_p => _p.Name).ToList();
        _key.ForEach(k => { _JObj[k.ToLower()] = _JObj[k]; _JObj[k.ToUpper()] = _JObj[k]; });

        var _key_source = _Source.Split('{').Skip(1).Where(x => x.Contains("}")).Select(x => x.Substring(0, x.IndexOf('}'))).ToList();
        var ls_Add = _key_source.Except(_key).ToList();
        ls_Add.ForEach(k => { _JObj[k] = _JObj[k]; _JObj[k.ToLower()] = _JObj[k]; _JObj[k.ToUpper()] = _JObj[k]; });

        return _JObj.ToObject<object>();
    }

    public static Hashtable AddHashFromTemplate(string source, Hashtable oHash)
    {
        Hashtable oHashLowerKey = new Hashtable();
        var key = oHash.Keys.Cast<string>().ToList();
        key.ForEach(k => oHashLowerKey[k.ToLower()] = oHash[k]);
        var obj_source = source.Split('{').Skip(1).Where(x => x.Contains("}")).Select(x => x.Substring(0, x.IndexOf('}'))).ToList();
        var ls_Add = obj_source.Except(key).ToList();
        var ls_DupName = obj_source.Intersect(key, StringComparer.OrdinalIgnoreCase).ToList();
        ls_Add.ForEach(s =>
        {
            oHash[s] = "";
            if (ls_DupName.Contains(s)) oHash[s] = oHashLowerKey[s.ToLower()];
        });
        return oHash;
    }

    public static JObject SmartAddObject(this JObject _JObj, params string[] source)
    {
        JObject oHashLowerKey = new JObject();
        var key = _JObj.Properties().Select(p => p.Name).ToList();
        key.ForEach(k => oHashLowerKey[k.ToLower()] = _JObj[k]);
        var obj_source = new List<string>();
        source.ToList().ForEach(s =>
        {
            obj_source.AddRange(s.Split('{').Skip(1).Where(x => x.Contains("}")).Select(x => x.Substring(0, x.IndexOf('}'))).ToList());
        });
        var ls_Add = obj_source.Except(key).ToList();
        var ls_DupName = obj_source.Intersect(key, StringComparer.OrdinalIgnoreCase).ToList();
        ls_Add.ForEach(s =>
        {
            _JObj[s] = "";
            if (ls_DupName.Contains(s)) _JObj[s] = oHashLowerKey[s.ToLower()];
        });
        return _JObj;
    }

    public static Hashtable AddHashFromObject(Hashtable oHash, object s)
    {
        var key = oHash.Keys.Cast<string>().ToList();
        s.GetType().GetProperties().Where(p => p.CanRead && p.GetValue(s, null) != null).ToList().ForEach(p =>
        {
            if (key.Contains(p.Name)) oHash.Remove(p.Name);
            oHash.Add(p.Name, p.GetValue(s, null));
        });
        return oHash;
    }

    public static DataTable ListToDataTable<T>(List<T> items)
    {
        DataTable dataTable = new DataTable(typeof(T).Name);
        //Get all the properties by using reflection
        PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (PropertyInfo prop in Props)
        {
            //Setting column names as Property names
            dataTable.Columns.Add(prop.Name);
        }
        foreach (T item in items)
        {
            var values = new object[Props.Length];
            for (int i = 0; i < Props.Length; i++)
            {
                values[i] = Props[i].GetValue(item, null);
            }
            dataTable.Rows.Add(values);
        }

        return dataTable;
    }

    public static Dictionary<string, string> DynToDict(dynamic dynObj)
    {
        var dictionary = new Dictionary<string, string>();
        foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(dynObj))
        {
            string obj = propertyDescriptor.GetValue(dynObj)?.ToString() ?? "";
            dictionary.Add(propertyDescriptor.Name, obj);
        }
        return dictionary;
    }
}

public class DynamicContractResolver : DefaultContractResolver
{
    private readonly string[] props;

    public DynamicContractResolver(params string[] prop)
    { this.props = prop; }

    protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
    {
        IList<JsonProperty> retval = base.CreateProperties(type, memberSerialization);
        retval = retval.Where(p => !this.props.Contains(p.PropertyName)).ToList();
        return retval;
    }
}