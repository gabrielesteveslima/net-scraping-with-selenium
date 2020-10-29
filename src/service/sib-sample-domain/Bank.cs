namespace SibSample.Domain.Users
{
    using System;
    using System.Collections.Generic;
    using Core.Domain;
    using Documents;

    public sealed class Bank : Entity<BankId>, IAggregateRoot
    {
        public Bank(int code, string name, Email email, Document document) : this()
        {
            Id = new BankId(Guid.NewGuid());
            Code = code;
            Name = name;
            Email = email;
            Document = document;
        }

        public string Name { get; private set; }
        public int Code { get; private set; }
        public int ISPB { get; private set; }
        public Email Email { get; private set; }
        public Document Document { get; private set; }
    }
}