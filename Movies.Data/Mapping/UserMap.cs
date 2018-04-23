using Movies.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
