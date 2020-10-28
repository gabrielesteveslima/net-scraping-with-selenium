namespace SibSample.Application.Configuration.Validation
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     Represents any Infrastructure errors
    /// </summary>
    public class InfrastructureException : Exception
    {
        public InfrastructureException(string message, List<object> errors) : base(message)
        {
            Errors = errors;
        }

        public List<object> Errors { get; }
    }
}