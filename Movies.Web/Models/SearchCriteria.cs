using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movies.Web.Models
{
   public class SearchCriteria
   {
      public string Title { get; set; }
      public int? Year { get; set; }
      public string Genres { get; set; }
   }
}