namespace SibSample.API.Configuration.ProblemDetails.Helpers
{
    using System;
    using Application.Configuration.Validation;
    using Infrastructure.Processing;
    using Microsoft.AspNetCore.Mvc.Filters;
    using SeedWorks.Logs;

    /// <summary>
    ///     Filters any exception from the application
    /// </summary>
    public class ProblemDetailsFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            switch (exception)
            {
                case InvalidCommandException commandException:
                    Log.Error(commandException.Errors);
                    break;
                default:
                    Log.Error(exception);
                    break;
            }
        }
    }
}