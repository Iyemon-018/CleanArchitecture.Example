namespace CleanArchitecture.Example.Domain.UseCase.Response
{
    using System.Collections.Generic;
    using System.Linq;
    using CleanArchitecture.Example.Domain.Data;

    public sealed class DetailDataListUseCaseResponse : ResponseBase
    {
        private readonly List<UserDetail> _userDetails;

        public IEnumerable<UserDetail> GetUserDetails => _userDetails;

        public DetailDataListUseCaseResponse(ResponseResultType resultType, string cause, IEnumerable<UserDetail> userDetails) : base(resultType, cause)
        {
            _userDetails = userDetails != null ? new List<UserDetail>(userDetails) : Enumerable.Empty<UserDetail>().ToList();
        }
    }
}