namespace SibSample.API.Configuration.ProblemDetails
{
    using Helpers;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     Represent infrastructure exceptions
    /// </summary>
    /// <example>
    ///     <see cref="FlurlHttpException" /> <see cref="Win32Exception" /> <see cref="SqlException" />
    /// </example>
    public class InfrastructureExceptionProblemDetails : ProblemDetails
    {
        public InfrastructureExceptionProblemDetails(Exception exception)
        {
            Status = StatusCodes.Status500InternalServerError;
            Type = nameof(InfrastructureExceptionProblemDetails);
            Errors = ProblemDetailsWrapErrors.GetErrors(exception);
        }

        public IEnumerable<ProblemDetailsWrapErrors> Errors { get; }

        public new string Extensions { get; set; }
        public new string Title { get; set; }
        public new string Detail { get; set; }
    }
}