using E_Learning.BL.DTO.Category;
using E_Learning.BL.DTO.Course;
using E_Learning.BL.Dtos.Category;
using E_Learning.BL.Managers.CategoryManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning.APIs.Controllers
{
    //[Authorize]

       [AllowAnonymous]

    public class CategoryController :APIBaseController
    {
        /*------------------------------------------------------------------------*/
        private readonly ICategoryManager _categoryManager;
        /*------------------------------------------------------------------------*/
        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }
        /*------------------------------------------------------------------------*/
        [HttpGet]
        public ActionResult<IEnumerable<ReadCategoryDto>> GetAll()
        {
            string scheme = Request.Scheme;
            string host = Request.Host.Value;
            var categories = _categoryManager.GetAll(scheme, host);
            return Ok(categories);
        }
        /*------------------------------------------------------------------------*/
        [HttpGet("{id}")]
        public ActionResult<CategoryWithCoursesDTO> GetCoursesByCategoryId(int id)
        {
            var category = _categoryManager.GetCategoryWithCourses(id);
            if(category == null)
            {
                return NotFound(new { Message = "Category Courses Not Found" });
            }
            return Ok(category);
        }
        /*------------------------------------------------------------------------*/
        //[HttpPost]
        //public ActionResult CreateCategory([FromBody] CreateCategoryDto createCategoryDto)
        //{
        //    if(createCategoryDto != null)
        //    {
        //        _categoryManager.CreateCategory(createCategoryDto);
        //        return Ok(new { Message = "Category Creation Succeded" });
        //    }
        //    return BadRequest(ModelState);
        //}

        /*------------------------------------------------------------------------*/
        //[HttpPut]
        //public ActionResult<Category> UpdateCategory(int id,[FromBody] CreateCategoryDto createCategoryDto)
        //{
        //    if(createCategoryDto != null)
        //    {
        //        _categoryManager.UpdateCategory(id, createCategoryDto);
        //        return Ok();
        //    }
        //    return BadRequest(ModelState);
        //}

        /*------------------------------------------------------------------------*/
        //[HttpDelete]
        //public void DeleteCategory(int id)
        //{
        //    _categoryManager.DeleteCategory(id);
        //}

        [HttpPost]
        public ActionResult CreateCategory([FromForm] CreateCategoryDto createCategoryDto)
        {

            _categoryManager.CreateCategory(createCategoryDto);
            return Ok(new { Message = "Category Creation Succeded" });
            //}
            //return BadRequest(ModelState);
        }

        /*------------------------------------------------------------------------*/
        [HttpPut]
        public ActionResult UpdateCategory(int id, [FromForm] CreateCategoryDto createCategoryDto)
        {
            if (createCategoryDto != null)
            {
                _categoryManager.UpdateCategory(id, createCategoryDto);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        /*------------------------------------------------------------------------*/
        [HttpDelete("{id}")]
        public void DeleteCategory(int id)
        {
            _categoryManager.DeleteCategory(id);
        }
    }
}
