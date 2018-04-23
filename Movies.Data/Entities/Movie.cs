using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data.Entities
{
   public class Movie
   {
      public int Id { get; set; }

      public string Title { get; set; }

      public int Year { get; set; }



      public virtual ICollection<Genre> Genres { get; set; }

      public virtual ICollection<Rating> Ratings { get; set; }
   }
}
