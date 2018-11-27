using System;
using System.Collections.ObjectModel;
using System.Linq;
using CleanArchitecture.Example.Domain.Services;
using CleanArchitecture.Example.Interactions;
using Prism.Commands;

namespace CleanArchitecture.Example.ViewModels
{
    public sealed class ShellViewModel : AppViewModelBase
    {
        public static readonly string DialogIdentifier = "DialogHostArea";
        private readonly IContentNavigator<ViewType> _contentNavigator;

        public ShellViewModel(IDialogService dialogService, IContentNavigator<ViewType> contentNavigator) :
            base(dialogService)
        {
            _contentNavigator = contentNavigator;
            var menus = Enum.GetValues(typeof(ViewType))
                             .OfType<ViewType>()
                             .Select(x => new MenuItem(x)
                                          {
                                              Name = x.ToString()
                                            , SelectionCommand = new DelegateCommand(() => _contentNavigator.Navigate(x))
                                          });
            MenuItems = new ObservableCollection<MenuItem>(menus);
        }

        public ObservableCollection<MenuItem> MenuItems { get; }
    }
}