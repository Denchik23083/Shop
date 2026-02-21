namespace Shop.Services.GodService
{
    public interface IGodService
    {
        Task<bool> UserToAdminAsync(int userId);

        Task<bool> AdminToUserAsync(int adminId);
    }
}