using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;

namespace Alchemy
{
   class SelectionToVisibilityConverter : IValueConverter
   {
      #region IValueConverter Members

      public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
         ElementSelection selection = (ElementSelection)value;

         return (selection == ElementSelection.None) ? Visibility.Hidden : Visibility.Visible;
      }

      public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
         return null;
      }

      #endregion
   }
}
