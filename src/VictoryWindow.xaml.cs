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
using System.Windows.Shapes;

namespace Alchemy
{
   /// <summary>
   /// Interaction logic for VictoryWindow.xaml
   /// </summary>
   public partial class VictoryWindow : Window
   {
      public VictoryWindow()
      {
         InitializeComponent();

         this.Title = AlchemyResources.UI.VictoryTitle;
         labelCongrats.Content = AlchemyResources.UI.VictoryCongrats;
         labelDescriptionBlock.Text = AlchemyResources.UI.VictoryDescription;
         hintCloseTip.Text = AlchemyResources.UI.HintClose;

         this.FlowDirection = AlchemyResources.Languages.CurrentFlowDirection;
      }

      private void Window_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
      {
         this.Close();
      }
   }
}
