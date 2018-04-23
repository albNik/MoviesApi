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
      public object GetMovies()
      {




      }


      public HttpResponseMessage GetTop5()
      {
         return Request.CreateResponse();
      }

      public HttpResponseMessage GetTop5ForUser(int userId)
      {
         return Request.CreateResponse();
      }


      public HttpResponseMessage SetRating([FromBody] object obj)
      {
         return Request.CreateResponse();
      }
   }
}
