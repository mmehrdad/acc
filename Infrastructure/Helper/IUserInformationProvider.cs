
using City.Amlak.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;

namespace Acc.Infrastructure.Helper
{
    public interface IUserInformationProvider : IScopedDependency
    {
        Guid? CurrentUserId { get; }
        string CurrentUserName { get; }
        bool IsAuthenticated { get; }

        Guid? GetCurrentUserId();
        string GetCurrentUserName();

        HttpContext HttpContext();
    }
}
