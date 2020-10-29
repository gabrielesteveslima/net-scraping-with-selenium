namespace SibSample.Domain
{
    using System;
    using System.Collections.Generic;
    using Core.Domain;
    using Documents;

    public sealed class Bank : Entity<BankId>, IAggregateRoot
    {
        public Bank(string code, string name, string ispb, string document) : this()
        {
            Code = code;
            ISPB = ispb;
            Name = name;

            AddDocument(document);
        }

        private Bank()
        {
            Id = new BankId(Guid.NewGuid());
        }

        public string Name { get; private set; }
        public string Code { get; private set; }
        public string ISPB { get; private set; }
        public Document Document { get; private set; }

        public void AddDocument(string value)
        {
            Document = new Document(value);
        }
    }
}