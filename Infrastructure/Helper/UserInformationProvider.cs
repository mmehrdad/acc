using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Acc.Infrastructure.Helper
{
    public class UserInformationProvider : IUserInformationProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserInformationProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool IsAuthenticated => _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;

        public Guid? CurrentUserId => GetCurrentUserId() ?? null;

        public string CurrentUserName => _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name)?.Value ?? null;

        public string GetCurrentUserName()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name)?.Value ?? null;
        }

        public Guid? GetCurrentUserId()
        {
            var httpContext = _httpContextAccessor.HttpContext;

            // You can now use the 'user' to get claims, roles, etc.
            var userId = httpContext.User.FindFirst("sub")?.Value;
            return Guid.Parse(userId);
        }

        public HttpContext HttpContext() {
            return _httpContextAccessor.HttpContext;
        }
    }
}
