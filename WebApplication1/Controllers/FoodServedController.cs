using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FoodServedController : ControllerBase
    {
        public IRepository<FoodServed> FoodRepo { get; set; }
        public FoodServedController(IRepository<FoodServed> foodRepo)
        {
            FoodRepo = foodRepo;
        }
        [HttpGet]
        public ActionResult<List<FoodServed>> getFoodServed()
        {
            var listOfFoodServed = FoodRepo.GetAll();

            if(listOfFoodServed!=null && listOfFoodServed.Count()>0)
            {
                return Ok(listOfFoodServed);
            }
            return Ok(listOfFoodServed);
        }
        [HttpGet("{id}")]
        public ActionResult<FoodServed> getById(int id)
        {
            return FoodRepo.GetDetails(id);
        }

        [HttpDelete("{id}")]
        public ActionResult delete(int id)
        {
            //FoodServed foodServed = FoodRepo.GetDetails(id);

            //if (foodServed == null)
            //{
            //    return NotFound();
            //}
            FoodRepo.Delete(id);
            //return Ok(foodServed); 
            return Ok();
        }
        [HttpPut]
        public ActionResult put(FoodServed foodServed)
        {
            if (foodServed != null && foodServed.Id != 0)
            {
                FoodRepo.Update(foodServed);

                return Ok(foodServed);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult Post([FromBody] FoodServed foodServed)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    FoodRepo.Insert(foodServed);
                    return Created("url", foodServed);
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