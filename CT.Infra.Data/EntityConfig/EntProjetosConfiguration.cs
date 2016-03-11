using System.Data.Entity.ModelConfiguration;
using CT.Domain.Entities;

namespace CT.Infra.Data.EntityConfig
{
    public class EntProjetosConfiguration : EntityTypeConfiguration<EntProjetos>
    {
        public EntProjetosConfiguration()
        {
            ToTable("ENTIDADES_PROJETOS");

            HasKey(e => e.EP_ID);
        }
    }
}