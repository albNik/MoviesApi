using Movies.Data;
using Movies.Data.Services;
using Movies.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Movies.Web.Controllers
{
   public class MoviesController : ApiController
   {

      // /api/movies/get?title=this is title&year=2015&genres=genre1,genre2
      public HttpResponseMessage Get(SearchCriteria search)
      {
         try
         {
            Catalog cat = new Catalog();
            var movies = cat.GetMovies(search.Title, search.Year, search.Genres);
            if(!movies.Any())
               return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
            return Request.CreateResponse(movies);
         }
         catch(InvalidCriteriaException ex)
         {
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
         }
      }

      // /api/movies/gettop5
      public HttpResponseMessage GetTop5()
      {
         Catalog cat = new Catalog();
         var movies = cat.GetMoviesTop5();
         if(!movies.Any())
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
         return Request.CreateResponse(movies);
      }

      // /api/movies/gettop5forUser?userId=1
      public HttpResponseMessage GetTop5ForUser(int userId)
      {
         try
         {
            Catalog cat = new Catalog();
            var movies = cat.GetMoviesTop5forUser(userId);
            if(!movies.Any())
               return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
            return Request.CreateResponse(movies);
         }
         catch(InvalidCriteriaException ex)
         {
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
         }
      }


      [HttpPost]
      public HttpResponseMessage SetRating([FromBody] object obj)
      {
         return Request.CreateResponse();
      }
   }
}
