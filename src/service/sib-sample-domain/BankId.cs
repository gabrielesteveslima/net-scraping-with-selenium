namespace SibSample.Domain.Users
{
    using System;
    using Core.Data;

    public class BankId : TypedIdValueBase
    {
        public BankId(Guid value) : base(value)
        {
        }
    }
}