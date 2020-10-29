namespace SibSample.Application.Banks.RegisterUser
{
    using FluentValidation;

    public class AddBankCommandValidator : AbstractValidator<AddBankCommand>
    {
        public AddBankCommandValidator()
        {
            RuleFor(x => x.BankContract.Name).NotEmpty();
            RuleFor(x => x.BankContract.Code).NotEmpty();
            RuleFor(x => x.BankContract.ISPB).NotEmpty();
            RuleFor(x => x.BankContract.Document).NotEmpty();
        }
    }
}