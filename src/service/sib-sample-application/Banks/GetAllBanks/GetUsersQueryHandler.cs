namespace SibSample.Application.Banks.GetUsers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain;

    public class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, List<BankContract>>
    {
        private readonly IBankRepository _bankRepository;

        public GetUsersQueryHandler(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public async Task<List<BankContract>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _bankRepository.GetAll();
            return users.Select(x => new BankContract {Id = x.Id.Value, Name = x.Name}).ToList();
        }
    }
}