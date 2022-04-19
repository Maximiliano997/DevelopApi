using AutoMapper;
using Posting.Core.Dtos;
using Posting.Core.Entities;

namespace Posting.Infrastructure.Mappers
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();
        }
    }
}
