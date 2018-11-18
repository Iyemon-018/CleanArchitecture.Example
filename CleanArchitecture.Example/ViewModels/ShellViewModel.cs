using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using CleanArchitecture.Example.Domain.Services;
using CleanArchitecture.Example.Interactions;
using Prism.Commands;

namespace CleanArchitecture.Example.ViewModels
{
    public sealed class ShellViewModel : AppViewModelBase
    {
        public static readonly string DialogIdentifier = "DialogHostArea";

        public ShellViewModel(IDialogService dialogService) : base(dialogService)
        {
            MenuItems = new ObservableCollection<MenuItem>(new[]
                                                           {
                                                               "GetCurrentDateTime"
                                                             , "DetailDataList"
                                                           }
                                                               .Select(x => new MenuItem {Name = x}));
        }

        public ObservableCollection<MenuItem> MenuItems { get; }
    }
}