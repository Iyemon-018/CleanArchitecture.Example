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

            var currentDateTime = DateTime.Now;
            return request.IsSuccess
                       ? new GetCurrentDateTimeUseCaseResponse(ResponseResultType.Success, string.Empty, currentDateTime)
                       : new GetCurrentDateTimeUseCaseResponse(ResponseResultType.Failed, $"原因不明のエラーが発生しました。", currentDateTime);
        }
    }
}