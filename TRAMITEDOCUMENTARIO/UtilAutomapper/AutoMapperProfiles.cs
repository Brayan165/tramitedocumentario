using AutoMapper;
using BDTramiteDocumentarioModel;
using RequestResponseModel;

namespace UtilAutomapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //CreateMap<CargoRequest, Cargo>();
            //CreateMap<Cargo, CargoRequest>();
            CreateMap<Cargo, CargoRequest>().ReverseMap();
            CreateMap<Cargo, CargoResponse>().ReverseMap();
            CreateMap<CargoRequest, CargoResponse>().ReverseMap();
        }
    }
}