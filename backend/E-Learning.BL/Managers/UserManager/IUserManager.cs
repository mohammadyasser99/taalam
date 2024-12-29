using E_Learning.BL.DTO.User;
namespace E_Learning.BL.Managers.CategoryManager
{
    public interface IUserManager
    {
        InstructorDTO GetInstructorInfo(int id);
        Task<bool> EditUserProfile(EditUserProfileDTO editUserProfileDTO, string scheme, string host);
    }
}
