using System.Collections.Generic;

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
