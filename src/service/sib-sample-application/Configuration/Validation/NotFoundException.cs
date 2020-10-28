namespace SibSample.Application.Configuration.Validation
{
    using System;

    /// <summary>
    ///     Represents when Mongo Db not found any result
    /// </summary>
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}