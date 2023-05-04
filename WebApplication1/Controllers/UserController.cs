using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IRepository<User> UserRepo { get; set; }
        public UserController(IRepository<User> userRepo)
        {
            UserRepo = userRepo;
        }
        [HttpGet]
        public ActionResult<List<User>> getUsers()
        {
            return UserRepo.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult<User> getById(int id)
        {
            return UserRepo.GetDetails(id);
        }

        [HttpDelete("{id}")]
        public ActionResult delete(int id)
        {
            UserRepo.Delete(id);

            if (id == 0)
            {
                return NotFound();
            }
            UserRepo.Delete(id);
            return Ok();
        }
        [HttpPut]
        public ActionResult put( User user)
        {
            if (user != null && user.Id != 0)
            {
                UserRepo.Update(user);
                return Ok(user);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult Post(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UserRepo.Insert(user);
                    return Created("url", user);
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