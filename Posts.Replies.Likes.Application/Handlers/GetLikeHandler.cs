using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Posts.Replies.Likes.Application.Dtos;
using Posts.Replies.Likes.Application.Exceptions;
using Posts.Replies.Likes.Application.Queries;
using Posts.Replies.Likes.Infrastructure.Entities;
using Posts.Replies.Likes.Infrastructure.Services;

namespace Posts.Replies.Likes.Application.Handlers
{
    public class GetLikeHandler : IRequestHandler<GetLikeQuery, LikeDto>
    {
        private readonly IMapper _mapper;

        private readonly ILikeService _likeService;

        public GetLikeHandler(IMapper mapper, ILikeService likeService)
        {
            _mapper = mapper;

            _likeService = likeService;
        }

        public async Task<LikeDto> Handle(GetLikeQuery request, CancellationToken cancellationToken)
        {
            var like = await _likeService.GetLike(request.Id);

            if (like == null)
            {
                throw new NotFoundException(nameof(Like));
            }

            var response = _mapper.Map<LikeDto>(like);

            return response;
        }
    }
}