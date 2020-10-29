namespace SibSample.Application.Banks.RegisterUser
{
    using FluentValidation;

    public class AddBankCommandValidator : AbstractValidator<AddBankCommand>
    {
        public AddBankCommandValidator()
        {
        }
    }
}