namespace CleanArchitecture.Example.ViewModels
{
    using System.Windows.Input;
    using Domain.Bus;
    using Domain.Presenter;
    using Domain.Services;
    using Domain.UseCase;
    using Domain.UseCase.Request;
    using Prism.Commands;

    public sealed class GetCurrentDateTimeViewModel : AppViewModelBase
    {
        private readonly IGetCurrentDateTimeUseCase _getCurrentDateTimeUseCase;

        public GetCurrentDateTimeViewModel(IDialogBus dialogBus
                                         , IProgressPresenter progressPresenter
                                         , IGetCurrentDateTimeUseCase getCurrentDateTimeUseCase) :
            base(dialogBus, progressPresenter)
        {
            _getCurrentDateTimeUseCase = getCurrentDateTimeUseCase;
            GetCurrentDateTimeCommand  = new DelegateCommand(ExecuteGetCurrentDateTimeUseCase);
        }

        public ICommand GetCurrentDateTimeCommand { get; }

        private async void ExecuteGetCurrentDateTimeUseCase()
        {
            await DialogBus.Execute(x =>
                                        _getCurrentDateTimeUseCase
                                            .Handle(new GetCurrentDateTimeUseCaseRequest(ProgressPresenter)));

            await DialogBus.Information(DialogData.Build("UseCase 完了", "UseCase の実行が完了しました。"));
        }
    }
}