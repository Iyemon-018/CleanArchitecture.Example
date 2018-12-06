namespace CleanArchitecture.Example.Domain.UseCase
{
    using System;
    using System.Threading;
    using CleanArchitecture.Example.Domain.UseCase.Request;
    using CleanArchitecture.Example.Domain.UseCase.Response;

    public sealed class DetailDataListUseCase : IDetailDataListUseCase
    {
        private static readonly int TaskCount = 10;

        public DetailDataListUseCaseResponse Handle(DetailDataListUseCaseRequest request)
        {
            request.ProgressPresenter.Initialize(TaskCount);
            request.ProgressPresenter.SetMessage("データを取得しています。しばらくお待ち下さい。");

            for (int i = 0; i < TaskCount; i++)
            {
                if (request.ProgressPresenter.IsCanceled)
                {
                    return new DetailDataListUseCaseResponse(ResponseResultType.Canceled, "ユーザーによってキャンセルされました。");
                }

                Thread.Sleep(TimeSpan.FromSeconds(1));

                request.ProgressPresenter.UpdateValue(i + 1);
            }
            
            request.ProgressPresenter.SetMessage("完了までもうしばらくお待ち下さい。");
            Thread.Sleep(TimeSpan.FromSeconds(3));

            return new DetailDataListUseCaseResponse(ResponseResultType.Success, string.Empty);
        }
    }
}