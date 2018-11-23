using System;
using System.Windows;
using CleanArchitecture.Example.Domain.Services;
using CleanArchitecture.Example.Services;
using CleanArchitecture.Example.ViewModels;
using CleanArchitecture.Example.Views;
using Prism.Ioc;
using Prism.Unity;

namespace CleanArchitecture.Example
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : PrismApplication
    {
        private IContentNavigator<ViewType> _contentNavigator;
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            _contentNavigator = new ContentNavigator();
            containerRegistry.RegisterInstance(typeof(IDialogService), new DialogService(ShellViewModel.DialogIdentifier));
            containerRegistry.RegisterInstance(typeof(IContentNavigator<ViewType>), _contentNavigator);
        }

        protected override Window CreateShell()
        {
            return new Shell();
        }

        protected override void InitializeShell(Window shell)
        {
            base.InitializeShell(shell);

            if (!(shell is Shell view)) return;
            _contentNavigator.SetNavigationService(view.ContentFrame.NavigationService); 
        }
    }
}