using System.Threading.Tasks;
using System.Windows.Input;
using CleanArchitecture.Example.Domain.Services;
using CleanArchitecture.Example.Domain.UseCase;
using Prism.Commands;

namespace CleanArchitecture.Example.ViewModels
{
    public sealed class GetCurrentDateTimeViewModel : AppViewModelBase
    {
        private readonly IGetCurrentDateTimeUseCase _getCurrentDateTimeUseCase;

        public GetCurrentDateTimeViewModel(IDialogService dialogService, IGetCurrentDateTimeUseCase getCurrentDateTimeUseCase) : base(dialogService)
        {
            _getCurrentDateTimeUseCase = getCurrentDateTimeUseCase;
            GetCurrentDateTimeCommand = new DelegateCommand(ExecuteGetCurrentDateTimeUseCase);
        }

        private async void ExecuteGetCurrentDateTimeUseCase()
        {
            await Task.Run(() => _getCurrentDateTimeUseCase.Handle(new GetCurrentDateTimeUseCaseRequest()));

            await DialogService.Information(DialogData.Build("UseCase 完了", "UseCase の実行が完了しました。"));
        }

        public ICommand GetCurrentDateTimeCommand { get; }
    }
}