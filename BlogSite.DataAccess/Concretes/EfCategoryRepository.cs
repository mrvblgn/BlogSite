using BlogSite.DataAccess.Abstracts;
using BlogSite.DataAccess.Contexts;
using BlogSite.Models.Entites;
using Core.Repositories;

namespace BlogSite.DataAccess.Concretes;

public class EfCategoryRepository : EfRepositoryBase<BaseDbContext, Category, int>, ICategoryRepository
{
    public EfCategoryRepository(BaseDbContext context) : base(context)
    {
        
    }
}