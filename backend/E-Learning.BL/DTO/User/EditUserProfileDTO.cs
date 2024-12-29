using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.BL.DTO.User
{
    public class EditUserProfileDTO
    {
        public int Id { get; set; }
        public string? FName { get; set; }
        public string? LName { get; set; }
        public string? Description { get; set; }
        public string? Github { get; set; }
        public string? Twitter { get; set; }
        public string? Facebook { get; set; }
        public string? LinkedIn { get; set; }
        public string? Youtube { get; set; }
        public IFormFile? ProfilePictureFile { get; set; }
        public string? ProfilePicture { get; set; }
    }
}
