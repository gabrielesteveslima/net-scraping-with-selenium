namespace SibSample.Application.Users.RegisterUser
{
    public class RegisterUserCommand : CommandBase<UserContract>
    {
        public RegisterUserCommand(UserContract userContract)
        {
            UserContract = userContract;
        }

        public UserContract UserContract { get; }
    }
}