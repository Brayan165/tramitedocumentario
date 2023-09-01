using AutoMapper;
using BDTramiteDocumentarioModel;
using RequestResponseModel;

namespace UtilAutomapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {

            CreateMap<Cargo, CargoRequest>().ReverseMap();
            CreateMap<Cargo, CargoResponse>().ReverseMap();
            CreateMap<CargoRequest, CargoResponse>().ReverseMap();

            CreateMap<Usuario, UsuarioRequest>().ReverseMap();
            CreateMap<Usuario, UsuarioResponse>().ReverseMap();
            CreateMap<UsuarioRequest, UsuarioResponse>().ReverseMap();


        }
    }
}