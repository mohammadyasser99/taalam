using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using E_Learning.BL.DTO.Mail;
using E_Learning.BL.DTO.User;
using E_Learning.DAL.Models;
using Microsoft.AspNetCore.Identity;

using MimeKit;
using MailKit.Net.Smtp;

using MailKit.Security;
using MimeKit.Text;

using Microsoft.Extensions.Configuration;

namespace E_Learning.BL.Managers.Mailmanager
{
    public class MailManager : IMailManager
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        public MailManager(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;

        }



        public async Task<string> sendforgetemail(ForgetPasswordDTO forgetPasswordDTO)
        {
            var user = await _userManager.FindByNameAsync(forgetPasswordDTO.Email);
            if (user != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                string link = $"http://localhost:5062/api/Account/ForgetPassword?token={token}&email={user.Email}";

                //send the email with this url

                return $"the forget password email is sent ,token={token.ToString()}";

            }
            else
            {
                return "error";
            }
        }



        public string sendrandommail(string subject, string body)
        {
            return "hello";
        }

        public bool SendMail(MailData mailData)
        {

            try
            {

                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_configuration["MailSettings:Gmail"])); // Your Gmail address from settings
                email.To.Add(MailboxAddress.Parse(mailData.RecieverMail)); // Replace with recipient's email
                email.Subject = mailData.EmailSubject;
                email.Body = new TextPart(TextFormat.Html) { Text = mailData.EmailBody };

                using var smtp = new SmtpClient();
                smtp.Connect(_configuration["MailSettings:Host"], Int32.Parse(_configuration["MailSettings:Port"]), SecureSocketOptions.StartTls);
                smtp.Authenticate(_configuration["MailSettings:Gmail"], _configuration["MailSettings:Password"]);
                smtp.Send(email);
                smtp.Disconnect(true);

                return true;
            }
            catch
            {
                // Handle exception (log error)
                return false;
            }
        }

    }

}







