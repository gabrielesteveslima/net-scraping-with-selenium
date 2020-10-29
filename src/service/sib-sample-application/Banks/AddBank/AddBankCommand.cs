namespace SibSample.Application.Banks.AddBank
{
    public class AddBankCommand : CommandBase<BankContract>
    {
        public AddBankCommand(BankContract bankContract)
        {
            BankContract = bankContract;
        }

        public BankContract BankContract { get; }
    }
}