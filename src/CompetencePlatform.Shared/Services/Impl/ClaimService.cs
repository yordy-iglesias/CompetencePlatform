using System;
using System.Security.Claims;
using CompetencePlatform.Shared.Services;
using Microsoft.AspNetCore.Http;

namespace CompetencePlatform.Shared.Services.Impl
{
    public class ClaimService : IClaimService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClaimService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetUserId()
        {
            return GetClaim(ClaimTypes.NameIdentifier);
        }

        public int GetClaim(string key)
        {
            var result = _httpContextAccessor.HttpContext?.User?.FindFirst(key)?.Value;
            if (!String.IsNullOrEmpty(result))
                return int.Parse(result);
            return 0;

        }
        public string GetUserNameFromIdentity()
        {
            return _httpContextAccessor.HttpContext?.User?.Identity.Name;
        }
    }
}
