using System.Data.Entity.ModelConfiguration;
using CT.Domain.Entities;

namespace CT.Infra.Data.EntityConfig
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            ToTable("CLIENTE");

            HasKey(e => e.ID);
        }
    }
}