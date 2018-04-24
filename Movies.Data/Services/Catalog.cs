using Movies.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data.Services
{
   public class Catalog
   {
      public IEnumerable<object> GetMovies(string title = null, int? year = null, string genres = "")
      {
         using(MoviesDbContext dbContext = new MoviesDbContext())
         {
            if(string.IsNullOrEmpty(title) && string.IsNullOrEmpty(genres) && year == null)
            {
               throw new InvalidCriteriaException("Empty search filters");
            }

            var genresArr = genres.Split(',');

            return dbContext.Movies.Where(x => x.Title.Contains(title)
                                             || x.Year == year
                                             || x.Genres.Any(y => genresArr.Contains(y.Name)))
                                             .Select(x => new
                                             {
                                                x.Id,
                                                x.Title,
                                                x.Year,
                                                AverageRating = x.Ratings.Average(y => y.Value),
                                             })
                                            .ToList()
                                            .Select(x => new
                                            {
                                               x.Id,
                                               x.Title,
                                               x.Year,
                                               AverageRating = Math.Round(x.AverageRating * 2) / 2.0
                                            });

         }
      }

      public IEnumerable<object> GetMoviesTop5()
      {
         using(MoviesDbContext dbContext = new MoviesDbContext())
         {
            return dbContext.Movies
                     .Where(x => x.Ratings.Any())
                     .OrderByDescending(x => x.Ratings.Average(y => y.Value))
                     .ThenBy(x => x.Title)
                     .Take(5)
                     .Select(x => new
                     {
                        x.Id,
                        x.Title,
                        x.Year,
                        AverageRating = x.Ratings.Average(y => y.Value),
                     })
                     .ToList()
                     .Select(x => new
                     {
                        x.Id,
                        x.Title,
                        x.Year,
                        AverageRating = Math.Round(x.AverageRating * 2) / 2.0
                     });

         }

      }

      public IEnumerable<object> GetMoviesTop5forUser(int userId)
      {
         using(MoviesDbContext db = new MoviesDbContext())
         {
            var user = db.Users.FirstOrDefault(x => x.Id == userId);

            if(user == null)
               throw new InvalidCriteriaException("User id non existent");

            return user.Ratings
                     .OrderByDescending(x => x.Value)
                     .ThenBy(x => x.Movie.Title)
                     .Take(5)
                     .Select(x => new
                     {
                        x.Movie.Id,
                        x.Movie.Title,
                        x.Movie.Year,
                        UserRating = x.Value,
                     })
                     .ToList();

         }
      }

      public void SetRating(int movieId, int userId, int rating)
      {
         if(rating < 1 || rating > 5)
            throw new RatingOutOfRangeException();

         using(MoviesDbContext db = new MoviesDbContext())
         {
            var rat = db.Ratings.FirstOrDefault(x => x.MovieId == movieId && x.UserId == userId);
            if(rat != null)
            {
               rat.Value = rating;
               db.SaveChanges();

            }
            else if(db.Users.Any(x => x.Id == userId) && db.Movies.Any(x => x.Id == movieId))
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
               throw new InvalidCriteriaException("User or movie not Found");
            }
         }


      }

   }
}
