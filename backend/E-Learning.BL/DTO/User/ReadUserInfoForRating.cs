using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.BL.DTO.User
{
    public class ReadUserInfoForRating
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ProfilePicture { get; set; }
    }
}
