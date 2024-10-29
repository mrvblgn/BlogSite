using BlogSite.Models.Entites;
using Core.Repositories;

namespace BlogSite.DataAccess.Abstracts;

public interface IPostRepository : IRepository<Post, Guid>
{
    
}