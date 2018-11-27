namespace CleanArchitecture.Example.ViewModels
{
    using Domain.Bus;

    public abstract class AppViewModelBase : ViewModelBase
    {
        protected AppViewModelBase(IDialogBus dialogBus)
        {
            DialogBus = dialogBus;
        }

        public IDialogBus DialogBus { get; }
    }
}