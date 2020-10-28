namespace SibSample.Domain.Users
{
    using System;
    using Core.SeedWorks;

    public sealed class Email : ValueObject
    {
        public string Value { get; private set; }

        public Email(string value)
        {
            if (!value.Contains("@"))
            {
                throw new Exception("Email is invalid");
            }

            Value = value;
        }
    }
}