using System.Data.Entity.ModelConfiguration;
using CT.Domain.Entities;

namespace CT.Infra.Data.EntityConfig
{
    public class EntLicencasConfiguration : EntityTypeConfiguration<EntLicencas>
    {
        public EntLicencasConfiguration()
        {
            ToTable("ENTIDADES_LICENCAS");

            HasKey(e => e.LICENCIADO);
        }
    }
}