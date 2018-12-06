namespace CleanArchitecture.Example.Domain.UseCase.Response
{
    public sealed class DetailDataListUseCaseResponse : ResponseBase
    {
        public DetailDataListUseCaseResponse(ResponseResultType resultType, string cause) : base(resultType, cause)
        {
        }
    }
}