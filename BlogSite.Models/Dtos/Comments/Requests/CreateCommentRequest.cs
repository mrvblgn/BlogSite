namespace BlogSite.Models.Dtos.Comments.Requests;

public sealed record CreateCommentRequest(string Text, string UserId, Guid PostId);