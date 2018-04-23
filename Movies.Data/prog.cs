using Movies.Data.Entities;
using Movies.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data
{
   class Program
   {
      static void Main(string[] args)
      {

         Catalog cc = new Catalog();
         var v = cc.GetMoviesTop5();




         using(MoviesDbContext dbContext = new MoviesDbContext())
         {
            var users = new User[]
            {
               new User{ Name = "User 1"},
               new User{ Name = "User 2"},
               new User{ Name = "User 3"},
               new User{ Name = "User 4"},
               new User{ Name = "User 5"},
               new User{ Name = "User 6"},
               new User{ Name = "User 7"},
               new User{ Name = "User 8"},
            };



            var movies = new Movie[]
            {
               new Movie{ Title = "movie 1"},
               new Movie{ Title = "movie 2"},
               new Movie{ Title = "movie 3"},
               new Movie{ Title = "movie 4"},
               new Movie{ Title = "movie 5"},
               new Movie{ Title = "movie 6"},
               new Movie{ Title = "movie 7"},
               new Movie{ Title = "movie 8"},
           };



            dbContext.Users.AddRange(users);
            dbContext.Movies.AddRange(movies);
            dbContext.SaveChanges();


            var ratings = new Rating[]
            {
               new Rating{UserId = users[0].Id, MovieId = movies[0].Id, Value = 2 },
               new Rating{UserId = users[0].Id, MovieId = movies[1].Id, Value = 5 },
               new Rating{UserId = users[0].Id, MovieId = movies[2].Id, Value = 3 },
               new Rating{UserId = users[0].Id, MovieId = movies[3].Id, Value = 5 },
               new Rating{UserId = users[0].Id, MovieId = movies[4].Id, Value = 4 },
               new Rating{UserId = users[0].Id, MovieId = movies[5].Id, Value = 1 },

               new Rating{UserId = users[1].Id, MovieId = movies[1].Id, Value = 3 },
               new Rating{UserId = users[1].Id, MovieId = movies[3].Id, Value = 4 },
               new Rating{UserId = users[1].Id, MovieId = movies[4].Id, Value = 2 },
               new Rating{UserId = users[1].Id, MovieId = movies[5].Id, Value = 3 },
               new Rating{UserId = users[1].Id, MovieId = movies[6].Id, Value = 5 },
               new Rating{UserId = users[1].Id, MovieId = movies[7].Id, Value = 2 },
            };


            dbContext.Ratings.AddRange(ratings);
            dbContext.SaveChanges();


            Console.WriteLine("ok");


         }
      }
   }
}
