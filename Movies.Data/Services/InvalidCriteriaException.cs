using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data.Services
{
   public class InvalidCriteriaException : Exception
   {
      public InvalidCriteriaException(string message)
         :base(message)
      {

      }

   }
}
