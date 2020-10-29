namespace SibSample.Application.Banks
{
    using Domain;
    using Domain.Core.Domain;
    using Domain.Documents;

    public class BankBuilder : Builder<Bank>
    {
        public string Name { get; private set; }
        public Document Document { get; private set; }
        public string Code { get; private set; }
        public string ISPB { get; private set; }

        public BankBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        public BankBuilder WithDocument(string document)
        {
            Document = new Document(document);
            return this;
        }

        public BankBuilder WithCode(string code)
        {
            Code = code;
            return this;
        }

        public BankBuilder WithIspb(string ispb)
        {
            ISPB = ispb;
            return this;
        }


        public override Bank Build()
        {
            return new Bank(Code, Name, ISPB, Document.Value);
        }
    }
}