namespace SibSample.Application.Users
{
    using System.Collections.Generic;
    using Domain.Users;
    using Domain.Users.Documents;
    using SibSample.Domain.Core.Domain;

    public class UserBuilder : Builder<User>
    {
        public string Name { get; private set; }
        public ICollection<Document> Documents { get; private set; }
        public Email Email { get; private set; }

        public UserBuilder WithName(string name)
        {
            Name = name ?? "Default";
            return this;
        }

        public UserBuilder WithDocuments(ICollection<Document> documents)
        {
            Documents = documents;
            return this;
        }

        public UserBuilder WithEmail(Email email)
        {
            Email = email ?? new Email("default@mail.com");
            return this;
        }

        public override User Build()
        {
            return new User(Name, Email, Documents);
        }
    }
}