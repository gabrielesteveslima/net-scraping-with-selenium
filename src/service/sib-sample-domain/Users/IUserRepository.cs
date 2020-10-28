namespace SibSample.Domain.Users
{
    using System.Threading.Tasks;

    public interface IUserRepository
    {
        Task NewUser(User user);
        Task<User> GetUserById(UserId id);
    }
}