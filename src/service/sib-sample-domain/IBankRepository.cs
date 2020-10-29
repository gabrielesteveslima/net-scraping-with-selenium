namespace SibSample.Domain
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserRepository
    {
        Task NewUser(Bank bank);
        Task<Bank> GetUserById(BankId id);
        Task<IEnumerable<Bank>> GetUsers();
    }
}