using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FoosballWebsite.Models;

namespace FoosballWebsite.Core.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Match, MatchViewModel>()
                .ForMember(vm => vm.Type, map => map.MapFrom(m => m.Type.ToString()))
                .ForMember(vm => vm.Feeds, map => map.MapFrom(m => 
                    Mapper.Map<ICollection<Feed>, ICollection<FeedViewModel>>(m.Feeds.OrderByDescending(f => f.Id).ToList())));
            Mapper.CreateMap<Feed, FeedViewModel>();
        }
    }
}
