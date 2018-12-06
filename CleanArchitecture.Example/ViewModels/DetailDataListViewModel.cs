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

    public sealed class DetailDataListViewModel : AppViewModelBase
    {
        private readonly IDetailDataListUseCase _detailDataListUseCase;

        public DetailDataListViewModel(IDialogBus dialogBus, IProgressPresenter progressPresenter, IDetailDataListUseCase detailDataListUseCase) :
            base(dialogBus, progressPresenter)
        {
            _detailDataListUseCase = detailDataListUseCase;
            DetailDataListCommand = new DelegateCommand(ExecuteDetailDataListCommand);
        }

        public ICommand DetailDataListCommand { get; }

        private async void ExecuteDetailDataListCommand()
        {
            DetailDataListUseCaseResponse response = null;

            await DialogBus.ExecuteCancellable(p =>
                                               {
                                                   var request = new DetailDataListUseCaseRequest(ProgressPresenter);
                                                   response = _detailDataListUseCase.Handle(request);
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
    }
}