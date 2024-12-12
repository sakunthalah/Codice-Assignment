using Model.Response;
using System.Net;
using System.Text.Json;
using System;
using static Core.Exceptions.UserDefinedException;

namespace Students.API.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                HttpResponse response = context.Response;
                response.ContentType = "application/json";

                switch (exception)
                {
                    case UDNotFoundException:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case UDBadRequesException:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                _logger.LogError("School.Api.Middlewares.ErrorHandlingMiddleware | Exception: {exception}", exception.ToString());
                const string defaultErrorMessage = "SERVERSIDE_ERROR_OCCURED";
                BaseResponse<string> exceptionResponse = new BaseResponse<string> { Message = response.StatusCode == (int)HttpStatusCode.InternalServerError ? defaultErrorMessage : exception?.Message };
                JsonSerializerOptions serializeOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                };
                string result = JsonSerializer.Serialize(exceptionResponse, serializeOptions);
                await response.WriteAsync(result);
            }
        }
    }
}
