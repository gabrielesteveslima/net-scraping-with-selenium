namespace SibSample.Domain
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBankRepository
    {
        Task AddBank(Bank bank);
        Task<IEnumerable<Bank>> GetAll();
        Task AddRangeAsync(List<Bank> banks);
    }
}