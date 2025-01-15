using System;
using EmployeeSerializer.Services;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeSerializer.Filters;

public class ClearEmployeeData : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        EmployeeService.ClearEmployeeList();
    }
}