using E_Learning.BL.DTO;
using E_Learning.BL.DTO.User;
using E_Learning.BL.DTO.Mail;
using E_Learning.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Pkcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.BL.Managers.Mailmanager
{
    public interface IMailManager
    {
        string sendrandommail(string subject, string body);

        Task<string> sendforgetemail(ForgetPasswordDTO forgetPasswordDTO);

        bool SendMail(MailData mailData);

    }
}
