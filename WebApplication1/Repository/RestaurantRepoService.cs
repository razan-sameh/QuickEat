using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Repository
{
    public class RestaurantRepoService :BaseRepoService, IRepository<Restaurant>
    {
   
        public RestaurantRepoService(IDbContextFactory <ElDbContext> context) :base(context)
        {
        

        }

        public List<Restaurant> GetAll()
        {
            List<Restaurant> RestaurantsList = new List<Restaurant>();
            //return Context.Categories.ToList();
            using (var customContext = Context.CreateDbContext())
            {
                RestaurantsList = customContext.Restaurants.ToList();
            }

            return RestaurantsList;
        }

        public Restaurant? GetDetails(int id)
        {
            var RestaurantDetails = new Restaurant();
            using (var customContext = Context.CreateDbContext())
            {
                RestaurantDetails = customContext.Restaurants.Find(id);
            }
            using (var customContext = Context.CreateDbContext())
            {
                RestaurantDetails.FoodServeds = customContext.FoodServed.Where(f => f.RestaurantID == id).ToList();
            }

            return RestaurantDetails;
        }

        public void Insert(Restaurant restaurant)
        {
            using (var customContext = Context.CreateDbContext())
            {
                customContext.Restaurants.Add(restaurant);
                customContext.SaveChanges();
            }
        }

        public void UpdateBayza(int id, Restaurant restaurant)
        { //NotUsed
            using (var CustomContext = Context.CreateDbContext())
            {
                Restaurant RestaurantUpdated = CustomContext.Restaurants.Find(id);
                RestaurantUpdated.Name = restaurant.Name;
                CustomContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var customContext = Context.CreateDbContext())
            {
                customContext.Restaurants.Remove(customContext.Restaurants.Find(id));
                customContext.SaveChanges();
            }
        }

        public void Update(Restaurant restaurant)
        {
            using (var customContext = Context.CreateDbContext())
            {
                customContext.Restaurants.Update(restaurant);
                customContext.SaveChanges();
            }
        }
    }
}
