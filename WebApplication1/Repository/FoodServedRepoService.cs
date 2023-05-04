using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class FoodServedRepoService: BaseRepoService, IRepository<FoodServed>
    {
        public FoodServedRepoService(IDbContextFactory<ElDbContext> context) : base(context)
        {
        }

        public List<FoodServed> GetAll()
        {
            List<FoodServed> foodServedList = new List<FoodServed>();

            using (var customContext = Context.CreateDbContext())
            {
                foodServedList = customContext.FoodServed.ToList();
            }

            using (var customContext = Context.CreateDbContext())
            {
                foreach (var foodServed in foodServedList)
                {
                    foodServed.Restaurant = customContext.Restaurants.First(r => r.Id == foodServed.RestaurantID);
                    foodServed.Category = customContext.Categories.First(c => c.Id == foodServed.CategoryID);
                }
            }

            return foodServedList;
        }

        public FoodServed? GetDetails(int id)
        {
            var FoodServedDetails = new FoodServed();
            using (var customContext = Context.CreateDbContext())
            {
                FoodServedDetails =  customContext.FoodServed.Find(id);
            }

            using (var customContext = Context.CreateDbContext())
            {
                FoodServedDetails.Restaurant = customContext.Restaurants.First(r => r.Id == FoodServedDetails.RestaurantID);
                FoodServedDetails.Category = customContext.Categories.First(r => r.Id == FoodServedDetails.CategoryID);
            }
            return (FoodServedDetails);

        }

        public void Insert(FoodServed foodServed)
        {
            using (var customContext = Context.CreateDbContext())
            {
                customContext.FoodServed.Add(foodServed);
                customContext.SaveChanges();
            }
           
        }

        public void UpdateBayza(int id, FoodServed t)
            //Not Used
        {
            using (var customContext = Context.CreateDbContext())
            {
                FoodServed foodUpdated = customContext.FoodServed.Find(id);
                foodUpdated.Name = t.Name;
                customContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var customContext = Context.CreateDbContext())
            {
                customContext.FoodServed.Remove(new FoodServed() { Id = id});
                // customContext.FoodServed.Remove(customContext.FoodServed.Find(id)); AnotherWay bad performence
                customContext.SaveChanges();
            }
          
        }

        public void Update(FoodServed foodServed)
        {
            using (var customContext = Context.CreateDbContext())
            {
                customContext.FoodServed.Update(foodServed);
                customContext.SaveChanges();
            }
        }
    }
}
