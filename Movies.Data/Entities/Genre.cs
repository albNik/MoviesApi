using System.Collections.Generic;

namespace Movies.Data.Entities
{
   public class Genre
   {
      public int Id { get; set; }

      public int Name { get; set; }

    
      public virtual ICollection<Movie> Movies { get; set; }
   }
}
