using Movies.Data.Entities;
using System.Data.Entity.ModelConfiguration;

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
