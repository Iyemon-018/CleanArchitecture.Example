namespace CleanArchitecture.Example.ViewModels
{
    using System;
    using System.Windows.Input;
    using Domain.Bus;
    using Domain.Presenter;
    using Domain.Services;
    using Domain.UseCase;
    using Domain.UseCase.Request;
    using Domain.UseCase.Response;
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
            _isSuccess = true;
            GetCurrentDateTimeCommand  = new DelegateCommand(ExecuteGetCurrentDateTimeUseCase);
        }

        public ICommand GetCurrentDateTimeCommand { get; }

        private async void ExecuteGetCurrentDateTimeUseCase()
        {
            IResponse response = null;
            await DialogBus.Execute(x =>
                                    {
                                        var request = new GetCurrentDateTimeUseCaseRequest(ProgressPresenter, IsSuccess);
                                        response = _getCurrentDateTimeUseCase.Handle(request);
                                    });

            if (response.ResultType == ResponseResultType.Success)
            {
                await DialogBus.Information(DialogData.Build("データ取得 完了", "データの取得が完了しました。"));
            }
            else if (response.ResultType == ResponseResultType.Failed)
            {
                await DialogBus.Error(DialogData.Build("データ取得 失敗"
                                                     , $"データの取得に失敗しました。{Environment.NewLine}"
                                                       + $"{response.Cause}"));
            }
        }

        private bool _isSuccess;

        public bool IsSuccess
        {
            get => _isSuccess;
            set => SetProperty(ref _isSuccess, value);
        }
    }
}