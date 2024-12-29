using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.BL.DTO.User
{
    public class ForgetPasswordDTO
    {

        public string? Password { get; set; } 
        [Compare("Password",ErrorMessage ="the password and the confirmation password doesnt match")]
        public string? confirmPassword { get; set; }

        public string? Email { get; set; }
        public string? Token { get; set; }

    }
}
