using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        public IRepository<Restaurant> RestaurantRepo { get; set; }
        public RestaurantController(IRepository<Restaurant> restaurantRepo)
        {
            RestaurantRepo = restaurantRepo;
        }
        [HttpGet]
        public ActionResult<List<Restaurant>> getRestaurants()
        {

            return RestaurantRepo.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult<Restaurant> getById(int id)
        {
            return RestaurantRepo.GetDetails(id);
        }

        [HttpDelete("{id}")]
        public ActionResult delete(int id)
        {
           Restaurant restaurant = RestaurantRepo.GetDetails(id);

            if (restaurant == null)
            {
                return NotFound();
            }
            RestaurantRepo.Delete(id);
            return Ok(restaurant);
        }
        [HttpPut]
        public ActionResult put(int id, Restaurant rstrnt)
        {
            if (rstrnt != null && rstrnt.Id != 0)
            {
                RestaurantRepo.Update(rstrnt);
                return Ok(rstrnt);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult Post(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    RestaurantRepo.Insert(restaurant);
                    return Created("url", restaurant);
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
