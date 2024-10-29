using BlogSite.DataAccess.Abstracts;
using BlogSite.DataAccess.Contexts;
using BlogSite.Models.Entites;
using Core.Repositories;

namespace BlogSite.DataAccess.Concretes;

public class EfPostRepository : EfRepositoryBase<BaseDbContext, Post, Guid>, IPostRepository
{
    public EfPostRepository(BaseDbContext context) : base(context)
    {
        
    }

    public List<Post> GetAllByAuthorId(string id)
    {
        return Context.Posts.Where(p => p.AuthorId == id).ToList();
    }
}