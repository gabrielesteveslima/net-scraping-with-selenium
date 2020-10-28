namespace SibSample.Application.Users
{
    using Configuration;
    using Document = Domain.Users.Documents.Document;

    public class DocumentContract : Contract<Document>
    {
        public string Value { get; set; }
        public string DocumentType { get; set; }
    }
}