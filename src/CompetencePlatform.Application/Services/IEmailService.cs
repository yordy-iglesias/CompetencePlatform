using CompetencePlatform.Application.Common.Email;

namespace CompetencePlatform.Application.Services;

public interface IEmailService
{
    Task SendEmailAsync(EmailMessage emailMessage);
}
