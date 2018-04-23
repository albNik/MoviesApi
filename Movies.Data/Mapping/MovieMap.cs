using Movies.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Movies.Data.Mapping
{
   public class MovieMap : EntityTypeConfiguration<Movie>
   {

      public MovieMap()
      {
         this.ToTable("Movies");
         this.HasKey(c => c.Id);

         this.Property(x => x.Title).IsRequired().HasMaxLength(200);

         this.HasMany(x => x.Genres)
            .WithMany(x => x.Movies)
            .Map(x => x.ToTable("MoviesGenres"));
      }
   }
}
