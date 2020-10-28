namespace SibSample.Infrastructure.Domain
{
    using Database;
    using SibSample.Domain.Core.Data;
    using System.Threading;
    using System.Threading.Tasks;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _applicationContext;

        public UnitOfWork(
            ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return await _applicationContext.SaveChangesAsync(cancellationToken);
        }
    }
}