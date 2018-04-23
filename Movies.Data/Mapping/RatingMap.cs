using Movies.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data.Mapping
{
  public class RatingMap : EntityTypeConfiguration<Rating>
   {
      public RatingMap()
      {
         this.ToTable("Ratings");
         this.HasKey(c => c.Id);

         this.HasRequired(x => x.Movie)
            .WithMany(x => x.Ratings)
            .HasForeignKey(x => x.MovieId);

         this.HasRequired(x => x.User)
           .WithMany(x => x.Ratings)
           .HasForeignKey(x => x.UserId);

      }
   }
}
