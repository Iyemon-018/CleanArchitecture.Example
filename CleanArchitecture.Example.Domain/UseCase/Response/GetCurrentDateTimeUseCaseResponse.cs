namespace CleanArchitecture.Example.Domain.UseCase.Response
{
    using System;

    public sealed class GetCurrentDateTimeUseCaseResponse : ResponseBase
    {
        public GetCurrentDateTimeUseCaseResponse(ResponseResultType resultType, string cause, DateTime currentTime) :
            base(resultType, cause)
        {
            CurrentTime = currentTime;
        }

        public DateTime CurrentTime { get; }
    }
}