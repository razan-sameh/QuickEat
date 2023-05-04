using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class OrderRepoService: IRepository<Order>
    {
        public ElDbContext Context { get; set; }

        public OrderRepoService(ElDbContext context)
        {
            Context = context;
        }

        public List<Order> GetAll()
        {
            return Context.Orders.ToList();
        }

        public Order? GetDetails(int id)
        {
            return Context.Orders.Find(id);
        }

        public void Insert(Order order)
        {
            Context.Orders.Add(order);
            Context.SaveChanges();
        }

        public void UpdateBayza(int id, Order order)
        {
            Order orderUpdated = Context.Orders.Find(id);
            orderUpdated.Name = order.Name;
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            Context.Orders.Remove(Context.Orders.Find(id));
            Context.SaveChanges();
        }

        public void Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
