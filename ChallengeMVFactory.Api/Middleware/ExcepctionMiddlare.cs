using ChallengeMVFactory.Application.Models.Response;
using System.Net;
using System.Text.Json;

namespace ChallengeMVFactory.Api.Middleware
{
    public class ExcepctionMiddlare
    {
        private readonly RequestDelegate _Next;
        private readonly ILogger<ExcepctionMiddlare> _Previous;
        private readonly IHostEnvironment _environment;

        public ExcepctionMiddlare(RequestDelegate next)
        {
            _Next = next;
         
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _Next(httpContext);
            }
            catch (Exception ex)
            {
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = new Response(ex);

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(response, options);

                await httpContext.Response.WriteAsync(json);

            }
        }
    }
}
