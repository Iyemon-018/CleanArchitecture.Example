namespace CleanArchitecture.Example.ViewModels
{
    using Domain.Bus;

    public sealed class DetailDataListViewModel : AppViewModelBase
    {
        public DetailDataListViewModel(IDialogBus dialogBus) : base(dialogBus)
        {
        }
    }
}