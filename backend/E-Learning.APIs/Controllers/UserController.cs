using E_Learning.BL.DTO.User;
using E_Learning.BL.Managers.CategoryManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning.APIs.Controllers
{
    [AllowAnonymous]

    public class UserController : APIBaseController
    {
        private readonly IUserManager _userManager;
        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("Get-Instructor-Info/{id}")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<InstructorDTO>> GetInstructorInfo(int id)
        {
            var instructorInfo = _userManager.GetInstructorInfo(id);
            if (instructorInfo == null)
                return NotFound();
            return Ok(instructorInfo);
        }

        [HttpPut("Edit-User-Profile")]
        
        public async Task<ActionResult<EditUserProfileDTO>> EditUserProfile([FromForm] EditUserProfileDTO editUserProfileDTO)
        {
            string scheme = Request.Scheme;
            string host = Request.Host.Value;
            var result =  await _userManager.EditUserProfile(editUserProfileDTO ,scheme,host); // Calling
            if (result)
            {
                return Ok(editUserProfileDTO);
            }
            return BadRequest("Failed to update the profile");
        }
    }
}
