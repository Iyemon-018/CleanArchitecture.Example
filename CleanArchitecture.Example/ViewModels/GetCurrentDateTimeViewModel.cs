namespace CleanArchitecture.Example.ViewModels
{
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Domain.Bus;
    using Domain.Services;
    using Domain.UseCase;
    using Prism.Commands;

    public sealed class GetCurrentDateTimeViewModel : AppViewModelBase
    {
        private readonly IGetCurrentDateTimeUseCase _getCurrentDateTimeUseCase;

        public GetCurrentDateTimeViewModel(IDialogBus dialogBus
                                         , IGetCurrentDateTimeUseCase getCurrentDateTimeUseCase) : base(dialogBus)
        {
            _getCurrentDateTimeUseCase = getCurrentDateTimeUseCase;
            GetCurrentDateTimeCommand  = new DelegateCommand(ExecuteGetCurrentDateTimeUseCase);
        }

        public ICommand GetCurrentDateTimeCommand { get; }

        private async void ExecuteGetCurrentDateTimeUseCase()
        {
            await Task.Run(() => _getCurrentDateTimeUseCase.Handle(new GetCurrentDateTimeUseCaseRequest()));

            await DialogBus.Information(DialogData.Build("UseCase 完了", "UseCase の実行が完了しました。"));
        }
    }
}