namespace SibSample.Domain.Users
{
    using System;
    using Core.Data;

    public class UserId : TypedIdValueBase
    {
        public UserId(Guid value) : base(value)
        {
        }
    }
}