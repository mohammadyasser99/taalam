using E_Learning.BL.DTO.Mail;
using E_Learning.BL.DTO.User;
using E_Learning.BL.Enums;
using E_Learning.BL.Managers.AccountManager;
using E_Learning.BL.Managers.AuthenticationManager;
using E_Learning.BL.Managers.Mailmanager;
using E_Learning.DAL.Models;
using E_Learning.DAL.UnitOfWorkDP;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Web;
using Microsoft.AspNetCore.Authentication.Facebook;
using E_Learning.BL.DTO.CourseDTO.CourseUploadDTO;
using E_Learning.BL.DTO.Course;

namespace E_Learning.APIs.Controllers
{
    [AllowAnonymous]
    public class AccountController : APIBaseController
    {
        private readonly IAccountManager _accountManager;
      
        public AccountController(IAccountManager accountManager,IMailManager mailManager, UserManager<User> userManager)
        {
            _accountManager = accountManager;
         
           
        }

        [HttpGet("debugger")]

        public IActionResult Get()
        {
            var name = User.Identity.Name;
            var users = User;
            return Ok(name);
        }


        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            // Call the account manager to sign out the user
            await _accountManager.SignOutUserAsync();

            HttpContext.Response.Cookies.Delete("taalam");
            return NoContent();
        }


        [HttpPost("Register")]
        public async Task<IActionResult> AccountRegister([FromBody] RegisterDTO registerDTO)
        {
            if (!ModelState.IsValid)
            {
                string errorMessage = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return Problem(errorMessage);
            }
            //here we are checking the existing of the user 
            IdentityResult result = await _accountManager.RegisterUserAsync(registerDTO);

            if (result.Succeeded)
            {
                //in case of success register login the user
                var user = await _accountManager.FindUserByEmailAsync(registerDTO.Email);
                LoginDTO loginDTO = new LoginDTO() { Email = user.Email , Password =registerDTO.Password};
                //_signInManager.PasswordSignInAsync
                var authenticationResponse = await _accountManager.LoginAsync(loginDTO);
                if (authenticationResponse != null)
                {
                    return Ok(authenticationResponse);
                }
                else
                {
                    return Problem("error with creating jwt");
                }
             
            }
            else
            {
                string errorMessage = string.Join(" | ", result.Errors.Select(e => e.Description));
                return Problem(errorMessage);
            }
        }



            [HttpGet("getusers")]
        public async Task< IActionResult> GetUsers()
        {
           
                var users = await _accountManager.GetAllUsers();
                return Ok(users);
            
           
        }





        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                string errorMessage = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return Problem(errorMessage);
            }

            var authenticationResponse = await _accountManager.LoginAsync(loginDTO);

            if (authenticationResponse == null)
            {
                return Problem("Invalid email or password");
            }

            return Ok(authenticationResponse);
        }

        [HttpGet("signin-facebook")]
        public async Task LoginFacebook()
        {
            await HttpContext.ChallengeAsync(FacebookDefaults.AuthenticationScheme, new AuthenticationProperties
            {
                RedirectUri = Url.Action("ExternalLoginCallback")
            });
        }

        [HttpGet("signin-google")]
        public async Task LoginGoogle()
        {


            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties
            {
                RedirectUri = Url.Action("ExternalLoginCallback")
            });


            // this needs google business account to extract phone number
            //await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties
            //{
            //    RedirectUri = Url.Action("ExternalLoginCallback"),
            //    Items = { { "prompt", "consent" }, { "scope", "profile email https://www.googleapis.com/auth/user.phonenumbers.read" } }
            //});

        }

        [HttpGet("external-login-callback")]
        public async Task<IActionResult> ExternalLoginCallback()
        {
            // Retrieve authentication info from Google
            var info = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);
            if (info.Principal == null)
            {
                return Problem("Failed to authenticate via Google");
            }

            // Get user details from Google
            var email = info.Principal.FindFirstValue(ClaimTypes.Email);
            var name = info.Principal.FindFirstValue(ClaimTypes.GivenName);


            if (string.IsNullOrEmpty(email))
            {
                return Problem("Google did not provide an email.");
            }

            // Check if the user already exists in the database
            var user = await _accountManager.FindUserByEmailAsync(email);

            // If the user doesn't exist, register them
            if (user == null)
            {
                GoogleregisterDTO googleregisterDTO = new GoogleregisterDTO()
                {
                    Email = email,
                    FName = name
                };

                IdentityResult registerResult = await _accountManager.RegisterUserWithGoogle(googleregisterDTO);

                if (!registerResult.Succeeded)
                {
                    string errorMessage = string.Join(" | ", registerResult.Errors.Select(e => e.Description));
                    return Problem(errorMessage);
                }

                // Retrieve the newly registered user
                user = await _accountManager.FindUserByEmailAsync(googleregisterDTO.Email);
            }

            // Log the user in after registration or if already existed
            var authenticationResponse = await _accountManager.LoginWithGoogle(user);

            if (authenticationResponse == null)
            {
                return Problem("Login failed after registration.");
            }

            //return Ok(authenticationResponse);  // Return the JWT token or necessary response
            return Redirect($"http://localhost:4200/auth-callback?token={authenticationResponse.Token}");
        }

        [HttpGet("login-failed")]
        public IActionResult LoginFailed()
        {
            return Problem("Login with Google was canceled or failed. Please try again.");
        }

        [HttpGet("is-email-registered")]
        public async Task<IActionResult> IsEmailAlreadyRegistered(string email)
        {
            bool isRegistered = await _accountManager.IsEmailAlreadyRegisteredAsync(email);
            return Ok(!isRegistered);
        }

      

        [HttpPost("generate-new-jwt-token")]
        public async Task<IActionResult> GenerateNewAccessToken([FromBody] TokenModel tokenModel)
        {
            if (tokenModel == null)
            {
                return BadRequest("Invalid client request");
            }

            var authenticationResponse = await _accountManager.GenerateNewJwtTokenAsync(tokenModel);

            if (authenticationResponse == null)
            {
                return BadRequest("Invalid JWT access token or refresh token");
            }

            return Ok(authenticationResponse);
        }

