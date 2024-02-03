using AutoMapper;
using MED.Application.ViewModel;
using MED.Domain.Entities;


namespace MED.Api.Config
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Contato, ContatoViewModel>().ReverseMap();
        }
    }
}
