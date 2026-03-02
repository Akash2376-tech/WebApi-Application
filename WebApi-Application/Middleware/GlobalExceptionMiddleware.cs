using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApi_Application.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(
            RequestDelegate next,
            ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                await HandleValidationException(context, ex);
            }
            catch (Exception ex)
            {
                await HandleGenericException(context, ex);
            }
        }

        private async Task HandleValidationException(
            HttpContext context,
            ValidationException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";

            var problemDetails = new ValidationProblemDetails(
                ex.Errors
                  .GroupBy(e => e.PropertyName)
                  .ToDictionary(
                        g => g.Key,
                        g => g.Select(e => e.ErrorMessage).ToArray()))
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Validation Failed",
                Type = "https://httpstatuses.com/400",
                Instance = context.Request.Path
            };

            await context.Response.WriteAsJsonAsync(problemDetails);
        }

        private async Task HandleGenericException(
            HttpContext context,
            Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception");

            context.Response.StatusCode =
                (int)HttpStatusCode.InternalServerError;

            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Internal Server Error",
                Type = "https://httpstatuses.com/500",
                Detail = "An unexpected error occurred.",
                Instance = context.Request.Path
            };

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}
