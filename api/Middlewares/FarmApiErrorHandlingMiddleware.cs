using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using Homo.Api;

namespace Homo.FarmApi
{
    public class FarmApiErrorHandlingMiddleware : ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        public FarmApiErrorHandlingMiddleware(RequestDelegate next) : base(next)
        {
            this.next = next;
        }

        protected override ActionResult<dynamic> HandleExceptionAsync(HttpContext context, Exception ex, IOptions<IAppSettings> config, ErrorMessageLocalizer localizer)
        {
            IOptions<AppSettings> _config = _serviceProvider.GetService<IOptions<AppSettings>>();
            return base.HandleExceptionAsync(context, ex, _config, localizer);
        }
    }
}
