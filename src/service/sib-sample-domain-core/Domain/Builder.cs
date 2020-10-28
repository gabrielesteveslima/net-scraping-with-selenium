namespace SibSample.Domain.Core.Domain
{
    using System;

    public class Builder<T> : IBuilder<T>
    {
        public virtual T Build()
        {
            throw new NotImplementedException();
        }
    }
}