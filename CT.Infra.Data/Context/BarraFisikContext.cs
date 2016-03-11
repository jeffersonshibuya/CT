using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CT.Domain.Entities;
using CT.Infra.Data.EntityConfig;

namespace CT.Infra.Data.Context
{
    public class BarraFisikContext : BaseContext
    {
        public BarraFisikContext() : base("BarraFisikConnectionString")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public IDbSet<Entidades> Entidades { get; set; }
        public IDbSet<EntProjetos> EntProjetos { get; set; }
        public IDbSet<EntLicencas> EntLicencas { get; set; }
        public IDbSet<Cliente> Cliente { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Conventions
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //General Custom Properties
            modelBuilder.Properties().Where(p => p.ReflectedType != null && p.Name == p.ReflectedType + "Id").Configure(p => p.IsKey());
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            //Model Configuration
            modelBuilder.Configurations.Add(new EntidadesConfiguration());
            modelBuilder.Configurations.Add(new EntProjetosConfiguration());
            modelBuilder.Configurations.Add(new EntLicencasConfiguration());
            modelBuilder.Configurations.Add(new ClienteConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}