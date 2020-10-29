namespace SibSample.Application.Banks.BulkInsert
{
    using System.Collections.Generic;
    using Domain;

    public class BulkInsertCommand : CommandBase
    {
        public ICollection<BankContract> Banks { get; private set; }

        public BulkInsertCommand(ICollection<BankContract> banks)
        {
            Banks = banks;
        }
    }
}