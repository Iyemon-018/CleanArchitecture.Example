namespace CleanArchitecture.Example.Domain.UseCase.Request
{
    using Presenter;

    public abstract class RequestBase
    {
        public IProgressPresenter ProgressPresenter { get; }

        protected RequestBase(IProgressPresenter progressPresenter)
        {
            ProgressPresenter = progressPresenter;
        }
    }
}