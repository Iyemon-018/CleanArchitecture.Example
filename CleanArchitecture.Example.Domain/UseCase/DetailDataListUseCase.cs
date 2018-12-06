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

            for (int i = 0; i < TaskCount; i++)
            {
                if (request.ProgressPresenter.IsCanceled)
                {
                    return new DetailDataListUseCaseResponse(ResponseResultType.Canceled, "ユーザーによってキャンセルされました。");
                }

                Thread.Sleep(TimeSpan.FromSeconds(2));
                request.ProgressPresenter.UpdateValue(i);
            }

            return new DetailDataListUseCaseResponse(ResponseResultType.Success, string.Empty);
        }
    }
}