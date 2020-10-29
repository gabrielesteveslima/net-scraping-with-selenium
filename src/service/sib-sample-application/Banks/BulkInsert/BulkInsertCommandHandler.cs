namespace SibSample.Application.Banks.BulkInsert
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain;
    using Domain.Core.Data;
    using MediatR;
    using SeedWorks.Logs;

    public class BulkInsertCommandHandler : ICommandHandler<BulkInsertCommand>
    {
        private readonly IBankRepository _bankRepository;
        private readonly IUnitOfWork _uow;

        public BulkInsertCommandHandler(IBankRepository bankRepository, IUnitOfWork uow)
        {
            _bankRepository = bankRepository;
            _uow = uow;
        }

        public async Task<Unit> Handle(BulkInsertCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var banks = request.Banks.Select(x => new BankBuilder()
                        .WithName(x.Name)
                        .WithCode(x.Code)
                        .WithIspb(x.ISPB)
                        .WithDocument(x.Document)
                        .Build())
                    .ToList();

                await _bankRepository.AddRangeAsync(banks);
                await _uow.CommitAsync(cancellationToken);

                return default;
            }
            catch (Exception e)
            {
                Log.Error(new
                {
                    details = "Error on executing bulk insert", exception = new {e.Message, e.InnerException}
                });
                throw;
            }
        }
    }
}