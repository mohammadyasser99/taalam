using E_Learning.BL.DTO.Course;
using E_Learning.BL.DTO.User;
using E_Learning.BL.DTO.WishList;
using E_Learning.DAL.Models;
using E_Learning.DAL.UnitOfWorkDP;


namespace E_Learning.BL.Managers.WishListManager
{
    public class WishListManager : IWishListManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public WishListManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<ReadCourseDTO> GetWishListItems(int userId)
        {
            return _unitOfWork.WishListRepository.GetWishListItemsByUserId(userId)
                .Select(c => new ReadCourseDTO
                {
                    Id = c.Course.Id,
                    Title = c.Course.Title,
                    Price = c.Course.Price,
                    CoverPicture = c.Course.CoverPicture,
                    InstructorName = c.Course.User.FName + ' ' + c.Course.User.LName

                });
        }
        public IEnumerable<ReadCourseDTO> RemoveItemFromWishList(int userId, int courseId)
        {
           var WishListItem= _unitOfWork.WishListRepository.GetWishListItem(userId, courseId);
            if (WishListItem is not null) 
            {
                _unitOfWork.WishListRepository.Delete(WishListItem);
                _unitOfWork.SaveChanges();
            }
            return GetWishListItems(userId);
        }

        public bool AddToWishList(AddToWishListDTO cartItemDto)
        {
            if (!_unitOfWork.EnrollmentRepository.IsStudentEnrolled(cartItemDto.UserId, cartItemDto.CourseId))
            {
                var newWishListItem = new WishList
                {
                    UserId = cartItemDto.UserId,
                    CourseId = cartItemDto.CourseId
                };


                _unitOfWork.WishListRepository.Create(newWishListItem);
                _unitOfWork.SaveChanges();
                return true;
            }
            else return false;

        }

        public bool WishListItemExists(AddToWishListDTO wishListDTO)
        {
            return _unitOfWork.WishListRepository.WishListITemExists(wishListDTO.UserId, wishListDTO.CourseId);
        }

    }
}
