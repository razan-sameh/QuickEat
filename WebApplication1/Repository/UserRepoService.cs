using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using WebApplication1.Data;
using WebApplication1.Models;
namespace WebApplication1.Repository
{
    public class UserRepoService:BaseRepoService,IRepository<User>
    {
       

        public UserRepoService(IDbContextFactory<ElDbContext> context) :base (context)
        {
           
        }

        public List<User> GetAll()
        {
            List<User> UsersList = new List<User>();

            using (var customContext = Context.CreateDbContext())
            {
                UsersList = customContext.Users.ToList();
            }
            return UsersList;
        }

        public User? GetDetails(int id)
        {
            using (var customContext = Context.CreateDbContext())
            {
                return customContext.Users.Find(id);
            }
        }

        public void Insert(User user)
        {
            using (var customContext = Context.CreateDbContext())
            {
                customContext.Users.Add(user);
                customContext.SaveChanges();
            }
        }

        public void UpdateBayza(int id, User user)
        {
            using (var CustomContext = Context.CreateDbContext())
            {
                User userUpdated = CustomContext.Users.Find(id);
                userUpdated.UserName = user.UserName;
                CustomContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var CustomContext = Context.CreateDbContext())
            {
                CustomContext.Users.Remove(CustomContext.Users.Find(id));
                CustomContext.SaveChanges();
            }
        }

        public void Update(User user)
        {
            using (var customContext = Context.CreateDbContext())
            {
                customContext.Users.Update(user);
                customContext.SaveChanges();
            }
        }
    }
}
