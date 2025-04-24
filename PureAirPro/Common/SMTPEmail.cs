using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace PureAirPro.Common
{
    public class SMTPEmail
    {
        public async Task<bool> TaskSendEmail(String email,String firstName, String lastName)
        {
            try
            {
                var apiKey = "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";
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("krunal.international.patel@gmail.com", "PureAir Pro Support");
                var subject = "Welcome to PureAir Pro - Your Source for Clean Air!";
                var to = new EmailAddress(email, firstName + lastName);
                var plainTextContent = "";
                var htmlContent = $"<table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"margin: auto; max-width: 600px; border-collapse: collapse;\">\r\n   \r\n    <tr>\r\n      <td style=\"padding: 20px;\">\r\n           <p>Dear {firstName},</p>\r\n        <p>Welcome to PureAir Pro, your ultimate destination for everything related to air quality and purification solutions! We're thrilled to have you join our community dedicated to promoting healthy living through clean air.</p>\r\n        <p>By signing up with PureAir Pro, you've taken the first step towards ensuring a cleaner, healthier environment for yourself and your loved ones.</p>\r\n        <p>Here's what you can expect from your PureAir Pro membership:</p>\r\n        <ol>\r\n          <li>Real-time Updates: Stay ahead of the curve with our up-to-date information on future air quality forecasts, helping you plan ahead and take necessary precautions.</li>\r\n          <li>Expert Advice: Our team of air quality specialists is here to provide you with expert guidance and recommendations on the best air purification solutions tailored to your specific requirements.</li>\r\n          <li>Exclusive Offers: As a valued member, you'll gain access to exclusive discounts and promotions on our range of premium air purifiers, ensuring that you can breathe easy without breaking the bank.</li>\r\n        </ol>\r\n        <p>We're committed to delivering the highest standard of service and support to our members, and we're excited to embark on this journey with you.</p>\r\n        <p>Should you have any questions, feedback, or concerns, please don't hesitate to reach out to our customer support team at <a href=\"mailto:support@pureairpro.com\">support@pureairpro.com</a>. We're always here to assist you and ensure that your PureAir Pro experience is nothing short of exceptional.</p>\r\n        <p>Once again, welcome to PureAir Pro! Together, let's make every breath a breath of fresh air.</p>\r\n        <p>Warm regards,</p>\r\n        <p>PureAir Pro Team</p>\r\n          </td>\r\n    </tr>\r\n  </table>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send email: {ex.Message}");
            }
            return false;
        }
    }
}

