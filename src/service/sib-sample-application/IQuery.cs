namespace SibSample.Application
{
    using MediatR;

    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}