using E_Learning.BL.DTO.Course;
using E_Learning.BL.DTO.CourseDTO.CourseUploadDTO;
using E_Learning.BL.DTO.Mail;
using E_Learning.BL.DTO.User;
using E_Learning.BL.Enums;
using E_Learning.BL.Managers.AuthenticationManager;
using E_Learning.BL.Managers.Mailmanager;
using E_Learning.DAL.Models;
using E_Learning.DAL.UnitOfWorkDP;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace E_Learning.BL.Managers.AccountManager
{
    public class AccountManager : IAccountManager
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtManager _jwtManager;
        private readonly IMailManager _mailManager;
        public AccountManager(UserManager<User> userManager, SignInManager<User> signInManager,
            RoleManager<Role> roleManager, IUnitOfWork unitOfWork, IJwtManager jwtManager , IMailManager mailManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
            _jwtManager = jwtManager;
            _mailManager = mailManager;
        }



        public async Task<IdentityResult> RegisterUserAsync(RegisterDTO registerDTO)
        {
            // Create the User entity from the DTO
            User user = new User()
            {
                Email = registerDTO.Email,
                PhoneNumber = registerDTO.Phone,
                UserName = registerDTO.Email,
                FName = registerDTO.FName,
                LName = registerDTO.LName,
            };

            // Create the user
            IdentityResult result = await _userManager.CreateAsync(user, registerDTO.Password);

            if (result.Succeeded)
            {
                // Map the string to the enum
                if (Enum.TryParse<UserRoleOptions>(registerDTO.UserRole, true, out var userRole))
                {
                    string roleName = userRole == UserRoleOptions.Admin ? UserRoleOptions.Admin.ToString() : UserRoleOptions.User.ToString();

                    if (await _roleManager.FindByNameAsync(roleName) == null)
                    {
                        Role role = new Role() { Name = roleName };
                        await _roleManager.CreateAsync(role);
                    }

                    await _userManager.AddToRoleAsync(user, roleName);

                    // Sign-in the user
                    // await _signInManager.SignInAsync(user, isPersistent: false);

                    // Generate JWT token and refresh token
                    var authenticationResponse = await _jwtManager.createJwtToken(user);
                    user.RefreshToken = authenticationResponse.RefreshToken;
                    user.RefreshTokenExpirationDateTime = authenticationResponse.RefreshTokenExpirationDateTime;

                    // Update the user with the new refresh token
                    await _userManager.UpdateAsync(user);
                }
                else
                {
                    await _userManager.AddToRoleAsync(user, UserRoleOptions.User.ToString());
                    // Handle invalid role value
                    result = IdentityResult.Failed(new IdentityError { Description = "Invalid role specified." });
                }
            }

            return result;
        }

        public async Task<User> FindUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<SignInResult> LoginUserAsync(LoginDTO loginDTO)
        {
            return await _signInManager.PasswordSignInAsync(loginDTO.Email, loginDTO.Password, isPersistent: false, lockoutOnFailure: false);
        }

        public async Task SignOutUserAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<AuthenticationResponseDTO> GenerateNewJwtTokenAsync(User user, TokenModel tokenModel)
        {
            var authenticationResponse = await _jwtManager.createJwtToken(user);
            user.RefreshToken = authenticationResponse.RefreshToken;
            user.RefreshTokenExpirationDateTime = authenticationResponse.RefreshTokenExpirationDateTime;

            await _userManager.UpdateAsync(user);

            return authenticationResponse;
        }

        public async Task<IEnumerable<object>> GetAllUsers()
        {
        
            var users = _unitOfWork.UserRepository.GetAll().ToList();

    
            var userResults = new List<object>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                userResults.Add(new
                {
                    user.Id,
                    user.FName,
                    user.LName,
                    user.Email,
                    user.ProfilePicture,
                    user.PhoneNumber,
                    user.UserName,
                    user.Facebook,
                    user.Twitter,
                    user.GitHub,
                    user.Ratings,
                    user.Description,
                    user.OwnedCourses,
                    user.Youtube,
                    user.CartItems,
                    role = roles,
                    user.EmailConfirmed
                });
            }

            return userResults;
        }

        public async Task<bool> IsEmailAlreadyRegisteredAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user != null;
        }

        public async Task<AuthenticationResponseDTO> LoginAsync(LoginDTO loginDTO)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDTO.Email, loginDTO.Password, isPersistent: true, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(loginDTO.Email);
     
                if (user == null)
                {
                    return null;
                }

                var authenticationResponse =await _jwtManager.createJwtToken(user);
                user.RefreshToken = authenticationResponse.RefreshToken;
                user.RefreshTokenExpirationDateTime = authenticationResponse.RefreshTokenExpirationDateTime;
                await _userManager.UpdateAsync(user);

                return authenticationResponse;
            }

            return null;
        }

        public async Task<AuthenticationResponseDTO> GenerateNewJwtTokenAsync(TokenModel tokenModel)
        {
            ClaimsPrincipal? principal = _jwtManager.GetClaimsPrinciplFromJwtToken(tokenModel.Token);

            if (principal == null)
            {
                return null;
            }

            string? email = principal.FindFirstValue(ClaimTypes.Email);
            User? user = await _userManager.FindByEmailAsync(email);

            if (user == null || user.RefreshToken != tokenModel.RefreshToken || user.RefreshTokenExpirationDateTime <= DateTime.Now)
            {
                return null;
            }

            return await GenerateNewJwtTokenAsync(user, tokenModel);
        }

        public async Task<(bool Success, string Message)> ForgetPasswordAsync(ForgetPasswordDTO forgetPasswordDTO)
        {
            var user = await _userManager.FindByNameAsync(forgetPasswordDTO.Email);
            if (user != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                string encodedToken = HttpUtility.UrlEncode(token);
                string link = $"http://localhost:4200/forget-passwordToken?token={encodedToken}&email={user.Email}";

                // HTML template for the email
                string htmlBody = $@"
        <html>
        <head>
            <style>
                .container {{
                    width: 80%;
                    margin: 0 auto;
                    background-color: #f9f9f9;
                    border: 1px solid #ddd;
                    border-radius: 8px;
                    padding: 20px;
                    font-family: Arial, sans-serif;
                    text-align: center;
                }}
                .button {{
                    background-color: #4CAF50;
                    border: none;
                    color: white;
                    padding: 10px 20px;
                    text-align: center;
                    text-decoration: none;
                    display: inline-block;
                    font-size: 16px;
                    margin: 20px 0;
                    border-radius: 5px;
                }}
                .button:hover {{
                    background-color: #45a049;
                }}
                .message {{
                    font-size: 18px;
                    color: #333;
                }}
                .footer {{
                    margin-top: 20px;
                    font-size: 12px;
                    color: #999;
                }}
            </style>
        </head>
        <body>
            <div class='container'>
                <h2>Password Reset Request</h2>
                <p class='message'>You have requested to reset your password. Click the button below to proceed.</p>
                <a href='{link}' class='button'>Reset Password</a>
                <p>If you did not request a password reset, please ignore this email.</p>
                <div class='footer'>
                    <p>Thank you,<br>The E-Learning Team</p>
                </div>
            </div>
        </body>
        </html>";

                MailData mailData = new MailData
                {
                    RecieverMail = user.Email,
                    EmailSubject = "Password Reset Request",
                    EmailBody = htmlBody
                };

                // Use mail service to send email
                if (_mailManager.SendMail(mailData))
                {
                    return (true, "Email has been sent successfully.");
                }
                else
                {
                    return (false, "Error with sending email.");
                }
            }

            return (false, "User not found.");
        }
        public async Task<(bool Success, string Message)> ResetPasswordAsync(ForgetPasswordDTO forgetPasswordDTO)
        {
            if (forgetPasswordDTO == null || string.IsNullOrWhiteSpace(forgetPasswordDTO.Token))
            {
                return (false, "Invalid password reset request.");
            }

            var user = await _userManager.FindByEmailAsync(forgetPasswordDTO.Email);
            if (user != null)
            {
                var resetPasswordResult = await _userManager.ResetPasswordAsync(user, forgetPasswordDTO.Token, forgetPasswordDTO.Password);
                if (!resetPasswordResult.Succeeded)
                {
                    var errors = string.Join(" | ", resetPasswordResult.Errors.Select(e => e.Description));
                    return (false, errors);
                }

                return (true, "Password has been reset successfully.");
            }

            return (false, "User does not exist.");
        }


        public async Task<IdentityResult> RegisterUserWithGoogle(GoogleregisterDTO googleRegisterDTO)
        {
            User user = new User()
            {
                Email = googleRegisterDTO.Email,
                FName = googleRegisterDTO.FName,
                UserName=googleRegisterDTO.Email
            
            };

            // Generate a secure password that meets the password policy
            string generatedPassword = GenerateSecurePassword();

            // Register the user with the generated password
            IdentityResult result = await _userManager.CreateAsync(user, generatedPassword);

            if (result.Succeeded)
            {
                // Assign the user role (modify based on your needs)
                string roleName = UserRoleOptions.User.ToString();

                if (await _roleManager.FindByNameAsync(roleName) == null)
                {
                    Role role = new Role() { Name = roleName };
                    await _roleManager.CreateAsync(role);
                }

                await _userManager.AddToRoleAsync(user, roleName);

                // Generate a JWT token and assign a refresh token
                var authenticationResponse = await _jwtManager.createJwtToken(user);
                user.RefreshToken = authenticationResponse.RefreshToken;
                user.RefreshTokenExpirationDateTime = authenticationResponse.RefreshTokenExpirationDateTime;

                await _userManager.UpdateAsync(user);  // Save changes
            }

            return result;
        }

        public async Task<AuthenticationResponseDTO> LoginWithGoogle(User user)
        {
            // Generate JWT token for the user
            var authenticationResponse = await _jwtManager.createJwtToken(user);

            user.RefreshToken = authenticationResponse.RefreshToken;
            user.RefreshTokenExpirationDateTime = authenticationResponse.RefreshTokenExpirationDateTime;

            await _userManager.UpdateAsync(user);  // Save refresh token details
            await _signInManager.SignInAsync(user, isPersistent: true);
            return authenticationResponse;
        }

        public string GenerateSecurePassword(int length = 12)
        {
            const string upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lowerCase = "abcdefghijklmnopqrstuvwxyz";
            const string digits = "0123456789";
            const string specialChars = "!@#$%^&*()-_=+[]{}|;:'\",.<>?";

            Random random = new Random();

            // Make sure we have at least one of each required character type
            string password = upperCase[random.Next(upperCase.Length)].ToString();
            password += lowerCase[random.Next(lowerCase.Length)];
            password += digits[random.Next(digits.Length)];
            password += specialChars[random.Next(specialChars.Length)];

            // Fill the rest of the password length with random characters
            string allChars = upperCase + lowerCase + digits + specialChars;
            for (int i = 4; i < length; i++)
            {
                password += allChars[random.Next(allChars.Length)];
            }

            // Shuffle the characters in the password to randomize their positions
            return new string(password.OrderBy(x => random.Next()).ToArray());
        }

        public IEnumerable<ReadCourseDTO> GetInstructorCourses (int id)
        {
            //var courses = _unitOfWork.CourseRepository.GetInstructorCourses(id).Select(c => c.)
            return _unitOfWork.CourseRepository.GetInstructorCourses(id).Select(c => new ReadCourseDTO
            {
                Id = c.Id,
                Title = c.Title,
                Description = c.Description,
                CoverPicture = c.CoverPicture,
                Price = (int)c.Price
                //Duration = c.Duration,
                //SectionsNo = c.SectionsNo,
                //Rate = c.Rate,
                //CreationDate = c.CreationDate,
            });


        }
        
        public async Task<(bool Success, string Message)> approve(int id)
        {
            // Find the user by ID
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return (false, "User not found.");
            }

            // Generate the email confirmation token
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            // Confirm the email
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return (true, "Email has been confirmed successfully.");
            }
            else
            {
                // Collect detailed errors if available
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                return (false, $"Error confirming email: {errors}");
            }
        }


        public async Task<IdentityResult> deleteuser(int id)
        {
            // Find user by ID, convert the integer ID to a string if necessary
            var user = await _userManager.FindByIdAsync(id.ToString());

            // Check if the user exists
            if (user == null)
            {
                // Return a failure result if the user was not found
                return IdentityResult.Failed(new IdentityError { Description = $"User with ID {id} not found." });
            }

            // Try to delete the user
            IdentityResult result = await _userManager.DeleteAsync(user);
           
            // Return the result of the delete operation (Success or Failed)
            return result;
        }

            

    }
}
