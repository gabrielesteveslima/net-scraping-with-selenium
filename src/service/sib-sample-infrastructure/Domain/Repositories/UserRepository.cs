namespace SibSample.Infrastructure.Domain.Repositories
{
    using Database;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using SibSample.Domain.Users;

    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _applicationContext;

        public UserRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task NewUser(User user)
        {
            await _applicationContext.Users.AddAsync(user);
        }

        public async Task<User> GetUserById(UserId id)
        {
            return await _applicationContext.Users.FirstOrDefaultAsync(x =>
                x.Id == id);
        }
    }
}