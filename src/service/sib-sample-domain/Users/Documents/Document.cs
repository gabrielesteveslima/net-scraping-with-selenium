namespace SibSample.Domain.Users.Documents
{
    using System;
    using Core.Domain;
    using Rules;

    public class Document : Entity<DocumentId>
    {
        public string Value { get; private set; }
        public DocumentType DocumentType { get; private set; }
        public UserId UserId { get; private set; }
        public User User { get; private set; }

        public Document(string value, DocumentType documentType)
        {
            Id = new DocumentId(Guid.NewGuid());
            Value = value;
            DocumentType = documentType;

            switch (documentType)
            {
                case DocumentType.CNPJ:
                    CheckRule(new DocDoesMatchCnpj(value));
                    break;
                case DocumentType.CPF:
                    CheckRule(new DocDoesMatchCpf(value));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}