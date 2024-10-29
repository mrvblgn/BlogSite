namespace BlogSite.Models.Dtos.Users.Requests;

public record ChangePasswordRequestDto(string CurrentPassword, string NewPassword, string ConfirmPassword);