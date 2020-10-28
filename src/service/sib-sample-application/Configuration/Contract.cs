namespace SibSample.Application.Configuration
{
    using Humanizer;
    using System;

    public class Contract<T> where T : class
    {
        public Guid Id { get; set; }
        public string Type => typeof(T).Name.Kebaberize().Pluralize();
    }
}