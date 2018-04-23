using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data.Entities
{
   public class User
   {
      public int Id { get; set; }
      public string Name { get; set; }

      public virtual ICollection<Rating> Ratings { get; set; }
   }
}
