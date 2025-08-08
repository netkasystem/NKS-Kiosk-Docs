using Microsoft.AspNetCore.Mvc.Filters;

public class ActionFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    { }

    public void OnActionExecuted(ActionExecutedContext context)
    { }
}
