namespace SibSample.Application.Banks.BulkInsert
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain;
    using MediatR;
    using SeedWorks.Logs;

    public class BulkInsertCommandHandler : ICommandHandler<BulkInsertCommand>
    {
        private readonly IBankRepository _bankRepository;

        public BulkInsertCommandHandler(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public async Task<Unit> Handle(BulkInsertCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var contract = request.Banks;

                await _bankRepository.BulkInsert(contract.Select(x =>
                        new BankBuilder()
                            .WithCode(x.Code)
                            .WithIspb(x.ISPB)
                            .WithName(x.Name)
                            .WithDocument(x.Document)
                            .Build())
                    .ToList());
                
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