using Movies.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data
{
   class Catalog
   {
      public IEnumerable<Movie> GetMovies(string title = null, int? year = null, string genres = "")
      {
         using(MoviesDbContext dbContext = new MoviesDbContext())
         {
            if(string.IsNullOrEmpty(title) && string.IsNullOrEmpty(genres) && year == null)
            {
               throw new Exception("Bad Data");
            }

            var genresArr = genres.Split(',');

            //   var t = dbContext.Movies.Where(x => x.Title.Contains(title) || x.Year == year || genres.Contains(x.Genres.Select(y => y.Name));




            //    Console.WriteLine(t);

         }

         return null;
      }


      public IEnumerable<Movie> GetMoviesTop5()
      {
         using(MoviesDbContext dbContext = new MoviesDbContext())
         {
            return dbContext.Movies.OrderByDescending(x => x.Ratings.Sum(y => y.Value)).Take(5).ToList();
         }

      }

      public IEnumerable<Movie> GetMoviesTop5forUser(int userId)
      {
         using(MoviesDbContext db = new MoviesDbContext())
         {
            return db.Movies.OrderByDescending(x => x.Ratings.Where(y => y.UserId == userId).Sum(y => y.Value)).Take(5).ToList();
         }

      }


      public void SetRating(int movieId, int userId, double rating)
      {
         if(rating < 1 || rating > 5)
            throw new ArgumentOutOfRangeException("rating");

         using(MoviesDbContext db = new MoviesDbContext())
         {
            var rat = db.Ratings.FirstOrDefault(x => x.MovieId == movieId && x.UserId == userId);
            if(rat != null)
            {
               rat.Value = rating;
               db.SaveChanges();

            }
            else if (db.Users.Any(x=>x.Id==userId) && db.Movies.Any(x => x.Id == movieId))
            {
               db.Ratings.Add(new Rating
               {
                  MovieId = movieId,
                  UserId = userId,
                  Value = rating,
               });
               db.SaveChanges();
            }
            else
            {
               throw new Exception("User or movie not Found");
            }
         }


      }

   }
}
