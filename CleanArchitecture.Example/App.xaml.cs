using System;
using System.Windows;
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
            
        }

        protected override Window CreateShell()
        {
            return new Shell();
        }
    }
}