using MediatR;
using Posts.Replies.Likes.Application.Dtos;

namespace Posts.Replies.Likes.Application.Queries
{
    public class GetLikesQuery : IRequest<PaginatedListDto<LikeDto>>
    {
        public string ReplyId { get; }

        public int PageIndex { get; }

        public GetLikesQuery(string replyId, int pageIndex)
        {
            ReplyId = replyId;

            PageIndex = pageIndex < 1 ? 1 : pageIndex;
        }
    }
}