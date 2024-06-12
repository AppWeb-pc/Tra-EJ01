using System.Data;
using System.Net;
using Travelers.Shared.Domain.Model.Exceptions;
using Travelers.Subscriptions.Domain.Model.Aggregate;

namespace Travelers.Shared.Infrastructure.Interfaces.Middleware;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }


    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var code = HttpStatusCode.InternalServerError;
        var result = ex.Message;

        if (ex is NoValidPlanArgumentException)
        {
            code = HttpStatusCode.BadRequest;
        }


        if (ex is ConstraintException || ex is DuplicateNameException || ex is PlanNameAlreadyExistsException || ex is DefaultPlanLimitException)
        {
            code = HttpStatusCode.Conflict;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        await context.Response.WriteAsync(result);
    }
}