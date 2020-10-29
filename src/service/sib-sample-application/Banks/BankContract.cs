namespace SibSample.Application.Banks
{
    using Configuration;
    using Domain;

    public class BankContract : Contract<Bank>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string ISPB { get; set; }
        public string Document { get; set; }
    }
}