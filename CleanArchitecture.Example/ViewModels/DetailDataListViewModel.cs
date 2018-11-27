namespace CleanArchitecture.Example.ViewModels
{
    using Domain.Services;

    public sealed class DetailDataListViewModel : AppViewModelBase
    {
        public DetailDataListViewModel(IDialogService dialogService) : base(dialogService)
        {
        }
    }
}