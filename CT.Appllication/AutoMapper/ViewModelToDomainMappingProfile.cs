using AutoMapper;
using CT.Appllication.ViewModels;
using CT.Domain.Entities;

namespace CT.Appllication.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName {
            get { return "ViewModelToDomainMappingProfile"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ClienteViewModel, Cliente>();
            Mapper.CreateMap<EntidadesViewModel, Entidades>();
            Mapper.CreateMap<EntProjetosViewModel, EntProjetos>();
            Mapper.CreateMap<EntLicencasViewModel, EntLicencas>();
        }
    }
}