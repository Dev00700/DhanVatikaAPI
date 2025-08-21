using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using DevApi.Models;
using DevApi.Models.Common;
namespace DevApi.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception occurred.");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new
            {
                Flag = 0,
                Message = "An unexpected error occurred.",
                Details = exception.Message // Remove or mask in production
            };
           CommonResponseDto<object> commonResponseDto= new CommonResponseDto<object>
            {
                Data=response,
                PageRecordCount = 0,
                PageSize = 0,
                Flag = 0,
                Message = "An unexpected error occurred.",
           };  

            return context.Response.WriteAsync(JsonSerializer.Serialize(commonResponseDto));
        }
    }
}