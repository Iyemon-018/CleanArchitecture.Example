namespace CleanArchitecture.Example.Domain.UseCase
{
    using System;
    using System.Threading;
    using Request;
    using Response;

    public sealed class GetCurrentDateTimeUseCase : IGetCurrentDateTimeUseCase
    {
        public GetCurrentDateTimeUseCaseResponse Handle(GetCurrentDateTimeUseCaseRequest request)
        {
            request.ProgressPresenter.SetMessage($"データを取得しています。{Environment.NewLine}"
                                                 + "しばらくお待ちください。");
            Thread.Sleep(TimeSpan.FromSeconds(3));

            // 実行結果にランダム性を持たせる。
            var currentDateTime = DateTime.Now;
            return currentDateTime.Millisecond % 2 == 0
                       ? new GetCurrentDateTimeUseCaseResponse(ResponseResultType.Success, string.Empty, currentDateTime)
                       : new GetCurrentDateTimeUseCaseResponse(ResponseResultType.Failed, $"原因不明のエラーが発生しました。", currentDateTime);
        }
    }
}