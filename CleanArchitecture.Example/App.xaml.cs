namespace CleanArchitecture.Example
{
    using System.Windows;
    using Bus;
    using Domain.Bus;
    using Domain.Presenter;
    using Domain.Services;
    using Domain.UseCase;
    using Presenter;
    using Prism.Ioc;
    using Prism.Unity;
    using Services;
    using ViewModels;
    using Views;

    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : PrismApplication
    {
        private IContentNavigator<ViewType> _contentNavigator;

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            _contentNavigator = new ContentNavigator();
            var dialogService   = new DialogService(ShellViewModel.DialogIdentifier);
            var progressService = new ProgressService(ShellViewModel.ProgressDialogIdentifier);

            containerRegistry.RegisterInstance(typeof(IDialogBus), new DialogBus(dialogService, progressService));
            containerRegistry.RegisterInstance(typeof(IContentNavigator<ViewType>), _contentNavigator);
            containerRegistry.RegisterInstance(typeof(IProgressPresenter), new ProgressPresenter(progressService.GetMessenger()));
            containerRegistry.Register(typeof(IGetCurrentDateTimeUseCase), typeof(GetCurrentDateTimeUseCase));
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