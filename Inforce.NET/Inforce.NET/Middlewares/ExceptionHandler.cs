using Inforce.NET.Common.AuxiliaryModels.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace Inforce.NET.Middlewares
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;

        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var status = ex switch
                {
                    NotFoundException => HttpStatusCode.NotFound,
                    _ => HttpStatusCode.InternalServerError
                };

                await HandleException(context, status, ex.Message);
            }
        }

        private async Task HandleException(HttpContext context, HttpStatusCode status, object errorBody)
        {
            errorBody ??= new { Error = "Unknown error occured" };
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;
            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorBody));
        }
    }
}
