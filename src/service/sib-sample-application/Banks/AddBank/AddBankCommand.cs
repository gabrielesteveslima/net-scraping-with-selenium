namespace SibSample.Application.Banks.RegisterUser
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