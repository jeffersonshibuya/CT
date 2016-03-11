using System.ServiceModel.Channels;
using CT.Appllication.App;
using CT.Appllication.Interface;
using CT.Domain.Interfaces.Repositories;
using CT.Domain.Interfaces.Services;
using CT.Domain.Services;
using CT.Infra.Data.Context;
using CT.Infra.Data.Interfaces;
using CT.Infra.Data.Repository;
using CT.Infra.Data.UoW;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace CT.Infra.CrossCutting.IoC
{
    public class Container
    {
        public Container()
        {
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(GetModule()));
        }

        public UnityContainer GetModule()
        {
            return ConfigureUnityContainer();
        }

        public UnityContainer ConfigureUnityContainer()
        {
            var container = new UnityContainer();

            //APP
            container.RegisterType<ITesteAppService, TesteAppService>();
            container.RegisterType<IEntidadesAppService, EntidadesAppService>();
            container.RegisterType<IEntProjetosAppService, EntProjetosAppService>();
            container.RegisterType<IEntLicencasAppService, EntLicencasAppService>();
            container.RegisterType<IClienteAppService, ClienteAppService>();

            //Services            
            container.RegisterType(typeof(IServiceBase<>), typeof(ServiceBase<>));
            container.RegisterType<ITesteService, TesteService>();
            container.RegisterType<IEntidadesService, EntidadesService>();
            container.RegisterType<IEntProjetosService, EntProjetosService>();
            container.RegisterType<IEntLicencasService, EntLicencasService>();
            container.RegisterType<IClienteService, ClienteService>();

            //Data Repos
            container.RegisterType(typeof(IRepositoryBase<>), typeof(RepositoryBase<,>));
            container.RegisterType<ITesteRepository, TesteRepository>();
            container.RegisterType<IEntidadesRepository, EntidadesRepository>();
            container.RegisterType<IEntProjetosRepository, EntProjetosRepository>();
            container.RegisterType<IEntLicencasRepository, EntLicencasRepository>();
            container.RegisterType<IClienteRepository, ClienteRepository>();

            //DataConfig
            container.RegisterType(typeof(IContextManager<>), typeof(ContextManager<>));
            container.RegisterType<IDbContext, BarraFisikContext>();
            container.RegisterType(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

            return container;
        }


    }
}