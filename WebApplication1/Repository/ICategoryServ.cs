using WebApplication1.Models;

namespace WebApplication1.Repository
{
    //Custom Category Repo
    public interface ICategoryServ : IRepository<Category>
    {
        //SelectList GetCategoriesDropDownList();
    }
}