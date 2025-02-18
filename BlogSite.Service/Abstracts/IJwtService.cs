using BlogSite.Models.Dtos.Tokens.Responses;
using BlogSite.Models.Entites;

namespace BlogSite.Service.Abstracts;

public interface IJwtService
{
    TokenResponseDto CreateJwtToken(User user);
}