using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Posts.Replies.Likes.Application.Commands;
using Posts.Replies.Likes.Infrastructure.Services;

namespace Posts.Replies.Likes.Application.Handlers
{
    public class UnlikeHandler : IRequestHandler<UnlikeCommand, Unit>
    {
        private readonly ILikeService _likeService;

        public UnlikeHandler(ILikeService likeService)
        {
            _likeService = likeService;
        }

        public async Task<Unit> Handle(UnlikeCommand request, CancellationToken cancellationToken)
        {
            await _likeService.Unlike(request.UserId, request.ReplyId);

            return Unit.Value;
        }
    }
}