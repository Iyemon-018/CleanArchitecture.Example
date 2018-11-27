namespace CleanArchitecture.Example.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Domain.Bus;
    using Domain.Presenter;
    using Domain.Services;
    using Interactions;
    using Prism.Commands;

    public sealed class ShellViewModel : AppViewModelBase
    {
        public static readonly string DialogIdentifier = "DialogHostArea";

        public static readonly string ProgressDialogIdentifier = "ProgressDialogHostArea";

        private readonly IContentNavigator<ViewType> _contentNavigator;

        public ShellViewModel(IDialogBus dialogBus, IProgressPresenter progressPresenter, IContentNavigator<ViewType> contentNavigator) :
            base(dialogBus, progressPresenter)
        {
            _contentNavigator = contentNavigator;
            var menus = Enum.GetValues(typeof(ViewType))
                            .OfType<ViewType>()
                            .Select(x => new MenuItem(x)
                                         {
                                             Name = x.ToString()
                                           , SelectionCommand =
                                                 new DelegateCommand(() => _contentNavigator.Navigate(x))
                                         });
            MenuItems = new ObservableCollection<MenuItem>(menus);
        }

        public ObservableCollection<MenuItem> MenuItems { get; }
    }
}