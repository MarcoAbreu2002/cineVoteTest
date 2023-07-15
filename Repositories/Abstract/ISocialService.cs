using cineVote.Models.Domain;
using cineVote.Models.DTO;
namespace cineVote.Repositories.Abstract
{
    public interface ISocialService
    {
        Task<List<Posts>> GetPostsAsync(string userName);
        Posts CreatePost(string userName, string title, string content);
        Comments CreateComment(string userName, int postId, string content);
    }
}