using BlogSite.Models.Entites;
using Core.Repositories;

namespace BlogSite.DataAccess.Abstracts;

public interface ICategoryRepository : IRepository<Category, int>
{
    
}