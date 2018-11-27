namespace CleanArchitecture.Example.ComponentModels
{
    using Domain.Services;
    using ViewModels;

    public sealed class ErrorViewModel : ViewModelBase
    {
        private string _caption;

        private string _message;

        public ErrorViewModel()
        {
        }

        public ErrorViewModel(IDialogData dialogData)
        {
            _caption = dialogData.Caption;
            _message = dialogData.Message;
        }

        public string Caption
        {
            get => _caption;
            private set => SetProperty(ref _caption, value);
        }

        public string Message
        {
            get => _message;
            private set => SetProperty(ref _message, value);
        }
    }
}