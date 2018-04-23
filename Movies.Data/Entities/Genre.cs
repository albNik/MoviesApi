using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data.Entities
{
   public class Genre
   {
      public int Id { get; set; }

      public int Name { get; set; }

      public virtual ICollection<Movie> Movies { get; set; }
   }
}
