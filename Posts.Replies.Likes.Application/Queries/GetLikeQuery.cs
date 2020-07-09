using MediatR;
using Posts.Replies.Likes.Application.Dtos;

namespace Posts.Replies.Likes.Application.Queries
{
    public class GetLikeQuery : IRequest<LikeDto>
    {
        public string Id { get; }

        public GetLikeQuery(string id)
        {
            Id = id;
        }
    }
}