namespace Portifolio.Webapi.Services;

public interface ISendEmail
{
    Task SendEmailAsync(string email, string subject, string body);
}