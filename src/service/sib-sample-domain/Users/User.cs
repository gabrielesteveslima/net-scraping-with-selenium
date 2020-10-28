namespace SibSample.Domain.Users
{
    using System;
    using System.Collections.Generic;
    using Core.Domain;
    using Documents;

    public sealed class User : Entity<UserId>, IAggregateRoot
    {
        public User(string name, Email email, ICollection<Document> documents) : this()
        {
            Id = new UserId(Guid.NewGuid());
            Name = name;
            Email = email;
            Documents = documents;
        }

        private User()
        {
            Documents = new HashSet<Document>();
        }

        public string Name { get; private set; }
        public Email Email { get; private set; }
        public ICollection<Document> Documents { get; private set; }
    }
}