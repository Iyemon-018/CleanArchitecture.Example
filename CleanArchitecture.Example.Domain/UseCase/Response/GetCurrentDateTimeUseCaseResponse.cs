namespace CleanArchitecture.Example.Domain.UseCase.Response
{
    using System;

    public sealed class GetCurrentDateTimeUseCaseResponse
    {
        private readonly DateTime _currentTime;

        public GetCurrentDateTimeUseCaseResponse(DateTime currentTime)
        {
            _currentTime = currentTime;
        }

        public DateTime CurrentTime => _currentTime;
    }
}