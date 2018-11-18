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
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance(typeof(IDialogService), new DialogService(ShellViewModel.DialogIdentifier));
        }

        protected override Window CreateShell()
        {
            return new Shell();
        }
    }
}