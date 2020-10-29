namespace SibSample.Infrastructure.Domain.Repositories
{
    using System.Collections.Generic;
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

        public async Task<IEnumerable<Bank>> GetAll()
        {
            return await _applicationContext.Banks.ToListAsync();
        }

        public async Task AddRangeAsync(IEnumerable<Bank> banks)
        {
            await _applicationContext.Banks.AddRangeAsync(banks);
        }
    }
}