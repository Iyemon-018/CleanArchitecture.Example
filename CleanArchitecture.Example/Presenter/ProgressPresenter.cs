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

        public void UpdateValue(int value)
        {
            _messenger.UpdateValue(value);
        }

        public bool IsCanceled => _messenger.IsCanceled;

        public void Initialize(int maximum)
        {
            _messenger.Initialize(maximum);
        }
    }
}