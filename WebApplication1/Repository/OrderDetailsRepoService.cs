using WebApplication1.Data;
using WebApplication1.Models;
namespace WebApplication1.Repository
{
    public class OrderDetailsRepoService:IRepository<OrderDetails>
    {
        public ElDbContext Context { get; set; }

        public OrderDetailsRepoService(ElDbContext context)
        {
            Context = context;
        }

        public List<OrderDetails> GetAll()
        {
            return Context.OrderDetails.ToList();
        }

        public OrderDetails? GetDetails(int id)
        {
            return Context.OrderDetails.Find(id);
        }

        public void Insert(OrderDetails orderDetails)
        {
            Context.OrderDetails.Add(orderDetails);
            Context.SaveChanges();
        }

        public void UpdateBayza(int id, OrderDetails orderDetails)
        {
            OrderDetails orderDetailsUpdated = Context.OrderDetails.Find(id);
            orderDetailsUpdated.Order = orderDetails.Order;
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            Context.OrderDetails.Remove(Context.OrderDetails.Find(id));
            Context.SaveChanges();
        }

        public void Update(OrderDetails entity)
        {
            throw new NotImplementedException();
        }
    }
}
