using CFP.Application.Exceptions;
using Newtonsoft.Json;

namespace CFP.Api.Middlewares
{
    public class ExceptionHandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch(Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (exception is not ApiException apiException)
            {
                throw exception;
            }

            context.Response.StatusCode = apiException.StatusCode;
            context.Response.ContentType = "application/json";

            var result = JsonConvert.SerializeObject(new
            {
                StatusCode = apiException.StatusCode,
                Type = apiException.Type,
                ErrorMessage = apiException.Message,
            });

            await context.Response.WriteAsync(result);
        }
    }
}
