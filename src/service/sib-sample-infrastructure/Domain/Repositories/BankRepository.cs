namespace SibSample.Infrastructure.Domain.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Database;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using SibSample.Domain;

    public class BankRepository : IBankRepository
    {
        private readonly ApplicationContext _applicationContext;

        public BankRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task AddBank(Bank bank)
        {
            await _applicationContext.Banks.AddAsync(bank);
        }

        public async Task<Bank> GetUserById(BankId id)
        {
            return await _applicationContext.Banks.FirstOrDefaultAsync(x =>
                x.Id == id);
        }

        public async Task<IEnumerable<Bank>> GetAll()
        {
            return await _applicationContext.Banks.ToListAsync();
        }
    }
}