using System.Threading.Tasks;
using MongoDB.Driver.Linq;
using Posts.Replies.Likes.Infrastructure.Entities;

namespace Posts.Replies.Likes.Infrastructure.Services
{
    public interface ILikeService
    {
        IMongoQueryable<Like> GetLikes(string replyId);

        Task<Like> GetLike(string id);

        Task<Like> Unlike(int userId, string replyId);

        Task<Like> Like(Like like);
    }
}