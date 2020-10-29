namespace SibSample.Application.Banks.AddBank
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain;
    using Domain.Core.Data;
    using SeedWorks.Logs;

    public class AddBankCommandHandler : ICommandHandler<AddBankCommand, BankContract>
    {
        private readonly IBankRepository _repository;
        private readonly IUnitOfWork _uow;

        public AddBankCommandHandler(IBankRepository repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }

        public async Task<BankContract> Handle(AddBankCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var contract = request.BankContract;
                var bank = new BankBuilder()
                    .WithCode(contract.Code)
                    .WithIspb(contract.ISPB)
                    .WithName(contract.Name)
                    .WithDocument(contract.Document)
                    .Build();

                await _repository.AddBank(bank);
                await _uow.CommitAsync(cancellationToken);

                contract.Id = bank.Id.Value;
                return contract;
            }
            catch (Exception e)
            {
                Log.Error(new {details = "Error on save bank", exception = new {e.Message, e.InnerException}});
                throw;
            }
        }
    }
}