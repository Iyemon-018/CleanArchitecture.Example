namespace CleanArchitecture.Example.Services
{
    using System;
    using System.Threading.Tasks;
    using ComponentModels;
    using Components;
    using Domain.Services;
    using MaterialDesignThemes.Wpf;

    public sealed class ProgressService : IProgressService
    {
        private readonly object _identifier;

        private Action<IProgressMessenger> _work;

        private readonly ProgressViewModel _viewModel;

        public ProgressService(object identifier)
        {
            _identifier = identifier;
            _viewModel = new ProgressViewModel();
        }

        public IProgressMessenger GetMessenger() => _viewModel;

        public Task Execute(Action<IProgressMessenger> work)
        {
            var view = new ProgressDialog {DataContext = _viewModel};
            _work = work;
            return DialogHost.Show(view, _identifier, OpenEventHandler);
        }

        public Task ExecuteCancellable(Action<IProgressMessenger> work)
        {
            var view = new CancellableProgressDialog {DataContext = _viewModel};
            _work = work;
            return DialogHost.Show(view, _identifier, OpenEventHandler);
        }

        private async void OpenEventHandler(object sender, DialogOpenedEventArgs eventArgs)
        {
            await Task.Run(() => _work?.Invoke(_viewModel))
                      .ContinueWith((t, o) => eventArgs.Session.Close()
                                  , null, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}