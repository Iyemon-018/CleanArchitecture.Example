namespace CleanArchitecture.Example.Presenter
{
    using Domain.Presenter;
    using Domain.Services;

    public sealed class ProgressPresenter : IProgressPresenter
    {
        private readonly IProgressMessenger _messenger;

        public ProgressPresenter(IProgressMessenger messenger)
        {
            _messenger = messenger;
        }

        public void SetMessage(string message)
        {
            _messenger.Message = message;
        }
    }
}