using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alchemy
{
   /// <summary>
   /// Possible selection modes for an element
   /// </summary>
   public enum ElementSelection
   {
      /// <summary>
      /// No selection on the element
      /// </summary>
      None,

      /// <summary>
      /// Element is marked for deletion
      /// </summary>
      ForDeletion,

      /// <summary>
      /// Element is selected for combining with another element
      /// </summary>
      ForCombining
   }
}
