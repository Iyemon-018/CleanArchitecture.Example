namespace CleanArchitecture.Example.Domain.UseCase
{
    using Request;
    using Response;

    public interface IGetCurrentDateTimeUseCase : IUseCase<GetCurrentDateTimeUseCaseRequest, GetCurrentDateTimeUseCaseResponse>
    {
        
    }
}