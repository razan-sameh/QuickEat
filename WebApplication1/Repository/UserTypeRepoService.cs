using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
namespace WebApplication1.Repository
{
    public class UserTypeRepoService: BaseRepoService,IRepository<UserType>
    {
        

        public UserTypeRepoService(IDbContextFactory<ElDbContext> context):base(context)
        {
          
        }

        public List<UserType> GetAll()
        {
            //return Context.UserTypes.ToList();
            List<UserType> UserTypeList = new List<UserType>();

            using (var customContext = Context.CreateDbContext())
            {
                UserTypeList = customContext.UserTypes.ToList();
            }
            return UserTypeList;
        }

        public UserType? GetDetails(int id)
        {
            //return Context.UserTypes.Find(id);
            var UserTypeDetails = new UserType();
            using (var customContext = Context.CreateDbContext())
            {
                UserTypeDetails = customContext.UserTypes.Find(id);
            }
            return (UserTypeDetails);

        }

        public void Insert(UserType userType)
        {
            using (var customContext = Context.CreateDbContext())
            {
                customContext.UserTypes.Add(userType);
                customContext.SaveChanges();
            }
        }

        public void UpdateBayza(int id, UserType userType)
        {
            using (var customContext = Context.CreateDbContext())
            {
                UserType userTypeUpdated = customContext.UserTypes.Find(id);
                userTypeUpdated.Name = userType.Name;
                customContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var customContext = Context.CreateDbContext())
            {
                customContext.UserTypes.Remove(customContext.UserTypes.Find(id));
                customContext.SaveChanges();
            }
        }

        public void Update(UserType userType)
        {
            using (var customContext = Context.CreateDbContext())
            {
                customContext.UserTypes.Update(userType);
                customContext.SaveChanges();
            }
        }
    }
}
