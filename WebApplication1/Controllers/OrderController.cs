using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public IRepository<Order> OrderRepo { get; set; }
        public OrderController(IRepository<Order> orderRepo)
        {
            OrderRepo = orderRepo;
        }
        [HttpGet]
        public ActionResult<List<Order>> getOrders()
        {

            return OrderRepo.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult<Order> getById(int id)
        {
            return OrderRepo.GetDetails(id);
        }

        [HttpDelete]
        public ActionResult delete(int id)
        {
            Order order= OrderRepo.GetDetails(id);

            if (order == null)
            {
                return NotFound();
            }
            OrderRepo.Delete(id);
            return Ok(order);
        }
        [HttpPut]
        public ActionResult put(int id, Order order)
        {
            Order? orderr = OrderRepo.GetDetails(id);
            if (id != order.Id)
            {
                //return StatusCode(400);
                return BadRequest();
            }
            if (orderr != null)
            {


                OrderRepo.UpdateBayza(id, orderr);
                return Ok(order);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult Post(Order order)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    OrderRepo.Insert(order);
                    return Created("url", order);
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
