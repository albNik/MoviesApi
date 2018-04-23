using System.Collections.Generic;

namespace Movies.Data.Entities
{
   public class User
   {
      public int Id { get; set; }

      public string Name { get; set; }

      public virtual ICollection<Rating> Ratings { get; set; }
   }
}
