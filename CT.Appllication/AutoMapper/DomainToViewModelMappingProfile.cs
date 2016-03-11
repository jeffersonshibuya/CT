using AutoMapper;
using CT.Appllication.ViewModels;
using CT.Domain.Entities;

namespace CT.Appllication.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName {
            get { return "DomainToViewModelMappingProfile"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Cliente, ClienteViewModel>();
            Mapper.CreateMap<Entidades, EntidadesViewModel>();
            Mapper.CreateMap<EntProjetos, EntProjetosViewModel>();
            Mapper.CreateMap<EntLicencas, EntLicencasViewModel>();
        }
    }
}