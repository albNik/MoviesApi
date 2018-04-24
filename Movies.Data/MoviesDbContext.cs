using Movies.Data.Entities;
using Movies.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data
{
   public class MoviesDbContext : DbContext
   {

      public MoviesDbContext()
      {
         Database.SetInitializer(new DropCreateDatabaseAlways<MoviesDbContext>());
      }

      public DbSet<Movie> Movies { get; set; }
      public DbSet<User> Users { get; set; }
      public DbSet<Rating> Ratings { get; set; }
      public DbSet<Genre> Genres { get; set; }




      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {


         modelBuilder.Configurations.Add(new MovieMap());
         modelBuilder.Configurations.Add(new RatingMap());
         modelBuilder.Configurations.Add(new UserMap());
      }

   }
}
