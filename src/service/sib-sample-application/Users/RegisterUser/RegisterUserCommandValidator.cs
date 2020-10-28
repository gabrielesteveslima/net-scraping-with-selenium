namespace SibSample.Application.Users.RegisterUser
{
    using Domain.Users.Documents;
    using FluentValidation;

    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
        }
    }
}