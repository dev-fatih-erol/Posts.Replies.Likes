using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Posts.Replies.Likes.Infrastructure.Entities;

namespace Posts.Replies.Likes.Infrastructure.Services
{
    public class LikeService : ILikeService
    {
        private readonly LikeDbContext _dbContext;

        public LikeService(LikeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IMongoQueryable<Like> GetLikes(string replyId)
        {
            return _dbContext.Likes.AsQueryable().Where(l => l.ReplyId == replyId);
        }

        public async Task<Like> GetLike(string id)
        {
            return await _dbContext.Likes.Find(l => l.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Like> Unlike(int userId, string replyId)
        {
            return await _dbContext.Likes.FindOneAndDeleteAsync(l => l.User.Id == userId && l.ReplyId == replyId);
        }

        public async Task<Like> Like(Like like)
        {
            return await _dbContext.Likes.FindOneAndReplaceAsync(
                Builders<Like>.Filter.Eq(l => l.User.Id, like.User.Id) &
                Builders<Like>.Filter.Eq(l => l.ReplyId, like.ReplyId),
                like,
                new FindOneAndReplaceOptions<Like>
                {
                    IsUpsert = true,
                    ReturnDocument = ReturnDocument.After
                });
        }
    }
}