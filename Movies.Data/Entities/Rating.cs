using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data.Entities
{
   public class Rating
   {
      public int Id { get; set; }

      public int UserId { get; set; }

      public int MovieId { get; set; }

      public double Value { get; set; }


      public virtual User User { get; set; }

      public virtual Movie Movie { get; set; }
   }
}
