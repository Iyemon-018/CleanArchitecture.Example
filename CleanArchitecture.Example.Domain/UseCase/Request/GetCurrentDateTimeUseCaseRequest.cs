namespace CleanArchitecture.Example.Domain.UseCase.Request
{
    using Presenter;

    public sealed class GetCurrentDateTimeUseCaseRequest : RequestBase
    {
        private readonly bool _isSuccess;

        public GetCurrentDateTimeUseCaseRequest(IProgressPresenter progressPresenter, bool isSuccess) : base(progressPresenter)
        {
            _isSuccess = isSuccess;
        }

        public bool IsSuccess => _isSuccess;
    }
}