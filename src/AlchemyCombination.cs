using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alchemy
{
   public class AlchemyCombination
   {
      public AlchemyElement InputElement1 { get; set; }
      public AlchemyElement InputElement2 { get; set; }

      public AlchemyElement Result1 { get; set; }
      public AlchemyElement Result2 { get; set; }
      public AlchemyElement Result3 { get; set; }
      public AlchemyElement Result4 { get; set; }

      public int ResultsCount
      {
         get 
         {
            if (Result1 == null) return 0;
            else if (Result2 == null) return 1;
            else if (Result3 == null) return 2;
            else if (Result4 == null) return 3;
            else return 4;
         }
      }

      public override string ToString()
      {
         StringBuilder builder = new StringBuilder();

         this.Append(builder);

         return builder.ToString();
      }
   }

   static class AlchemyCombinationsExtensions
   {
      public static AlchemyCombination Find(
         this IEnumerable<AlchemyCombination> combinations,
         AlchemyElement e1,
         AlchemyElement e2)
      {
         if (e1 == null || e2 == null)
            return null;

         return (from c in combinations
                      where c.InputElement1.ID == e1.ID && c.InputElement2.ID == e2.ID ||
                            c.InputElement1.ID == e2.ID && c.InputElement2.ID == e1.ID
                      select c).FirstOrDefault();
      }

      public static AlchemyCombination Find(
         this IEnumerable<AlchemyCombination> combinations,
         int id1,
         int id2)
      {
         return (from c in combinations
                 where c.InputElement1.ID == id1 && c.InputElement2.ID == id2 ||
                       c.InputElement1.ID == id2 && c.InputElement2.ID == id1
                 select c).FirstOrDefault();
      }

      public static string FindUnlockedCombinations(
         this IEnumerable<AlchemyCombination> combinations,
         AlchemyElement element)
      {
         if(combinations == null || element == null)
            return string.Empty;

         StringBuilder builder = new StringBuilder();

         foreach (AlchemyCombination combination in combinations)
         {
            if (combination.InputElement1.ID == element.ID ||
               combination.InputElement2.ID == element.ID ||
               (combination.Result1 != null && combination.Result1.ID == element.ID) ||
               (combination.Result2 != null && combination.Result2.ID == element.ID) ||
               (combination.Result3 != null && combination.Result3.ID == element.ID) ||
               (combination.Result4 != null && combination.Result4.ID == element.ID))
            {

               if(combination.Append(builder))
                  builder.AppendLine();
            }
         }

         return builder.ToString();
      }

      public static bool Append(
         this AlchemyCombination combination,
         StringBuilder builder)
      {
         if (combination != null)
         {
            builder.AppendFormat("{0} + {1} = ",
               combination.InputElement1.Name,
               combination.InputElement2.Name);

            switch (combination.ResultsCount)
            {
               case 1:
                  {
                     builder.AppendFormat("{0}", combination.Result1.Name);
                  }
                  break;
               case 2:
                  {
                     builder.AppendFormat("{0} + {1}",
                        combination.Result1.Name,
                        combination.Result2.Name);
                  }
                  break;
               case 3:
                  {
                     builder.AppendFormat("{0} + {1} + {2}",
                        combination.Result1.Name,
                        combination.Result2.Name,
                        combination.Result3.Name);
                  }
                  break;
               case 4:
                  {
                     builder.AppendFormat("{0} + {1} + {2} + {3}",
                        combination.Result1.Name,
                        combination.Result2.Name,
                        combination.Result3.Name,
                        combination.Result4.Name);
                  }
                  break;
            }

            return true;
         }

         return false;
      }
   }
}
