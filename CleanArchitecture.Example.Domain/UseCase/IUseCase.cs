namespace CleanArchitecture.Example.Domain.UseCase
{
    public interface IUseCase<in TRequest, out TResponse>
    {
        TResponse Handle(TRequest request);
    }
}