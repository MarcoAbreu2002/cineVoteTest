using cineVote.Models.Domain;
using cineVote.Models.DTO;
namespace cineVote.Repositories.Abstract
{
    public interface IUserService
    {
        Task<Status> getProfile(int userId);
        Task<User> FindByUsernameAsync(string username);
        Task<Status>  Subscribe (string username, int competitionId);
        Task<Status> Vote (string username, int competitionId, int categoryId, int nomineeId, int subscriptionId);
        bool EditProfile(User user);
    }
}