//        [HttpGet("forget-password")] //malhash lazma
//public async Task<IActionResult> forgetPasswordview(string email , string token)
//        {
//            var model = new ForgetPasswordDTO { Email = email, Token = token };
//            return Ok(model);
//        }

        [HttpPost("forget-password")]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordDTO forgetPasswordDTO)
        {
            var (success, message) = await _accountManager.ForgetPasswordAsync(forgetPasswordDTO);
            if (success)
            {
                return Ok(new { Message = message });
            }
            else
            {
                return Problem(message);
            }
        }
    

        [HttpPost("reset-password")]
        public async Task<IActionResult> resetpassword(ForgetPasswordDTO forgetPasswordDTO)
        {
            if (!ModelState.IsValid)
            {
                string errorMessage = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return Problem(errorMessage);
            }

            var (success, message) = await _accountManager.ResetPasswordAsync(forgetPasswordDTO);
            if (success)
            {
                return Ok(new { Message = message });
            }
            else
            {
                return BadRequest(new { Message = message });
            }



        }

        [HttpDelete("delete/{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            // Await the result of the async deleteuser method
            var result = await _accountManager.deleteuser(id);

            // Check if the deletion was successful
            if (result.Succeeded)
            {
                return Ok(new
                {
                    Message = "Deleted successfully"
                });
            }
            else
            {
                // Return a BadRequest with errors if deletion failed
                return BadRequest(new
                {
                    Message = "Error in deleting user",
                    Errors = result.Errors.Select(e => e.Description).ToList()
                });
            }
        }

        [HttpGet("instructor-courses/{id}")]
        public ActionResult<IEnumerable<ReadCourseDTO>> GetInstructorCourses(int id)
        {
            IEnumerable<ReadCourseDTO> InstructorCourses = _accountManager.GetInstructorCourses(id);
            if (InstructorCourses == null)
                return NotFound();
            return Ok(InstructorCourses);
        }

        [HttpGet("approveuser/{id}")]
        [Authorize]
        public async Task<IActionResult> approveuser(int id)
        {
            
            var result = await _accountManager.approve(id);

            if (result.Success)
            {
                // Return success with 200 OK and a structured response
                return Ok(new
                {
                    Success = true,
                    Message = result.Message
                });
            }
            else
            {
                // Determine the error and return the appropriate status code
                if (result.Message.Contains("User not found"))
                {
                    // 404 Not Found for missing user
                    return NotFound(new
                    {
                        Success = false,
                        Message = result.Message
                    });
                }
                else
                {
                    // 400 Bad Request for other issues
                    return BadRequest(new
                    {
                        Success = false,
                        Message = result.Message
                    });
                }
            }
        }

    }

}

