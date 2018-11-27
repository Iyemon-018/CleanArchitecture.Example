namespace CleanArchitecture.Example.ViewModels
{
    using Domain.Services;

    public abstract class AppViewModelBase : ViewModelBase
    {
        protected AppViewModelBase(IDialogService dialogService, IProgressService progressService)
        {
            DialogService   = dialogService;
            ProgressService = progressService;
        }

        protected IDialogService DialogService { get; }
        public IProgressService ProgressService { get; }
    }
}