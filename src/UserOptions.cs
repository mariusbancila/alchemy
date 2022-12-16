using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alchemy
{
   public static class UserOptions
   {
      /// <summary>
      /// Indicates whether already discovered combinations should be locked.
      /// </summary>
      public static bool CombineOnlyNew { get; set; }

      /// <summary>
      /// Indicates whether combinations should happen by tapping on the first and then the second element.
      /// </summary>
      public static bool TabToCombine { get; set; }

       /// <summary>
       /// Indicates whether the total elapsed time should be shown.
       /// </summary>
      public static bool ShowTimer { get; set; }
   }
}
