using E_Learning.BL.DTO.Course;
using E_Learning.BL.DTO.CourseDTO.CourseUploadDTO;
using E_Learning.BL.DTO.User;
using E_Learning.DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.BL.Managers.AccountManager
{
    public interface IAccountManager
    {
        Task<IdentityResult> RegisterUserAsync(RegisterDTO registerDTO);
        Task<User> FindUserByEmailAsync(string email);
        Task<SignInResult> LoginUserAsync(LoginDTO loginDTO);
        Task SignOutUserAsync();
        Task<AuthenticationResponseDTO> GenerateNewJwtTokenAsync(User user, TokenModel tokenModel);
         Task<IEnumerable<object>> GetAllUsers();
        Task<bool> IsEmailAlreadyRegisteredAsync(string email);
        Task<AuthenticationResponseDTO> LoginAsync(LoginDTO loginDTO);
        Task<AuthenticationResponseDTO> GenerateNewJwtTokenAsync(TokenModel tokenModel);

        Task<(bool Success, string Message)> ForgetPasswordAsync(ForgetPasswordDTO forgetPasswordDTO);

        Task<(bool Success, string Message)> ResetPasswordAsync(ForgetPasswordDTO forgetPasswordDTO);

        Task<IdentityResult> RegisterUserWithGoogle(GoogleregisterDTO googleRegisterDTO);

        Task<AuthenticationResponseDTO> LoginWithGoogle(User user);


        public IEnumerable<ReadCourseDTO> GetInstructorCourses(int id);

        Task<(bool Success, string Message)> approve(int id);

        Task<IdentityResult> deleteuser(int id);

    }
}
