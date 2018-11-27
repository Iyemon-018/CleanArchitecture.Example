namespace CleanArchitecture.Example.ComponentModels
{
    using Domain.Services;
    using ViewModels;

    public sealed class InformationViewModel : ViewModelBase
    {
        private string _caption;

        private string _message;

        public InformationViewModel()
        {
        }

        public InformationViewModel(IDialogData dialogData)
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