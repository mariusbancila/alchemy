using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace Alchemy
{
   class SelectionToBrushConverter : IValueConverter
   {
      #region IValueConverter Members

      public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
         ElementSelection selection = (ElementSelection)value;

         switch(selection)
         {
            case ElementSelection.None:
               return null;
            case ElementSelection.ForCombining:
               return Brushes.White;
            case ElementSelection.ForDeletion:
               return Brushes.Red;
         }

         return null;
      }

      public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
         return null;
      }

      #endregion
   }
}
