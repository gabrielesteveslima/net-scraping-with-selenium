namespace SibSample.Domain.Users.Documents
{
    using System;
    using Core.Data;

    public class DocumentId : TypedIdValueBase
    {
        public DocumentId(Guid value) : base(value)
        {
        }
    }
}