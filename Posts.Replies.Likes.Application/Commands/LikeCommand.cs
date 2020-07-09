using MediatR;
using Posts.Replies.Likes.Application.Dtos;

namespace Posts.Replies.Likes.Application.Commands
{
    public class LikeCommand : IRequest<LikeDto>
    {
        public UserDto User { get; }

        public string ReplyId { get; }

        public LikeCommand(UserDto user, string replyId)
        {
            User = user;

            ReplyId = replyId;
        }
    }
}