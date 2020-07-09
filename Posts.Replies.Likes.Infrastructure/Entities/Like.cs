using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Posts.Replies.Likes.Infrastructure.Entities
{
    public class Like
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public User User { get; set; }

        public DateTime CreatedDate { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string ReplyId { get; set; }
    }
}