using Hei.Admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;

namespace Hei.Admin.Api.Filters
{
    /// <summary>
    /// 模型合参数验证
    /// </summary>
    public class ValidateModelFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var response = context.HttpContext.Response;
            var parameters = ((ControllerActionDescriptor)context.ActionDescriptor).MethodInfo.GetParameters();
            foreach (var prop in parameters)
            {
                if (prop.IsDefined(typeof(ValidationAttribute), true))
                {
                    object[] attrs = prop.GetCustomAttributes(typeof(ValidationAttribute), true);
                    foreach (var attr in attrs)
                    {
                        var attribute = attr as ValidationAttribute;
                        try
                        {
                            attribute.Validate(context.ActionArguments[prop.Name], prop.Name);
                        }
                        catch (ValidationException vEx)
                        {
                            context.Result = new JsonResult(new ApiActionResult
                            {
                                Message = vEx.Message,
                                Code = 1,
                                IsSucceed = false,
                                HttpStatusCode = HttpStatusCode.UnprocessableEntity
                            });
                            return;
                        }
                    }
                }
            }
            if (!context.ModelState.IsValid)
            {
                var msg = string.Join(",", context.ModelState.Select(a => string.IsNullOrWhiteSpace(a.Value.Errors.FirstOrDefault()?.ErrorMessage) ? a.Value.Errors.FirstOrDefault()?.Exception.Message : a.Value.Errors.FirstOrDefault()?.ErrorMessage).Where(a => !string.IsNullOrWhiteSpace(a)).ToArray());
                context.Result = new JsonResult(new ApiActionResult
                {
                    Message = msg,
                    Code = 1,
                    IsSucceed = false,
                    HttpStatusCode = HttpStatusCode.UnprocessableEntity
                });
            }
        }
    }
}

