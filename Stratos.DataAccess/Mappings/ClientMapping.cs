using Stratos.DomainModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Stratos.DataAccess.Mappings
{
    public class ClientMapping : EntityTypeConfiguration<Client>
    {
        public ClientMapping()
        {
            ToTable("Client");
            
            HasKey(c => c.Id);
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Name);
            Property(c => c.Email);
            Property(c => c.Phone);

            HasMany(c => c.Servers).WithRequired(s => s.Client).WillCascadeOnDelete(true);
        }
    }
}
