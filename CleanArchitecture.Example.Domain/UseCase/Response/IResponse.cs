namespace CleanArchitecture.Example.Domain.UseCase.Response
{
    public interface IResponse
    {
        ResponseResultType ResultType { get; }

        string Cause { get; }
    }
}