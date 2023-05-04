using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public ICategoryServ CategoryRepo { get; set; }
        public CategoryController(ICategoryServ categoryRepo)
        {
            CategoryRepo = categoryRepo;
        }
        [HttpGet]
        public ActionResult <List<Category>> getCategories()
        {
            return CategoryRepo.GetAll();
        }

        //[HttpGet]
        //public ActionResult<List<Category>> GetCategoriesDropDownList()
        //{
        //    return CategoryRepo.GetAll();
        //}

        [HttpGet("{id}")]
        public ActionResult<Category> getById(int id)
        { 
            return CategoryRepo.GetDetails(id);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(int id)
        {
            //Category category = CategoryRepo.GetDetails(id);

            //if (category == null)
            //{
            //    return NotFound();
            //}
            CategoryRepo.Delete(id);
            return Ok();
        }

        [HttpPut]
        public ActionResult Put (Category category)
        {
            if (category != null && category.Id != 0)
            {
                CategoryRepo.Update(category);
                return Ok(category);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult Post(Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CategoryRepo.Insert(category);
                    return Created("url", category);
                    // return 201 & Url is the place where you added the object
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message); // Return 400!
                }
            }
            return BadRequest();
        }
    }
}