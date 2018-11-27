namespace CleanArchitecture.Example.ViewModels
{
    using Domain.Bus;
    using Domain.Presenter;

    public abstract class AppViewModelBase : ViewModelBase
    {
        protected AppViewModelBase(IDialogBus dialogBus, IProgressPresenter progressPresenter)
        {
            DialogBus = dialogBus;
            ProgressPresenter = progressPresenter;
        }

        public IDialogBus DialogBus { get; }

        protected IProgressPresenter ProgressPresenter { get; }
    }
}