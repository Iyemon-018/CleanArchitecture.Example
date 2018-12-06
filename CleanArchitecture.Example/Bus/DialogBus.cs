namespace CleanArchitecture.Example.Bus
{
    using System;
    using System.Threading.Tasks;
    using Domain.Bus;
    using Domain.Services;

    public sealed class DialogBus : IDialogBus
    {
        private readonly IDialogService _dialogService;

        private readonly IProgressService _progressService;

        public DialogBus(IDialogService dialogService, IProgressService progressService)
        {
            _dialogService = dialogService;
            _progressService = progressService;
        }

        public Task Information(IDialogData dialogData)
        {
            return _dialogService.Information(dialogData);
        }

        public Task<bool> Question(IDialogData dialogData)
        {
            return _dialogService.Question(dialogData);
        }

        public Task Error(IDialogData dialogData)
        {
            return _dialogService.Error(dialogData);
        }

        public Task Execute(Action<IProgressMessenger> work)
        {
            return _progressService.Execute(work);
        }

        public Task ExecuteCancellable(Action<IProgressMessenger> work)
        {
            return _progressService.ExecuteCancellable(work);
        }
    }
}