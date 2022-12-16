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
using System.Reflection;
using Microsoft.Win32;

namespace Alchemy
{
   /// <summary>
   /// Interaction logic for SettingsWindow.xaml
   /// </summary>
   public partial class SettingsWindow : Window
   {
      MainWindow m_mainwnd;
      private bool m_languagesLoaded;
      private bool m_cheatsLoaded;
      private bool m_creditsLoaded;
      private bool m_settingsLoaded;

      public SettingsWindow(MainWindow mainref)
      {
         InitializeComponent();

         ShowInTaskbar = false;
         m_mainwnd = mainref;
      }

      private void Window_Loaded(object sender, RoutedEventArgs e)
      {
         Localize();
      }

      private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
      {
         if (m_settingsLoaded)
         {
            UserOptions.CombineOnlyNew = checkBoxCombineOnlyNew.IsChecked??false;
            UserOptions.TabToCombine = checkBoxTapToCombine.IsChecked??false;
            UserOptions.ShowTimer = checkBoxTimer.IsChecked ?? false;
         }
      }

      private void Localize()
      {
         // title
         this.Title = AlchemyResources.UI.MoreTitle;

         // tab
         tabItemSaves.Header = AlchemyResources.UI.HeaderSaves;
         tabItemLanguage.Header = AlchemyResources.UI.HeaderLanguage;
         tabItemSettings.Header = AlchemyResources.UI.HeaderSettings;
         tabItemCheats.Header = AlchemyResources.UI.HeaderCheats;
         tabItemCredits.Header = AlchemyResources.UI.HeaderCredits;

         // saves
         textSavesDescription.Text = AlchemyResources.UI.SavesInfoLine;
         buttonSaveLabel.Content = AlchemyResources.UI.ButtonSave;
         buttonLoadLabel.Content = AlchemyResources.UI.ButtonLoad;
         buttonResetLabel.Content = AlchemyResources.UI.ButtonReset;

         // language
         languageTipText.Text = AlchemyResources.UI.LanguageDescription;

         // settings
         checkBoxCombineOnlyNew.Content = AlchemyResources.UI.SettingCombineNew;
         checkBoxTapToCombine.Content = AlchemyResources.UI.SettingTapCombine;
         checkBoxTimer.Content = AlchemyResources.UI.ShowTimer;

         UpdateFlowDirection();
      }

      private void UpdateFlowDirection()
      {
         labelSaves.FlowDirection = AlchemyResources.Languages.CurrentFlowDirection;
         languageTipLabel.FlowDirection = AlchemyResources.Languages.CurrentFlowDirection;
         tabItemSettings.FlowDirection = AlchemyResources.Languages.CurrentFlowDirection;         
      }

      #region saves

      private void buttonSave_Click(object sender, RoutedEventArgs e)
      {
         var dlg = new SaveFileDialog();
         dlg.Filter = "Alchemy User Settings (*.aus)|*.aus";
         dlg.InitialDirectory = Environment.CurrentDirectory;
         dlg.RestoreDirectory = true;
         dlg.AddExtension = true;
         dlg.CheckFileExists = false;

         bool? res = dlg.ShowDialog();
         if (res.HasValue && res.Value)
         {
            m_mainwnd.Save(dlg.FileName);
         }
      }

      private void buttonLoad_Click(object sender, RoutedEventArgs e)
      {
         var dlg = new OpenFileDialog();
         dlg.Filter = "Alchemy User Settings (*.aus)|*.aus";
         dlg.InitialDirectory = Environment.CurrentDirectory;
         dlg.RestoreDirectory = true;
         dlg.AddExtension = true;
         dlg.CheckFileExists = true;

         bool? res = dlg.ShowDialog();
         if (res.HasValue && res.Value)
         {
            m_mainwnd.Reload(dlg.FileName);
            this.Close();
         }
      }

      private void buttonReset_Click(object sender, RoutedEventArgs e)
      {
         MessageBoxResult res = MessageBox.Show(
            AlchemyResources.UI.ResetProgressWarning,
            "Alchemy",
            MessageBoxButton.YesNo,
            MessageBoxImage.Warning);

         if (res == MessageBoxResult.Yes)
         {
            m_mainwnd.Reset();
         }
      }

      #endregion

      #region language

      private void newLanguageButton_Click(object sender, RoutedEventArgs e)
      {
         ListBoxItem lbi = languagesListBox.SelectedItem as ListBoxItem;
         if (lbi != null)
         {
            AlchemyResources.Languages.CurrentLanguage = (int)lbi.DataContext;
            this.Close();
         }         
      }

