using Movies.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Movies.Data.Mapping
{
   public class UserMap : EntityTypeConfiguration<User>
   {
      public UserMap()
      {
         this.ToTable("Users");

         this.HasKey(c => c.Id);

         this.Property(x => x.Name).IsRequired().HasMaxLength(50);

      }
   }
}
