namespace SibSample.Domain.Core.SeedWorks
{
    using System;

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class IgnoreOfPopulateMemberAttribute : Attribute
    {
    }
}