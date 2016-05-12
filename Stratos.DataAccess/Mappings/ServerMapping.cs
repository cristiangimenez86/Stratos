using Stratos.DomainModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Stratos.DataAccess.Mappings
{
    public class ServerMapping : EntityTypeConfiguration<Server>
    {
        public ServerMapping()
        {
            ToTable("Server");
            
            HasKey(s => s.Id);
            Property(s => s.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(s => s.URL);
            Property(s => s.Username);
            Property(s => s.Password);

            HasRequired(s => s.Client).WithMany(c => c.Servers).HasForeignKey(s => s.ClientId);
        }
    }
}
