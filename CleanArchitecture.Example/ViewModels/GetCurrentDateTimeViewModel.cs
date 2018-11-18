using CleanArchitecture.Example.Domain.Services;

namespace CleanArchitecture.Example.ViewModels
{
    public sealed class GetCurrentDateTimeViewModel : AppViewModelBase
    {
        public GetCurrentDateTimeViewModel(IDialogService dialogService) : base(dialogService)
        {
        }
    }
}