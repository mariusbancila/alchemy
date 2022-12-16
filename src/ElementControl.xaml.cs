using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace Alchemy
{
   /// <summary>
   /// Interaction logic for ElementControl.xaml
   /// </summary>
   public partial class ElementControl : UserControl, IComparable, INotifyPropertyChanged
   {
      public static DependencyProperty LabelProperty =
         DependencyProperty.Register(
            "Label",
            typeof(string),
            typeof(ElementControl));


      public string Label
      {
         get
         {
            return (string)GetValue(LabelProperty);
         }
         set
         {
            SetValue(LabelProperty, value);
         }
      }

      public static DependencyProperty LabelColorProperty =
         DependencyProperty.Register(
            "LabelColor",
            typeof(Brush),
            typeof(ElementControl));


      public Brush LabelColor
      {
         get
         {
            return (Brush)(GetValue(LabelColorProperty));
         }
         set
         {
            SetValue(LabelColorProperty, value);
         }
      }

      public static DependencyProperty LabelFontWeightProperty =
         DependencyProperty.Register(
            "LabelFontWeight",
            typeof(FontWeight),
            typeof(ElementControl));


      public FontWeight LabelFontWeight
      {
         get
         {
            return (FontWeight)(GetValue(LabelFontWeightProperty));
         }
         set
         {
            SetValue(LabelFontWeightProperty, value);
         }
      }

      public static DependencyProperty IconProperty =
         DependencyProperty.Register(
            "Icon",
            typeof(BitmapImage),
            typeof(ElementControl));


      public BitmapImage Icon
      {
         get
         {
            return (BitmapImage)GetValue(IconProperty);
         }
         set
         {
            SetValue(IconProperty, value);
         }
      }

      public static DependencyProperty SelectionModeProperty =
         DependencyProperty.Register(
         "SelectionMode",
         typeof(ElementSelection),
         typeof(ElementControl));

      public ElementSelection SelectionMode
      {
         get 
         {
            return (ElementSelection)GetValue(SelectionModeProperty);
         }
         set
         {
            SetValue(SelectionModeProperty, value);
         }
      }

      private AlchemyElement _AlchemyData;
      public AlchemyElement AlchemyData 
      {
         get { return _AlchemyData; }
         set 
         { 
            _AlchemyData = value;
            if (PropertyChanged != null)
               PropertyChanged(this, new PropertyChangedEventArgs("AlchemyData"));
         }
      }

      public ElementControl()
      {
         InitializeComponent();
      }

      public int CompareTo(object obj)
      {
          ElementControl element = obj as ElementControl;
          if (element != null)
              return this.Label.CompareTo(element.Label);
          else
              throw new ArgumentException("Object is not an ElementControl");
      }

      #region INotifyPropertyChanged Members

      public event PropertyChangedEventHandler PropertyChanged;

      #endregion
   }
}
