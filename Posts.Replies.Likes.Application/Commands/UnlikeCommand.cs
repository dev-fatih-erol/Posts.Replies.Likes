using MediatR;

namespace Posts.Replies.Likes.Application.Commands
{
    public class UnlikeCommand : IRequest<Unit>
    {
        public int UserId { get; }

        public string ReplyId { get; }

        public UnlikeCommand(int userId, string replyId)
        {
            UserId = userId;

            ReplyId = replyId;
        }
    }
}