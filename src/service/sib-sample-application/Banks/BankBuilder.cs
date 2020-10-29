namespace SibSample.Application.Banks
{
    using Domain;
    using Domain.Core.Domain;
    using Domain.Documents;

    public class UserBuilder : Builder<Bank>
    {
        public string Name { get; private set; }
        public Document Document { get; private set; }
        public string Code { get; private set; }
        public string ISPB { get; private set; }

        public UserBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        public UserBuilder WithDocument(string document)
        {
            Document = new Document(document);
            return this;
        }

        public UserBuilder WithCode(string code)
        {
            Code = code;
            return this;
        }

        public UserBuilder WithIspb(string ispb)
        {
            ISPB = ispb;
            return this;
        }


        public override Bank Build()
        {
            return new Bank(Code, Name, ISPB, Document);
        }
    }
}