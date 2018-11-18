using CleanArchitecture.Example.Domain.Services;

namespace CleanArchitecture.Example.ViewModels
{
    public abstract class AppViewModelBase : ViewModelBase
    {
        private readonly IDialogService _dialogService;

        protected AppViewModelBase(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        protected IDialogService DialogService => _dialogService;
    }
}