namespace CleanArchitecture.Example.Domain.UseCase.Request
{
    using CleanArchitecture.Example.Domain.Presenter;

    public sealed class DetailDataListUseCaseRequest : RequestBase
    {
        public DetailDataListUseCaseRequest(IProgressPresenter progressPresenter) : base(progressPresenter)
        {
        }
    }
}