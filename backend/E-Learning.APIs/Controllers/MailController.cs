using E_Learning.BL.DTO.Mail;
using E_Learning.BL.Managers.Mailmanager;
using MailKit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Org.BouncyCastle.Asn1.Crmf;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace E_Learning.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MailController : ControllerBase
    {
      private readonly  IMailManager _mailmanager;
        public MailController(IMailManager mailmanager)
        {
           _mailmanager = mailmanager;
        }

        [HttpPost]
        public IActionResult SendMail(MailData Mail_Data)
        {
         

            if (_mailmanager.SendMail(Mail_Data) == true)
            {
                return Ok("email has been sent");
            }
            else
            {
                return Problem("error with send email");
            }


        }

    }
}
