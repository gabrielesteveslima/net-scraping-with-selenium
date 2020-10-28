namespace SibSample.Domain.Core.Domain
{
    public interface IBuilder<out T>
    {
        T Build();
    }
}