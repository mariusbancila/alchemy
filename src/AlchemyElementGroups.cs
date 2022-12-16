using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

namespace Alchemy
{
   static class GroupIndexes
   {
      public const int Mineral = 0;
      public const int Life = 1;
      public const int Animal = 2;
      public const int Air = 3;
      public const int Fire = 4;
      public const int Object = 5;
      public const int Liquid = 6;
      public const int Metal = 7;
      public const int Food = 8;
      public const int Media = 9;
      public const int Abstract = 10;
      public const int Building = 11;
      public const int Spacetime = 12;
      public const int People = 13;
      public const int Machinery = 14;
      public const int Place = 15;
   }

   static class AlchemyElementGroups
   {
      private static AlchemyElementGroup[] groups;

      static AlchemyElementGroups()
      {
         groups = new AlchemyElementGroup[]
         {
            new AlchemyElementGroup{ID=GroupIndexes.Mineral, Name="Mineral", TextBrush=Brushes.Brown},
            new AlchemyElementGroup{ID=GroupIndexes.Life, Name="Life", TextBrush=Brushes.Green},
            new AlchemyElementGroup{ID=GroupIndexes.Animal, Name="Animal", TextBrush=Brushes.Yellow},
            new AlchemyElementGroup{ID=GroupIndexes.Air, Name="Air", TextBrush=Brushes.White},
            new AlchemyElementGroup{ID=GroupIndexes.Fire, Name="Fire", TextBrush=Brushes.Red},
            new AlchemyElementGroup{ID=GroupIndexes.Object, Name="Object", TextBrush=Brushes.LightCoral},
            new AlchemyElementGroup{ID=GroupIndexes.Liquid, Name="Liquid", TextBrush=Brushes.White},
            new AlchemyElementGroup{ID=GroupIndexes.Metal, Name="Metal", TextBrush=Brushes.Silver},
            new AlchemyElementGroup{ID=GroupIndexes.Food, Name="Food", TextBrush=Brushes.LightGreen},
            new AlchemyElementGroup{ID=GroupIndexes.Media, Name="Media", TextBrush=Brushes.Gold},
            new AlchemyElementGroup{ID=GroupIndexes.Abstract, Name="Abstract", TextBrush=Brushes.White},
            new AlchemyElementGroup{ID=GroupIndexes.Building, Name="Building", TextBrush=Brushes.Gray},
            new AlchemyElementGroup{ID=GroupIndexes.Spacetime, Name="Spacetime", TextBrush=Brushes.Yellow},
            new AlchemyElementGroup{ID=GroupIndexes.People, Name="People", TextBrush=Brushes.Red},
            new AlchemyElementGroup{ID=GroupIndexes.Machinery, Name="Machinery", TextBrush=Brushes.LightCoral},
            new AlchemyElementGroup{ID=GroupIndexes.Place, Name="Place", TextBrush=Brushes.White},
         };
      }

      public static AlchemyElementGroup[] Groups
      {
         get { return groups; }
      }
   }
}