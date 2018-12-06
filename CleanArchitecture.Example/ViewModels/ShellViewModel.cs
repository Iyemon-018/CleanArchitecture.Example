namespace CleanArchitecture.Example.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
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
                            .Select(x => new MenuItem(x));
            MenuItems = new ObservableCollection<MenuItem>(menus);
            SelectedMenuCommand = new DelegateCommand(() => _contentNavigator.Navigate(SelectedMenuItem.ViewType));

            LoadedCommand = new DelegateCommand(() => _contentNavigator.Navigate(ViewType.GetCurrentDateTime));
        }

        public ICommand LoadedCommand { get; }

        public ICommand SelectedMenuCommand { get; }

        public ObservableCollection<MenuItem> MenuItems { get; }

        private MenuItem _selectedMenuItem;

        public MenuItem SelectedMenuItem
        {
            get => _selectedMenuItem;
            set => SetProperty(ref _selectedMenuItem, value);
        }
    }
}