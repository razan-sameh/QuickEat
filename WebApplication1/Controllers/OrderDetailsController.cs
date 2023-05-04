using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        public IRepository<OrderDetails> OrderDetailsRepo { get; set; }
        public OrderDetailsController(IRepository<OrderDetails> orderDetailsRepo)
        {
            OrderDetailsRepo = orderDetailsRepo;
        }
        [HttpGet]
        public ActionResult<List<OrderDetails>> getOrderDetails()
        {

            return OrderDetailsRepo.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult<OrderDetails> getById(int id)
        {
            return OrderDetailsRepo.GetDetails(id);
        }

        [HttpDelete]
        public ActionResult delete(int id)
        {
            OrderDetails orderDetails = OrderDetailsRepo.GetDetails(id);

            if (orderDetails == null)
            {
                return NotFound();
            }
            OrderDetailsRepo.Delete(id);
            return Ok(orderDetails);
        }
        [HttpPut]
        public ActionResult put(int id, OrderDetails orderDetails)
        {
            OrderDetails? orderrDetails = OrderDetailsRepo.GetDetails(id);
            if (id != orderDetails.Id)
            {
                //return StatusCode(400);
                return BadRequest();
            }
            if (orderrDetails != null)
            {
                OrderDetailsRepo.UpdateBayza(id, orderrDetails);
                return Ok(orderDetails);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult Post(OrderDetails orderDetails)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    OrderDetailsRepo.Insert(orderDetails);
                    return Created("url", orderDetails);
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
