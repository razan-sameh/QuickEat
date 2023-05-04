using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Repository
{
    public class BaseRepoService
    {
        public IDbContextFactory<ElDbContext> Context { get; set; }

        public BaseRepoService(IDbContextFactory<ElDbContext> context)
        {
            Context = context;
        }
    }
}