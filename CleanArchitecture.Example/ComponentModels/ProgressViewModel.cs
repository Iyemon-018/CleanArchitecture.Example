namespace CleanArchitecture.Example.ComponentModels
{
    using Domain.Services;
    using ViewModels;

    public sealed class ProgressViewModel : ViewModelBase, IProgressMessenger
    {
        private string _message;

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }
    }
}