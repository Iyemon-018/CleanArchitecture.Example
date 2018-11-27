namespace CleanArchitecture.Example.Domain.UseCase.Response
{
    public abstract class ResponseBase : IResponse
    {
        protected ResponseBase(ResponseResultType resultType, string cause)
        {
            ResultType = resultType;
            Cause = cause;
        }

        public ResponseResultType ResultType { get; }

        public string Cause { get; }
    }
}