using AutoMapper;
using CompetencePlatform.Application.Models.Behaviour;
using CompetencePlatform.Core.DataTable;
using CompetencePlatform.Core.Entities;
using CompetencePlatform.Core.Utils;

namespace CompetencePlatform.Application.MappingProfiles
{
    public class DataTablePaginProfile : Profile
    {
        public DataTablePaginProfile()
        {
            CreateMap<PageResult<Behavior>, DataTablePagin<BehaviorViewModel>>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(orig => orig.Result))
                .ForMember(dest => dest.RecordsTotal, opt => opt.MapFrom(orig => orig.Total))
                .ForMember(dest => dest.RecordsFiltered, opt => opt.MapFrom(orig => orig.TotalFilter))
                .ReverseMap();

          



        }
    }
}
