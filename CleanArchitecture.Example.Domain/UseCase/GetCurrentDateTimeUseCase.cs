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
            for (var i = 0; i < 10; i++)
            {
                request.ProgressPresenter.SetMessage($"{i} 秒経過...");
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }

            return new GetCurrentDateTimeUseCaseResponse(DateTime.Now);
        }
    }
}