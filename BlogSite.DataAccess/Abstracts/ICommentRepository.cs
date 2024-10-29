using BlogSite.Models.Entites;
using Core.Repositories;

namespace BlogSite.DataAccess.Abstracts;

public interface ICommentRepository : IRepository<Comment, Guid>
{
    
}