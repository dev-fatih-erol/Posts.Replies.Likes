namespace Posts.Replies.Likes.Infrastructure.Configurations
{
    public interface IMongoConfiguration
    {
        string ConnectionString { get; set; }
    }
}