      private void PopulateLanguageList()
      {
         if (!m_languagesLoaded)
         {
            m_languagesLoaded = true;
            Type t = typeof(AlchemyResources.Languages.Indexes);
            FieldInfo[] allfields = t.GetFields();
            var fields = allfields.Where(fi => (fi.Attributes & FieldAttributes.RTSpecialName) == 0).OrderBy(s => s.Name);

            int selection = 0;
            foreach (var field in fields)
            {
               int index = (int)field.GetValue(null);
               Image img = new Image();
               img.Source = new BitmapImage(
                   new Uri(String.Format("Images/Languages/{0}.png", AlchemyResources.Languages.LanguageName(index, AlchemyResources.Languages.Indexes.English)),
                       UriKind.Relative));
               img.VerticalAlignment = VerticalAlignment.Center;
               img.HorizontalAlignment = HorizontalAlignment.Center;

               Label label = new Label();
               label.Content = AlchemyResources.Languages.LanguageName(index, AlchemyResources.Languages.CurrentLanguage);
               label.Margin = new Thickness(10, 0, 10, 0);
               label.VerticalAlignment = VerticalAlignment.Center;
               label.HorizontalAlignment = HorizontalAlignment.Center;
               label.Foreground = Brushes.White;

               WrapPanel wp = new WrapPanel();
               wp.Children.Add(img);
               wp.Children.Add(label);

               ListBoxItem lbi = new ListBoxItem();
               lbi.Content = wp;
               lbi.FlowDirection = AlchemyResources.Languages.CurrentFlowDirection;

               lbi.DataContext = index;

               int pos = languagesListBox.Items.Add(lbi);
               if (index == AlchemyResources.Languages.CurrentLanguage)
                  selection = pos;
            }

            languagesListBox.SelectedIndex = selection;

            UpdateLanguageButtonContent();

            languagesListBox.Focus();
         }
      }

      private void UpdateLanguageButtonContent()
      {
         if (languagesListBox.SelectedItem != null)
         {
            ListBoxItem lbi = languagesListBox.SelectedItem as ListBoxItem;
            WrapPanel wp = lbi.Content as WrapPanel;
            var enumerator = wp.Children.GetEnumerator();
            enumerator.MoveNext();
            enumerator.MoveNext();
            var label = enumerator.Current as Label;
            newLanguageButton.Content = String.Format(
                AlchemyResources.UI.LanguageButton,
                label.Content);
         }
      }

      private void languagesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
      {
         UpdateLanguageButtonContent();
      }

      #endregion language

      #region settings

      private void PopulateSettings()
      {
         if (!m_settingsLoaded)
         {
            m_settingsLoaded = true;
            checkBoxCombineOnlyNew.IsChecked = UserOptions.CombineOnlyNew;
            checkBoxTapToCombine.IsChecked = UserOptions.TabToCombine;
            checkBoxTimer.IsChecked = UserOptions.ShowTimer;
         }
      }

      #endregion

      #region cheats

      private void PopulateCheats()
      {
         if (!m_cheatsLoaded)
         {
            m_cheatsLoaded = true;
            allElementsList.ItemsSource = from e in AlchemyElements.Elements
                                          orderby e.Name
                                          select new ElementControl
                                          {
                                             Label = e.Name,
                                             LabelColor = e.Group.TextBrush,
                                             LabelFontWeight = FontWeights.Normal,
                                             Icon = e.Icon,
                                             AlchemyData = e
                                          };
         }
      }

      #endregion

      #region credits

      private void PopulateCredits()
      {
         if (!m_creditsLoaded)
         {
            m_creditsLoaded = true;

            List<StackPanel> items = new List<StackPanel>();

            Dictionary<String, int> orderedcredits = new Dictionary<string, int>();
            for (int i = 0; i < AlchemyCredits.Credits.Length; ++i)
            {
               orderedcredits.Add(
                  AlchemyResources.Languages.LanguageName(
                     AlchemyCredits.Credits[i].LanguageIndex,
                     AlchemyResources.Languages.CurrentLanguage),
                  i);
            }

            foreach(var kvp in orderedcredits.OrderBy(c => c.Key))
            {
               StackPanel sp = new StackPanel();

               Label lauthor = new Label();
               lauthor.Content = AlchemyCredits.Credits[kvp.Value].Translator;
               lauthor.Foreground = Brushes.White;
               lauthor.FontWeight = FontWeights.Bold;
               lauthor.FontSize = 16;
               lauthor.FlowDirection = AlchemyResources.Languages.CurrentFlowDirection;
               sp.Children.Add(lauthor);

               Label llang = new Label();
               llang.Content = kvp.Key;
               llang.Foreground = Brushes.LightBlue;
               llang.FlowDirection = AlchemyResources.Languages.CurrentFlowDirection;
               sp.Children.Add(llang);

               Rectangle rect = new Rectangle();
               rect.Stroke = Brushes.White;
               rect.Width = listBoxCredits.Width - 30;
               sp.Children.Add(rect);

               items.Add(sp);
            }

            listBoxCredits.ItemsSource = items;
         }
      }

      #endregion

      private void tabControlMore_SelectionChanged(object sender, SelectionChangedEventArgs e)
      {
         switch (tabControlMore.SelectedIndex)
         {
            case 0: // saves
               break;
               
            case 1: // languages
               PopulateLanguageList();
               break;

            case 2: // settings
               PopulateSettings();
               break;

            case 3: // cheats
               PopulateCheats();
               break;

            case 4: // credits
               PopulateCredits();
               break;
         }
      }

   }
}
