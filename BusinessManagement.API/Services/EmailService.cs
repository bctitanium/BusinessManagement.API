﻿using BusinessManagement.Models;
using BusinessManagement.Settings;
using Microsoft.Extensions.Options;
using System.Net.Mail;

namespace BusinessManagement.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfig _emailConfig;
        private readonly SmtpClient _smtpClient;

        public EmailService(IOptionsMonitor<EmailConfig> emailConfig, SmtpClient smtpClient)
        {
            _emailConfig = emailConfig.CurrentValue;
            _smtpClient = smtpClient;
        }

        public async Task Send(EmailModel emailModel)
        {
            MailAddress from = new(_emailConfig.UserName, _emailConfig.DisplayName);
            MailMessage message = new(_emailConfig.UserName, emailModel.To, emailModel.Subject, emailModel.Body);
            message.From = from;
            message.IsBodyHtml = true;

            await _smtpClient.SendMailAsync(message);
        }

        public string GetTemplate(string type)
        {
            string FilePath = Directory.GetCurrentDirectory() + $"\\Templates\\{type}.html";
            StreamReader str = new(FilePath);
            string templateBody = str.ReadToEnd();
            str.Close();

            return templateBody;
        }
    }
}
