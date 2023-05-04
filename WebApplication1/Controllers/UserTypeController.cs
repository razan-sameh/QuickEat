using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        public IRepository<UserType> UserTypeRepo { get; set; }
        public UserTypeController(IRepository<UserType> userTypeRepo)
        {
            UserTypeRepo = userTypeRepo;
        }
        [HttpGet]
        public ActionResult<List<UserType>> getUserTypes()
        {

            return UserTypeRepo.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult<UserType> getById(int id)
        {
            return UserTypeRepo.GetDetails(id);
        }

        [HttpDelete("{id}")]
        public ActionResult delete(int id)
        {
           UserType userType = UserTypeRepo.GetDetails(id);

            if (userType == null)
            {
                return NotFound();
            }
            UserTypeRepo.Delete(id);
            return Ok(userType);
        }
        [HttpPut]
        public ActionResult put( UserType userType)
        {

            if (userType != null && userType.Id != 0)
            {
                UserTypeRepo.Update(userType);
                return Ok(userType);
            }
            return NotFound();

         
        }

        [HttpPost]
        public ActionResult Post(UserType userType)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   UserTypeRepo.Insert(userType);
                    return Created("url", userType);
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
