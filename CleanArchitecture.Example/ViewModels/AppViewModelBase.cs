namespace CleanArchitecture.Example.ViewModels
{
    using Domain.Services;

    public abstract class AppViewModelBase : ViewModelBase
    {
        protected AppViewModelBase(IDialogService dialogService)
        {
            DialogService = dialogService;
        }

        protected IDialogService DialogService { get; }
    }
}