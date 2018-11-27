namespace CleanArchitecture.Example.Domain.UseCase.Request
{
    using Presenter;

    public sealed class GetCurrentDateTimeUseCaseRequest : RequestBase
    {
        public GetCurrentDateTimeUseCaseRequest(IProgressPresenter progressPresenter) : base(progressPresenter)
        {
        }
    }
}