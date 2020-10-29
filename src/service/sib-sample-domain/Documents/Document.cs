namespace SibSample.Domain.Documents
{
    using Core.SeedWorks;
    using Rules;

    public class Document : ValueObject
    {
        public string Value { get; private set; }

        public Document(string value)
        {
            Value = value;
            CheckRule(new DocumentIsValid(value));
        }
    }
}