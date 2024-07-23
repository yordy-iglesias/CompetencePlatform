namespace CompetencePlatform.Shared.Services
{
    public interface IClaimService
    {
        int GetUserId();

        int GetClaim(string key);
        string GetUserNameFromIdentity();
    }
}
