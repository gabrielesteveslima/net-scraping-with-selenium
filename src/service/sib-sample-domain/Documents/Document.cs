namespace SibSample.Domain.Users.Documents
{
    using System;
    using Core.Domain;
    using Core.SeedWorks;
    using Rules;

    public class Document : ValueObject
    {
        public string Value { get; private set; }

        public Document(string value)
        {
            Value = value;

            CheckRule(new DocDoesMatchCnpj(value));
        }
    }
}