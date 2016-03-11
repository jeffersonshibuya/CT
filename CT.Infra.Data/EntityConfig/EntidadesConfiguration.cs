using System.Data.Entity.ModelConfiguration;
using CT.Domain.Entities;

namespace CT.Infra.Data.EntityConfig
{
    public class EntidadesConfiguration : EntityTypeConfiguration<Entidades>
    {
        public EntidadesConfiguration()
        {
            ToTable("ENTIDADES");

            HasKey(e => e.ENT_COD);
        }
    }
}