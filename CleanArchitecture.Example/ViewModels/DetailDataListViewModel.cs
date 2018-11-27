namespace CleanArchitecture.Example.ViewModels
{
    using Domain.Bus;
    using Domain.Presenter;

    public sealed class DetailDataListViewModel : AppViewModelBase
    {
        public DetailDataListViewModel(IDialogBus dialogBus, IProgressPresenter progressPresenter) : base(dialogBus, progressPresenter)
        {
        }
    }
}