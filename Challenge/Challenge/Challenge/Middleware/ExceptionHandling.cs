using Newtonsoft.Json;
using System.Net;

namespace Challenge.Middleware
{
    public class ExceptionHandling
    {
        public RequestDelegate requestDelegate;
        private readonly ILogger<ExceptionHandling> logger;

        public ExceptionHandling(RequestDelegate requestDelegate, ILogger<ExceptionHandling> logger)
        {
            this.requestDelegate = requestDelegate;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await requestDelegate(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private Task HandleException(HttpContext context, Exception ex)
        {
            logger.LogError(ex.ToString());
            var errorMessageObject = new { Message = ex.Message, Code = "system_error" };

            var errorMessage = JsonConvert.SerializeObject(errorMessageObject);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(errorMessage);
        }
    }
}