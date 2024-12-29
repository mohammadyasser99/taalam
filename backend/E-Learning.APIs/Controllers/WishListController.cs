using E_Learning.BL.DTO.Cart;
using E_Learning.BL.DTO.User;
using E_Learning.BL.DTO.WishList;
using E_Learning.BL.Managers.CartManager;
using E_Learning.BL.Managers.WishListManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Learning.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class WishListController : APIBaseController
    {
        private readonly IWishListManager _wishListManager;

        public WishListController(IWishListManager wishListManager)
        {
            _wishListManager = wishListManager;
        }

        [HttpGet("GetWishListItems")]

        public ActionResult<IEnumerable<CourseDTO>> GetWishListItems(int userId)
        {
            var wishListItems = _wishListManager.GetWishListItems(userId);
            return Ok(wishListItems);
        }

        [HttpDelete("RemoveWishListItem")]

        public ActionResult<IEnumerable<CourseDTO>> DeleteWishListItems(int userId,int courseId)
        {
           var wishListItems= _wishListManager.RemoveItemFromWishList(userId, courseId);
            return Ok(wishListItems);
        }

        [HttpPost("AddItemToUserWishList")]
        public IActionResult AddCartItem([FromBody] AddToWishListDTO wishListItemDto)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out var userId))
            {
                return Unauthorized();
            }

            wishListItemDto.UserId = userId;

            if (_wishListManager.WishListItemExists(wishListItemDto))
            {
                return BadRequest(new {message= "item is already in wish list"});
            }

            try
            {
                var addedToWishList = _wishListManager.AddToWishList(wishListItemDto);
                if (addedToWishList == false)
                {
                    return BadRequest(new { message= "course is already in wish list" });

                }
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(new { message = "course added to wishlist" });
        }
    }
}
