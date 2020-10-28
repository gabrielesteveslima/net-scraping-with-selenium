namespace SibSample.Domain.Core.Domain
{
    using Data;
    using SeedWorks;

    /// <summary>
    ///     Base class for entities.
    /// </summary>
    public abstract class Entity<T> where T : TypedIdValueBase
    {
        [IgnoreOfPopulateMember] public T Id { get; protected set; }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }

        protected bool IsActive { get; set; }

        public static bool operator ==(Entity<T> a, Entity<T> b)
        {
            if (a is null && b is null)
            {
                return true;
            }

            if (a is null || b is null)
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(Entity<T> a, Entity<T> b)
        {
            return !(a == b);
        }

        protected static bool CheckRule(IBusinessRule rule)
        {
            if (rule.IsBroken())
            {
                throw new BusinessRuleValidationException(rule);
            }

            return false;
        }
    }
}