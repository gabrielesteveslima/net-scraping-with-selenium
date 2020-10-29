namespace SibSample.Application.Banks.GetAllBanks
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain;

    public class GetBankQueryHandler : IQueryHandler<GetBankQuery, List<BankContract>>
    {
        private readonly IBankRepository _bankRepository;

        public GetBankQueryHandler(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public async Task<List<BankContract>> Handle(GetBankQuery request, CancellationToken cancellationToken)
        {
            var users = await _bankRepository.GetAll();
            return users.Select(x =>
                new BankContract {Id = x.Id.Value, Name = x.Name, Code = x.Code, Document = x.Document.Value}).ToList();
        }
    }
}