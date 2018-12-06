namespace CleanArchitecture.Example.ViewModels
{
    using System;
    using System.Windows.Input;
    using CleanArchitecture.Example.Domain.Bus;
    using CleanArchitecture.Example.Domain.Presenter;
    using CleanArchitecture.Example.Domain.Services;
    using CleanArchitecture.Example.Domain.UseCase;
    using CleanArchitecture.Example.Domain.UseCase.Request;
    using CleanArchitecture.Example.Domain.UseCase.Response;
    using Prism.Commands;

    public sealed class GetCurrentDateTimeViewModel : AppViewModelBase
    {
        private readonly IGetCurrentDateTimeUseCase _getCurrentDateTimeUseCase;

        private DateTime? _currentDateTime;

        private bool _isSuccess;

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

        public bool IsSuccess
        {
            get => _isSuccess;
            set => SetProperty(ref _isSuccess, value);
        }

        public DateTime? CurrentDateTime
        {
            get => _currentDateTime;
            set => SetProperty(ref _currentDateTime, value);
        }

        private async void ExecuteGetCurrentDateTimeUseCase()
        {
            GetCurrentDateTimeUseCaseResponse response = null;
            CurrentDateTime = null;

            await DialogBus.Execute(x =>
                                    {
                                        var request = new GetCurrentDateTimeUseCaseRequest(ProgressPresenter, IsSuccess);
                                        response = _getCurrentDateTimeUseCase.Handle(request);
                                    });

            if (response.ResultType == ResponseResultType.Success)
            {
                await DialogBus.Information(DialogData.Build("データ取得 完了", "データの取得が完了しました。"));
                CurrentDateTime = response.CurrentTime;
            }
            else if (response.ResultType == ResponseResultType.Failed)
            {
                await DialogBus.Error(DialogData.Build("データ取得 失敗"
                                                     , $"データの取得に失敗しました。{Environment.NewLine}"
                                                       + $"{response.Cause}"));
            }
        }
    }
}