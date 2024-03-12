using CompetencePlatform.Application.Common.Email;
using CompetencePlatform.Application.Services;
using System.Threading.Tasks;


namespace CompetencePlatform.Api.IntegrationTests.Helpers.Services;

public class EmailTestService : IEmailService
{
    public async Task SendEmailAsync(EmailMessage emailMessage)
    {
        await Task.Delay(100);
    }
}
