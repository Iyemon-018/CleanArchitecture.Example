using CleanArchitecture.Example.Domain.Services;

namespace CleanArchitecture.Example.ViewModels
{
    public sealed class DetailDataListViewModel : AppViewModelBase
    {
        public DetailDataListViewModel(IDialogService dialogService) : base(dialogService)
        {
        }
    }
}