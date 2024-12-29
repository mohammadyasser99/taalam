using E_Learning.BL.DTO.Cart;
using E_Learning.BL.DTO.Course;
using E_Learning.BL.DTO.WishList;

namespace E_Learning.BL.Managers.WishListManager
{
    public interface IWishListManager
    {
        IEnumerable<ReadCourseDTO> GetWishListItems(int userId);
        IEnumerable<ReadCourseDTO>  RemoveItemFromWishList(int userId, int courseId);

        public bool WishListItemExists(AddToWishListDTO wishListDTO);
            
        public bool AddToWishList(AddToWishListDTO cartItemDto);


    }
}
