using System;
using System.Threading;

namespace CleanArchitecture.Example.Domain.UseCase
{
    public sealed class GetCurrentDateTimeUseCase : IGetCurrentDateTimeUseCase
    {
        public GetCurrentDateTimeUseCaseResponse Handle(GetCurrentDateTimeUseCaseRequest request)
        {
            Thread.Sleep(TimeSpan.FromSeconds(3));
            return new GetCurrentDateTimeUseCaseResponse(DateTime.Now);
        }
    }

    public sealed class GetCurrentDateTimeUseCaseResponse
    {
        private readonly DateTime _currentTime;

        public GetCurrentDateTimeUseCaseResponse(DateTime currentTime)
        {
            _currentTime = currentTime;
        }

        public DateTime CurrentTime => _currentTime;
    }

    public sealed class GetCurrentDateTimeUseCaseRequest
    {

    }
}