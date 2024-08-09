using System.Net.Mail;

namespace Common.Domain.Services;

public interface IMailProviderService
{
    Task<bool> SendMailAsync(MailAddress from, MailAddress[] recipients, string subject, string body, MailAddress[]? replies = null, MailAddress[]? cc = null, MailAddress[]? bcc = null, CancellationToken ct = default);
}
