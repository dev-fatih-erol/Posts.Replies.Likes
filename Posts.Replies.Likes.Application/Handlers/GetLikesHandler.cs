using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MongoDB.Driver.Linq;
using Posts.Replies.Likes.Application.Dtos;
using Posts.Replies.Likes.Application.Helpers;
using Posts.Replies.Likes.Application.Queries;
using Posts.Replies.Likes.Infrastructure.Entities;
using Posts.Replies.Likes.Infrastructure.Services;

namespace Posts.Replies.Likes.Application.Handlers
{
    public class GetLikesHandler : IRequestHandler<GetLikesQuery, PaginatedListDto<LikeDto>>
    {
        private readonly IMapper _mapper;

        private readonly ILikeService _likeService;

        public GetLikesHandler(IMapper mapper, ILikeService likeService)
        {
            _mapper = mapper;

            _likeService = likeService;
        }

        public async Task<PaginatedListDto<LikeDto>> Handle(GetLikesQuery request, CancellationToken cancellationToken)
        {
            var query = _likeService.GetLikes(request.ReplyId);
            var likes = from l in query
                        orderby l.CreatedDate
                        select l;

            var pageSize = 5;
            var paginatedLikes = await PaginatedList<Like>.CreateAsync(likes, request.PageIndex, pageSize);

            var response = _mapper.Map<PaginatedListDto<LikeDto>>(paginatedLikes);

            return response;
        }
    }
}