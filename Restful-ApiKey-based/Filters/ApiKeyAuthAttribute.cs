using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Restful_ApiKey_based.Filters
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAuthAttribute : Attribute, IAsyncActionFilter
    {
        private const string ApiKeyHeaderName = "ApiKey";
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //before
            //context.HttpContext.Request.Query["ApiKey"])
            if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeaderName, out var PotentialApiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var configuration = context.HttpContext.RequestServices.GetRequiredService <IConfiguration>();
            var apikey = configuration.GetValue<String>("ApiKey");


            if (!apikey.Equals(PotentialApiKey))
            {
                context.Result = new UnauthorizedResult();
            }

            await next();
            //after
        }
    }
}
