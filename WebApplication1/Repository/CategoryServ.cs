using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class CategoryServ : BaseRepoService, ICategoryServ
    {
        public CategoryServ(IDbContextFactory<ElDbContext> context) : base(context)
        {
        }

        public List<Category> GetAll()    

        {
            List<Category> CategoriesList = new List<Category>();
           
            using (var customContext = Context.CreateDbContext())
            {
                CategoriesList = customContext.Categories.ToList();
            }
            return CategoriesList;
            //return Context.Categories.ToList();

        }

        public Category GetDetails(int id)
        {
            using (var customContext = Context.CreateDbContext())
            {
                return customContext.Categories.Find(id);
            }
            //return Context.Categories.Find(id);

        }
        public void Insert(Category category)
        {
            using (var customContext = Context.CreateDbContext())
            {
                customContext.Categories.Add(category);
                customContext.SaveChanges();
            }

        }

        public void UpdateBayza(int id, Category category)
        {

            
            using (var CustomContext = Context.CreateDbContext())
            {
                Category CategoryUpdated = CustomContext.Categories.Find(id);
                CategoryUpdated.Name = category.Name;
                CustomContext.SaveChanges();
            }

        }

        public void Update(Category category)
        {
           
            using (var customContext = Context.CreateDbContext())
            {
                customContext.Categories.Update(category);
                customContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
           
            using(var customContext = Context.CreateDbContext())
            {
                customContext.Categories.Remove(customContext.Categories.Find(id));
                customContext.SaveChanges();
            }
        }

        //public SelectList GetCategoriesDropDownList()
        //{
        //    using (var customContext = Context.CreateDbContext())
        //    {
        //        SelectList CategoriesList = new SelectList(customContext.Categories.ToList(), "Name", "Id");
        //        return CategoriesList;
        //    }
        //}
    }
}