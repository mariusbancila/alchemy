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
using System.Windows.Threading;
using System.IO;
using System.Diagnostics;
using System.Windows.Media.Animation;
using System.Reflection;
using Alchemy.Win32;
using System.Timers;

namespace Alchemy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // file history; version
        // 1: store elements, combinations and desktop
        // 2: added selected language
        // 3: added options: combine only new, tab to combine
        // 4: added total elapsed time
        const int CurrentFileVersion = 4;

        List<AlchemyElement> m_discoveredElements = new List<AlchemyElement>();
        List<AlchemyCombination> m_discoveredCombinations = new List<AlchemyCombination>();
        Point m_startPointDragToDesktop;        
        Point m_startPointDragOnDesktop;
        Point m_draggedElementOriginalPos;
        DispatcherTimer m_combinationTimer;
        DispatcherTimer m_deleteTimer;
        DispatcherTimer m_timerTimer;
        DispatcherTimer m_tipsTimer;
        BitmapImage m_recycleEmpty;
        BitmapImage m_recycleFull;
        BitmapImage m_help;
        BitmapImage m_about;
        bool m_isDraggingElement;
        ElementControl m_desktopDraggedElement;
        ElementControl m_currentSelection;
        List<ElementControl> m_deleteSelection = new List<ElementControl>();
        int m_totalElapsedSeconds;

        string [] m_tipsElements;
        int m_tipIndexElements;

        string[] m_tipsDesktop;
        int m_tipIndexDesktop;

        readonly Duration m_animationDuration = new Duration(TimeSpan.FromSeconds(0.25));
        bool m_animationRunning;
        bool m_combinationShowing;
        bool m_elementGripped;
        bool m_dragging;
        int m_elementsCounter;

        public MainWindow()
        {
            InitializeComponent();

            if (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height >= 800)
               this.Height = 800;

            m_recycleEmpty = new BitmapImage(new Uri("Images/RecycleBinEmpty.png", UriKind.Relative));
            m_recycleFull = new BitmapImage(new Uri("Images/RecycleBinFull.png", UriKind.Relative));
            m_help = new BitmapImage(new Uri("Images/helpblack.png", UriKind.Relative));
            m_about = new BitmapImage(new Uri("Images/aboutblack.png", UriKind.Relative));

            m_combinationTimer = new DispatcherTimer();
            m_combinationTimer.Interval = TimeSpan.FromMilliseconds(2000);
            m_combinationTimer.Tick += new EventHandler((s, a) =>
            {
                desktopTipBottom.Content = string.Empty;
                m_combinationShowing = false;
                m_combinationTimer.Stop();
            });

            m_deleteTimer = new DispatcherTimer();
            m_deleteTimer.Interval = TimeSpan.FromMilliseconds(1000);
            m_deleteTimer.Tick += new EventHandler((s, a) =>
            {
                recycleImage.Source = m_recycleEmpty;
                m_deleteTimer.Stop();
            });

            m_timerTimer = new DispatcherTimer();
            m_timerTimer.Interval = TimeSpan.FromMilliseconds(1000);
            m_timerTimer.Tick += new EventHandler((s, a) =>
            {
                m_totalElapsedSeconds++;
                if (!m_combinationShowing && UserOptions.ShowTimer)
                {
                    int sec = m_totalElapsedSeconds % 60;
                    int min = m_totalElapsedSeconds / 60;
                    int h = min / 60;
                    min = min % 60;
                    desktopTipBottom.Content = String.Format("{0}:{1:D2}:{2:D2}", h, min, sec);
                }
            });

            m_tipIndexElements = -1;
            m_tipIndexDesktop = -1;
            m_tipsTimer = new DispatcherTimer();
            m_tipsTimer.Interval = TimeSpan.FromMilliseconds(15000);
            m_tipsTimer.Tick += new EventHandler((s, a) =>
            {
               ShowNextListTip();
               ShowNextDesktopTip();
            });
            m_tipsTimer.Start();
        }


        #region event handlers

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Save();

#if(DEBUG)
            SaveAll();
#endif
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
#if(DEBUG)
            CheckCombinations();
            CheckElements();
#endif

            Reload();
            m_timerTimer.Start();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
           if (e.Key == Key.Delete && m_deleteSelection.Count > 0)
           {
              foreach (var child in m_deleteSelection)
              {
                 desktopCanvas.Children.Remove(child);
              }

              m_deleteSelection.Clear();
              ShowElementHelp(null);

              recycleImage.Source = m_recycleFull;
              m_deleteTimer.Stop();
              m_deleteTimer.Start();
           }
        }

        private void elementsList_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                var elem = (ElementControl)elementsList.SelectedItem;
                if (elem != null && elem.AlchemyData != null && !elem.AlchemyData.Terminal)
                {                    
                    var pos = e.GetPosition(elementsList);
                    double left = pos.X;
                    double top = pos.Y;
                    if (left < 0) left = 0;
                    if (left + elem.RenderSize.Width > desktopCanvas.RenderSize.Width)
                        left = desktopCanvas.RenderSize.Width - elem.RenderSize.Width;
                    if (top < 0) top = 0;
                    if (top + elem.RenderSize.Height > desktopCanvas.RenderSize.Height)
                        top = desktopCanvas.RenderSize.Height - elem.RenderSize.Height;
                    NewCanvasElement(elem.AlchemyData, left, top);
                }
            }
            else
            {
                // Store the mouse position
                m_startPointDragToDesktop = e.GetPosition(elementsList);
                m_elementGripped = false;
                m_dragging = true;
            }

            ShowElementHelp((ElementControl)elementsList.SelectedItem);
        }

        private void elementsList_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
           m_dragging = false;
           m_elementGripped = false;
        }

        private void elementsList_PreviewMouseMove(object sender, MouseEventArgs e)
        {
           if (m_dragging)
           {
              if (m_elementGripped) return;
              // Get the current mouse position
              Point mousePos = e.GetPosition(null);
              Vector diff = m_startPointDragToDesktop - mousePos;

              if (e.LeftButton == MouseButtonState.Pressed &&
                  Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance &&
                  Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance)
              {
                 // Get the dragged ListBoxItem
                 ListBox listBox = sender as ListBox;
                 ListBoxItem listBoxItem =
                     FindAnchestor<ListBoxItem>((DependencyObject)e.OriginalSource);

                 if (listBoxItem != null)
                 {
                    // Find the data behind the ListBoxItem
                    ElementControl element = (ElementControl)listBox.ItemContainerGenerator.
                        ItemFromContainer(listBoxItem);
                    m_elementGripped = true;

                    if (element.AlchemyData != null && !element.AlchemyData.Terminal)
                    {
                       // Initialize the drag & drop operation
                       DataObject dragData = new DataObject("list2desktop", element);
                       DragDrop.DoDragDrop(listBoxItem, dragData, DragDropEffects.Copy);
                    }
                 }
              }
           }
        }

        private void desktopCanvas_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("list2desktop"))
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void desktopCanvas_Drop(object sender, DragEventArgs e)
        {
            ElementControl control = null;

            // find the dragged data
            if (e.Data.GetDataPresent("list2desktop"))
            {
                control = e.Data.GetData("list2desktop") as ElementControl;
            }

            if (control != null)
            {
                elementsList.SelectedItem = null;

                // get the position of the mouse on drop
                Point pos = e.GetPosition(desktopCanvas);

                // adjust the position so that the control is fully visible within the desktop
                if (pos.X < control.Width / 2)
                    pos.X = control.Width / 2;
                if (pos.Y < control.Height / 2)
                    pos.Y = control.Height / 2;
                if (desktopCanvas.RenderSize.Width - pos.X < control.Width / 2)
                    pos.X = desktopCanvas.RenderSize.Width - control.Width / 2;
                if (desktopCanvas.RenderSize.Height - pos.Y < control.Height / 2)
                    pos.Y = desktopCanvas.RenderSize.Height - control.Height / 2;

                // we have to copy the element from the list to the canvas
                if (e.Effects == DragDropEffects.Copy)
                {
                    // create a new element
                    ElementControl desktopControl = new ElementControl
                    {
                        Label = control.Label,
                        LabelColor = control.LabelColor,
                        LabelFontWeight = control.LabelFontWeight,
                        Icon = control.Icon,
                        AlchemyData = control.AlchemyData
                    };

                    Canvas.SetLeft(desktopControl, pos.X - control.Width / 2);
                    Canvas.SetTop(desktopControl, pos.Y - control.Height / 2);

                    // add the element to the canvas
                    desktopCanvas.Children.Add(desktopControl);

                    CheckCombination(desktopControl);
                }
                // only move the element on the canvas
                else if (e.Effects == DragDropEffects.Move)
                {
                    // set the new relative position
                    Canvas.SetLeft(control, pos.X - control.Width / 2);
                    Canvas.SetTop(control, pos.Y - control.Height / 2);

                    PutOnTop(control);

                    CheckCombination(control);
                }
            }

            m_dragging = false;
        }

        private void desktopCanvas_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                ElementControl child =
                    FindAnchestor<ElementControl>((DependencyObject)e.OriginalSource);

                if (child != null)
                {
                    double left = Canvas.GetLeft(child);
                    double top = Canvas.GetTop(child);
                    double left1 = 0;
                    double top1 = 0;
                    if (left + 2 * child.Width <= desktopCanvas.RenderSize.Width)
                        left1 = left + child.Width / 2;
                    else
                        left1 = left - child.Width / 2;
                    if (top + 2 * child.Height <= desktopCanvas.RenderSize.Height)
                        top1 = top + child.Height / 2;
                    else
                        top1 = top - child.Height / 2;

                    NewCanvasElement(child.AlchemyData, left1, top1);
                }
                else
                {
                    double hitx = e.GetPosition(desktopCanvas).X;
                    double hity = e.GetPosition(desktopCanvas).Y;

                    if (hitx + 64 > desktopCanvas.RenderSize.Width)
                        hitx = desktopCanvas.RenderSize.Width - 64;
                    if (hity + 94 > desktopCanvas.RenderSize.Height)
                        hity = desktopCanvas.RenderSize.Height - 94;

                    Place4Elements(
                        AlchemyElements.Elements[ElementIndexes.Fire],
                        AlchemyElements.Elements[ElementIndexes.Air],
                        AlchemyElements.Elements[ElementIndexes.Earth],
                        AlchemyElements.Elements[ElementIndexes.Water],
                        hitx,
                        hity,
                        64,
                        94);
                }
                m_isDraggingElement = false;
            }
            else
            {
                ElementControl child =
                    FindAnchestor<ElementControl>((DependencyObject)e.OriginalSource);

                if (child != null)
                {
                   KeyStateInfo ctrlLock = KeyboardInfo.GetKeyState(System.Windows.Forms.Keys.ControlKey);
                   if (ctrlLock.IsPressed)
                   {
                      child.SelectionMode = ElementSelection.ForDeletion;
                      m_deleteSelection.Add(child);
                      if (child == m_currentSelection)
                         m_currentSelection = null;
                   }
                   else
                   {
                      if (m_deleteSelection.Count > 0)
                      {
                         foreach (var elem in m_deleteSelection)
                            elem.SelectionMode = ElementSelection.None;
                         m_deleteSelection.Clear();
                      }

                      ShowElementHelp(child);

                      #region tap to combine

                      if (UserOptions.TabToCombine)
                      {
                         // first selection
                         if (m_currentSelection == null)
                         {
                            m_currentSelection = child;
                            ShowSelection(m_currentSelection);
                         }
                         // first selection different than the current selection
                         else if (m_currentSelection != child)
                         {
                            bool added = CheckAndAdd(m_currentSelection, child);
                            if (added)
                            {
                               m_currentSelection = null;
                               child = null;
                            }
                            else
                            {
                               HideSelection(m_currentSelection);
                               m_currentSelection = child;
                               ShowSelection(m_currentSelection);
                            }
                         }
                         // selecting the same element
                         else
                         {
                         }
                      }

                      #endregion

                      if (child != null)
                      {
                         PutOnTop(child);
                         m_desktopDraggedElement = child;
                         m_isDraggingElement = true;
                         m_draggedElementOriginalPos = new Point(
                             Canvas.GetLeft(child),
                             Canvas.GetTop(child));

                         m_startPointDragOnDesktop = e.GetPosition(desktopCanvas);
                      }
                   }
                }
                else
                {
                   if (m_deleteSelection.Count > 0)
                   {
                      foreach (var elem in m_deleteSelection)
                         elem.SelectionMode = ElementSelection.None;
                      m_deleteSelection.Clear();
                   }

                   if (UserOptions.TabToCombine)
                   {
                      HideSelection(m_currentSelection);
                      m_currentSelection = null;
                   }
                   ShowElementHelp(null);
                }                
            }
        }

        private void desktopCanvas_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (m_isDraggingElement)
            {
                Point mousePos = e.GetPosition(desktopCanvas);
                Vector diff = m_startPointDragOnDesktop - mousePos;

                double left = m_draggedElementOriginalPos.X - diff.X;
                double top = m_draggedElementOriginalPos.Y - diff.Y;

                if (left < 0)
                {
                    left = 0;
                }
                else if (left + m_desktopDraggedElement.RenderSize.Width > desktopCanvas.RenderSize.Width)
                {
                    left = desktopCanvas.RenderSize.Width - m_desktopDraggedElement.RenderSize.Width;
                }

                if (top < 0)
                {
                    top = 0;
                }
                else if (top + m_desktopDraggedElement.RenderSize.Height > desktopCanvas.RenderSize.Height)
                {

                    top = desktopCanvas.RenderSize.Height - m_desktopDraggedElement.RenderSize.Height;
                }

                Canvas.SetLeft(m_desktopDraggedElement, left);
                Canvas.SetTop(m_desktopDraggedElement, top);
            }
        }

        private void desktopCanvas_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (m_isDraggingElement)
            {
                double top = Canvas.GetTop(m_desktopDraggedElement);
                if (top + m_desktopDraggedElement.Height > desktopCanvas.RenderSize.Height)
                {
                    desktopCanvas.Children.Remove(m_desktopDraggedElement);

                    recycleImage.Source = m_recycleFull;
                    m_deleteTimer.Stop();
                    m_deleteTimer.Start();
                }
                else
                {
                    CheckCombination(m_desktopDraggedElement);
                }

                m_isDraggingElement = false;
                m_draggedElementOriginalPos = default(Point);
                m_desktopDraggedElement = null;
            }
        }

        private void elementsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowElementHelp((ElementControl)elementsList.SelectedItem);
        }

        private void elementsList_LostFocus(object sender, RoutedEventArgs e)
        {
            elementsList.SelectedItem = null;
        }

        private void nonTerminalsSearchBox_Search(object sender, RoutedEventArgs e)
        {
            TextBox tb = e.OriginalSource as TextBox;
            if (tb != null)
            {
                elementsList.Items.Filter = o =>
                {
                    if (string.IsNullOrEmpty(tb.Text)) return true;
                    ElementControl item = o as ElementControl;
                    if (item != null)
                    {
                        if (string.IsNullOrEmpty(item.Label)) return false;

                        int index = item.Label.IndexOf(
                           tb.Text,
                           0,
                           StringComparison.InvariantCultureIgnoreCase);
                        return index > -1;
                    }
                    return false;
                };
            }
        }

        private void buttonSearchOnline_Click(object sender, RoutedEventArgs e)
        {
           if (elementHelpIcon.Source != null && elementHelpIcon.Source != m_help && elementHelpIcon.Source != m_about)
           {
              string text = labelHelpTop.Content as string;

              string searchtext = String.Format("http://{0}.wikipedia.org/w/index.php?search={1}",
                 AlchemyResources.Languages.CurrentWikiLanguage,
                 text.Replace(" ", "+"));

              try
              {
                 System.Diagnostics.Process.Start(searchtext);
              }
              catch (Exception)
              {
              }
           }
        }

        private void buttonMore_Click(object sender, RoutedEventArgs e)
        {
           SettingsWindow sw = new SettingsWindow(this);
           sw.ShowInTaskbar = false;
           sw.Owner = this;
           sw.WindowStartupLocation = WindowStartupLocation.CenterOwner;

           int oldLanguage = AlchemyResources.Languages.CurrentLanguage;

           sw.ShowDialog();

           if (oldLanguage != AlchemyResources.Languages.CurrentLanguage)
           {
              //UpdateLanguageButton();

              // save
              Save();

              // reload
              Reload();
           }

           if (!UserOptions.TabToCombine)
           {
              HideSelection(m_currentSelection);
              m_currentSelection = null;
           }

           if (!UserOptions.ShowTimer)
           {
               desktopTipBottom.Content = String.Empty;
           }
        }

        private void buttonHelp_Click(object sender, RoutedEventArgs e)
        {
            elementHelpIcon.Source = m_help;
            labelHelpTop.Content = AlchemyResources.UI.HelpTitle;
            labelHelpBlock.Text =
               AlchemyResources.UI.HelpLine1 +
               AlchemyResources.UI.HelpLine2 +
               AlchemyResources.UI.HelpLine3 +
               AlchemyResources.UI.HelpLine4;
        }

        private void buttonAbout_Click(object sender, RoutedEventArgs e)
        {
            elementHelpIcon.Source = m_about;
            labelHelpTop.Content = AlchemyResources.UI.AboutTitle;
            labelHelpBlock.Text =
                string.Format(AlchemyResources.UI.AboutLine1, VersionToString()) +
                AlchemyResources.UI.AboutLine2 +
                AlchemyResources.UI.AboutLine3 +
                AlchemyResources.UI.AboutLine4 +
                AlchemyResources.UI.AboutLine5;
        }

        private void buttonHint_Click(object sender, RoutedEventArgs e)
        {
            if (m_discoveredElements.Count == AlchemyElements.Elements.Length)
                return;

            var lockedElements =
                (from element in AlchemyElements.Elements
                where !m_discoveredElements.Contains(element)
                select element).ToList();

            var lockedCombinations =
                (from combination in AlchemyCombinations.Combinations
                where !m_discoveredCombinations.Contains(combination)
                select combination).ToList();

            var desktopElements = new List<AlchemyElement>();
            foreach (var child in desktopCanvas.Children)
            {
                ElementControl ec = child as ElementControl;
                if (ec != null && !ec.AlchemyData.Terminal)
                {
                    desktopElements.Add(ec.AlchemyData);
                }
            }

            List<AlchemyCombination> hints = null;

            if (desktopElements.Count > 0)
            {
                // look first for combinations with two of the elements on the desktop
                hints = (from c in lockedCombinations
                         where desktopElements.Contains(c.InputElement1) &&
                               desktopElements.Contains(c.InputElement2)
                         select c).ToList();

                // look second for combinations that contain one element from the desktop
                // and one locked element 
                if (hints.Count == 0)
                {
                    hints = (from c in lockedCombinations
                             from el in desktopElements
                             where (c.InputElement1.ID == el.ID || c.InputElement2.ID == el.ID)
                             select c).ToList();

                    if (hints.Count >= 0)
                    {
                        hints = FilterHints(hints);
                    }
                }
                else
                {
                    hints = FilterHints(hints);
                }

                // look third for combinations with unlocked elements not present on the desktop
                if (hints.Count == 0)
                {
                    hints = (from c in lockedCombinations
                             where m_discoveredElements.Contains(c.InputElement1) &&
                                   m_discoveredElements.Contains(c.InputElement2)
                             select c).ToList();

                    if (hints.Count > 0)
                    {
                        hints = FilterHints(hints);
                    }
                }
            }
            else
            {
                // look for combinations with unlocked elements not present on the desktop
                hints = FilterHints(lockedCombinations);

                if (hints.Count > 0)
                {
                    hints = FilterHints(hints);
                }
            }

            if (hints != null && hints.Count > 0)
            {
                AlchemyCombination comb = hints.FirstOrDefault();
                if (comb != null)
                {
                    var hintwnd = new HintWindow();
                    hintwnd.ShowInTaskbar = false;
                    hintwnd.Owner = this;
                    hintwnd.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                    AlchemyElement source = null;

                    if (comb.InputElement1 != null && m_discoveredElements.Contains(comb.InputElement1) && desktopElements.Find(ec => ec.ID == comb.InputElement1.ID) != null)
                        source = comb.InputElement1;
                    else if (comb.InputElement2 != null && m_discoveredElements.Contains(comb.InputElement2) && desktopElements.Find(ec => ec.ID == comb.InputElement2.ID) != null)
                        source = comb.InputElement2;
                    else source = comb.InputElement1;

                    hintwnd.elementSource.Label = source.Name;
                    hintwnd.elementSource.LabelColor = source.Group.TextBrush;
                    hintwnd.elementSource.LabelFontWeight = FontWeights.Normal;
                    hintwnd.elementSource.Icon = source.Icon;
                    hintwnd.elementSource.AlchemyData = source;

                    AlchemyElement result = null;
                    if (comb.Result1 != null && !m_discoveredElements.Contains(comb.Result1))
                        result = comb.Result1;
                    else if (comb.Result2 != null && !m_discoveredElements.Contains(comb.Result2))
                        result = comb.Result2;
                    else if (comb.Result3 != null && !m_discoveredElements.Contains(comb.Result3))
                        result = comb.Result3;
                    else if (comb.Result4 != null && !m_discoveredElements.Contains(comb.Result4))
                        result = comb.Result4;

                    if (result != null)
                    {
                        hintwnd.elementResult.Label = result.Name;
                        hintwnd.elementResult.LabelColor = result.Group.TextBrush;
                        hintwnd.elementResult.LabelFontWeight = FontWeights.Normal;
                        hintwnd.elementResult.Icon = result.Icon;
                        hintwnd.elementResult.AlchemyData = result;

                        hintwnd.ShowDialog();
                    }
                }
            }
        }

        private void OnRemoveAnimationComplete(object sender, EventArgs args)
        {
            AnimationClock clock = sender as AnimationClock;
            if (clock != null)
            {
                if (m_elementsCounter > 0)
                {
                    --m_elementsCounter;
                    if (m_elementsCounter == 0)
                    {
                        m_animationRunning = false;
                        desktopCanvas.Children.Clear();

                        recycleImage.Source = m_recycleFull;
                        m_deleteTimer.Stop();
                        m_deleteTimer.Start();
                    }
                }
            }
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
           if (!m_animationRunning)
           {
              ShowElementHelp(null);
              m_animationRunning = true;

              foreach (var child in desktopCanvas.Children)
              {
                 var element = child as ElementControl;
                 if (element != null)
                 {
                    DoubleAnimation fade =
                        CreateDoubleAnimation(
                            1.0,
                            0.0,
                            OnRemoveAnimationComplete);

                    element.BeginAnimation(ElementControl.OpacityProperty, fade);

                    m_elementsCounter++;
                 }
              }
           }
        }

        #endregion

        #region helper methods

        private void ShowVictoryWindow()
        {
           var winwnd = new VictoryWindow();
           winwnd.ShowInTaskbar = false;
           winwnd.Owner = this;
           winwnd.WindowStartupLocation = WindowStartupLocation.CenterOwner;

           winwnd.ShowDialog();
        }

        private void ShowNextListTip()
        {
           m_tipIndexElements++;
           m_tipIndexElements = m_tipIndexElements % m_tipsElements.Length;
           nonTerminalsHint.Content = m_tipsElements[m_tipIndexElements];
        }

        private void ShowNextDesktopTip()
        {
           m_tipIndexDesktop++;
           m_tipIndexDesktop = m_tipIndexDesktop % m_tipsDesktop.Length;
           labelDesktopTipTop.Text = m_tipsDesktop[m_tipIndexDesktop];
        }

        private string VersionToString()
        {
            string appName = Assembly.GetAssembly(this.GetType()).Location;
            AssemblyName assemblyName = AssemblyName.GetAssemblyName(appName);

            if (assemblyName.Version.Build == 0)
                return String.Format("{0}.{1}", assemblyName.Version.Major, assemblyName.Version.Minor);
            else
                return String.Format("{0}.{1}.{2}", assemblyName.Version.Major, assemblyName.Version.Minor, assemblyName.Version.Build);
        }

        private void HideSelection(ElementControl element)
        {
           if (element != null)
           {
              element.SelectionMode = ElementSelection.None;
           }
        }

        private void ShowSelection(ElementControl element)
        {
           if (element != null)
           {
              element.SelectionMode = ElementSelection.ForCombining;
           }
        }

        List<AlchemyCombination> FilterHints(List<AlchemyCombination> hints)
        {
            return (from c in hints
                     where m_discoveredElements.Contains(c.InputElement1) &&
                          m_discoveredElements.Contains(c.InputElement2) &&
                          ((c.Result1 != null && !m_discoveredElements.Contains(c.Result1)) ||
                          (c.Result2 != null && !m_discoveredElements.Contains(c.Result2)) ||
                          (c.Result3 != null && !m_discoveredElements.Contains(c.Result3)) ||
                          (c.Result4 != null && !m_discoveredElements.Contains(c.Result4)))
                     select c).ToList();
        }

        DoubleAnimation CreateDoubleAnimation(double from, double to, EventHandler completedEventHandler)
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation(from, to, m_animationDuration);
            doubleAnimation.AutoReverse = false;

            if (completedEventHandler != null)
            {
                doubleAnimation.Completed += completedEventHandler;
            }

            return doubleAnimation;
        }

        private void UpdateLists()
        {
            elementsList.ItemsSource = from e in m_discoveredElements
                                           orderby e.Name
                                           select new ElementControl
                                           {
                                               Label = e.Name,
                                               LabelColor = e.Group.TextBrush,
                                               LabelFontWeight = FontWeights.Normal,
                                               Icon = e.Icon,
                                               AlchemyData = e
                                           };

            nonTerminalsLabel.Content = String.Format(
                AlchemyResources.UI.NonTerminalsHint,
                m_discoveredElements.Count,
                AlchemyElements.Elements.Length);
        }

        // Helper to search up the VisualTree
        private static T FindAnchestor<T>(DependencyObject current)
            where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }

        private void CheckCombination(ElementControl element)
        {
            Rect rg1 = new Rect(
               Canvas.GetLeft(element),
               Canvas.GetTop(element),
               element.Width,
               element.Height);

            ElementControl intersect = null;
            foreach (var child in desktopCanvas.Children)
            {
                ElementControl ec = child as ElementControl;

                if (ec != null && ec != element)
                {
                    Rect rg2 = new Rect(
                       Canvas.GetLeft(ec),
                       Canvas.GetTop(ec),
                       element.Width,
                       element.Height);

                    rg2.Intersect(rg1);
                    if (rg2.Width >= element.Width / 2 &&
                       rg2.Height >= element.Height / 2)
                    {
                        intersect = ec;
                        break;
                    }
                }
            }

            CheckAndAdd(element, intersect);
        }

        private bool CheckAndAdd(ElementControl element, ElementControl intersect)
        {
           bool added = false;

           if (intersect != null && element != null)
           {
              AlchemyCombination combination =
                 AlchemyCombinations.Combinations.Find(
                    element.AlchemyData,
                    intersect.AlchemyData);

              if (combination != null)
              {
                 if (UserOptions.CombineOnlyNew && m_discoveredCombinations.Contains(combination))
                 {
                    // do nothing if the combination was already unlocked
                 }
                 else
                 {
                    if (!m_discoveredCombinations.Contains(combination))
                       m_discoveredCombinations.Add(combination);

                    desktopCanvas.Children.Remove(element);
                    desktopCanvas.Children.Remove(intersect);

                    double elemHeight = intersect.Height;
                    double elemWidth = intersect.Width;

                    switch (combination.ResultsCount)
                    {
                       case 1:
                          {
                             double left = Canvas.GetLeft(intersect);
                             double top = Canvas.GetTop(intersect);

                             NewCanvasElement(combination.Result1, left, top);
                          }
                          break;
                       case 2:
                          {
                             double left0 = Canvas.GetLeft(intersect);
                             double left1 = left0 - elemWidth / 2 - 5;
                             double left2 = left0 + elemWidth / 2 + 5;
                             double top = Canvas.GetTop(intersect);

                             if (left1 < 0)
                                left1 = 0;
                             if (left2 + elemWidth > desktopCanvas.RenderSize.Width)
                                left2 = desktopCanvas.RenderSize.Width - elemWidth;

                             NewCanvasElement(combination.Result1, left1, top);
                             NewCanvasElement(combination.Result2, left2, top);
                          }
                          break;

                       case 3:
                          {
                             double left0 = Canvas.GetLeft(intersect) + 5;
                             double left1 = left0 - elemWidth / 2 - 10;
                             double left2 = left0 + elemWidth / 2 + 10;
                             if (left0 + intersect.Width > desktopCanvas.RenderSize.Width)
                                left0 = desktopCanvas.RenderSize.Width - elemWidth;
                             if (left1 < 0)
                                left1 = 0;
                             if (left2 + intersect.Width > desktopCanvas.RenderSize.Width)
                                left2 = desktopCanvas.RenderSize.Width - elemWidth;

                             double top0 = Canvas.GetTop(intersect);
                             if (top0 + 5 + elemHeight < desktopCanvas.RenderSize.Height)
                                top0 += 5;
                             else
                                top0 -= 5;

                             double top1 = top0;
                             if (top0 + 2 * elemHeight < desktopCanvas.RenderSize.Height)
                                top1 = top0 + elemHeight;
                             else
                                top1 = top0 - elemHeight;

                             NewCanvasElement(combination.Result1, left0, top0);
                             NewCanvasElement(combination.Result2, left1, top1);
                             NewCanvasElement(combination.Result3, left2, top1);
                          }
                          break;

                       case 4:
                          {
                             Place4Elements(
                                 combination.Result1,
                                 combination.Result2,
                                 combination.Result3,
                                 combination.Result4,
                                 Canvas.GetLeft(intersect) + 10,
                                 Canvas.GetTop(intersect) + 10,
                                 elemWidth,
                                 elemHeight);
                          }
                          break;
                    }

                    desktopTipBottom.Content = combination.ToString();
                    m_combinationShowing = true;
                    m_combinationTimer.Stop();
                    m_combinationTimer.Start();

                    added = true;
                 }
              }
           }

           return added;
        }

        private void NewCanvasElement(AlchemyElement element, double left, double top)
        {
            // create a new element
            ElementControl newelement = new ElementControl
            {
                Label = element.Name,
                LabelColor = element.Group.TextBrush,
                LabelFontWeight = FontWeights.Normal,
                Icon = element.Icon,
                AlchemyData = element
            };

            Canvas.SetLeft(newelement, left);
            Canvas.SetTop(newelement, top);

            // add the element to the canvas
            desktopCanvas.Children.Add(newelement);

            ShowElementHelp(newelement);

            if (!m_discoveredElements.Contains(element))
            {
                m_discoveredElements.Add(element);

                if (m_discoveredElements.Count == AlchemyElements.Elements.Length)
                {
                   ShowVictoryWindow();
                }

                UpdateLists();
            }
        }

        private void ShowElementHelp(ElementControl element)
        {
            if (element != null)
            {
                elementHelpIcon.Source = element.AlchemyData.Icon;
                labelHelpTop.Content = element.AlchemyData.Name;
                labelHelpBlock.Text =
                   m_discoveredCombinations.FindUnlockedCombinations(element.AlchemyData);
            }
            else
            {
                elementHelpIcon.Source = null;
                labelHelpTop.Content = string.Empty;
                labelHelpBlock.Text = string.Empty;
            }
        }

        private void Place4Elements(
            AlchemyElement e1,
            AlchemyElement e2,
            AlchemyElement e3,
            AlchemyElement e4,
            double left,
            double top,
            double elemWidth,
            double elemHeight)
        {
            double left1 = 0, top1 = 0;
            double left2 = 0, top2 = 0;
            double left3 = 0, top3 = 0;
            double left4 = 0, top4 = 0;

            if (top - elemHeight >= 0 && top + 2 * elemHeight <= desktopCanvas.RenderSize.Height)
            {
                top1 = top - elemHeight;
                top2 = top + elemHeight;
                top3 = top;
                top4 = top;
            }
            else if (top - elemHeight < 0)
            {
                top1 = top;
                top2 = top;
                top3 = top + elemHeight;
                top4 = top + elemHeight;
            }
            else if (top + 2 * elemHeight > desktopCanvas.RenderSize.Height)
            {
                top1 = top;
                top2 = top;
                top3 = top - elemHeight;
                top4 = top - elemHeight;
            }

            if (left - elemWidth >= 0 && left + 2 * elemWidth <= desktopCanvas.RenderSize.Width)
            {
                left1 = left;
                left2 = left;
                left3 = left - elemWidth;
                left4 = left + elemWidth;
            }
            else if (left - elemWidth < 0)
            {
                left1 = left;
                left2 = left + elemWidth;
                left3 = left;
                left4 = left + elemWidth;
            }
            else if (left + 2 * elemWidth > desktopCanvas.RenderSize.Width)
            {
                left1 = left;
                left2 = left - elemWidth;
                left3 = left;
                left4 = left - elemWidth;
            }

            if (top1 == top2 && left1 == left2)
            {
                if (top1 + 2 * elemHeight < desktopCanvas.RenderSize.Height)
                    top2 = top + elemHeight;
                else
                    top2 = top - elemHeight;
            }

            NewCanvasElement(e1, left1, top1);
            NewCanvasElement(e2, left2, top2);
            NewCanvasElement(e3, left3, top3);
            NewCanvasElement(e4, left4, top4);
        }

        private void PutOnTop(ElementControl control)
        {
            // find the highest z-order in the canvas
            int zorder = 0;
            ElementControl zchild = null;
            foreach (var child in desktopCanvas.Children)
            {
                ElementControl ec = child as ElementControl;
                if (ec != null)
                {
                    int z = Canvas.GetZIndex(ec);
                    if (z > zorder)
                    {
                        zorder = z;
                        zchild = ec;
                    }
                }
            }

            // set the new z-order only if it's not the same control
            if (zchild == null || zchild != control)
                Canvas.SetZIndex(control, zorder + 1);
        }

        //private void UpdateLanguageButton()
        //{
        //   languageButtonImage.Source = new BitmapImage(
        //       new Uri(String.Format("Images/Languages/{0}.png",
        //           AlchemyResources.Languages.LanguageName(
        //               AlchemyResources.Languages.CurrentLanguage,
        //               AlchemyResources.Languages.Indexes.English)),
        //               UriKind.Relative));
        //   buttonLanguageLabel.Content = AlchemyResources.Languages.CurrentLanguageName;
        //}

        private void Localize()
        {
            nonTerminalsSearchBox.LabelText = AlchemyResources.UI.NonTerminalsSearchHint;
            nonTerminalsLabel.Content = String.Format(
                AlchemyResources.UI.NonTerminalsHint,
                m_discoveredElements.Count,
                AlchemyElements.Elements.Length);
            buttonHintLabel.Content = AlchemyResources.UI.ButtonHint;
            buttonWikiLabel.Content = AlchemyResources.UI.ButtonWiki;
            buttonMoreLabel.Content = AlchemyResources.UI.ButtonMore;
            buttonHelpLabel.Content = AlchemyResources.UI.ButtonHelp;
            buttonAboutLabel.Content = AlchemyResources.UI.ButtonAbout;
            buttonClearLabel.Content = AlchemyResources.UI.ButtonClear;

            m_tipsElements = new string[] 
            { 
               AlchemyResources.UI.ElementsListHint1,
               AlchemyResources.UI.ElementsListHint2,
               AlchemyResources.UI.ElementsListHint3,
               AlchemyResources.UI.ElementsListHint4,
            };

            m_tipsDesktop = new string[]
            {
               AlchemyResources.UI.DesktopHint,
               AlchemyResources.UI.DesktopHint2,
               AlchemyResources.UI.DesktopHint3,
               AlchemyResources.UI.DesktopHint4,
               AlchemyResources.UI.DesktopHint5,
               AlchemyResources.UI.DesktopHint6,
            };

            UpdateFlowDirection();
        }

        private void Reload()
        {
           Reload(Environment.UserName + ".aus");
        }

        public void Reload(string filename)
        {
           Clear();

           if (!Load(filename))
            {
                Place4Elements(
                    AlchemyElements.Elements[ElementIndexes.Fire],
                    AlchemyElements.Elements[ElementIndexes.Air],
                    AlchemyElements.Elements[ElementIndexes.Earth],
                    AlchemyElements.Elements[ElementIndexes.Water],
                    desktopCanvas.RenderSize.Width / 2 - 32,
                    desktopCanvas.RenderSize.Height / 2 - 47,
                    64,
                    94);
            }

            UpdateLists();
            Localize();

            ShowNextListTip();
            ShowNextDesktopTip();
        }

        public void Reset()
        {
           Clear();
           m_totalElapsedSeconds = 0;

           Place4Elements(
               AlchemyElements.Elements[ElementIndexes.Fire],
               AlchemyElements.Elements[ElementIndexes.Air],
               AlchemyElements.Elements[ElementIndexes.Earth],
               AlchemyElements.Elements[ElementIndexes.Water],
               desktopCanvas.RenderSize.Width / 2 - 32,
               desktopCanvas.RenderSize.Height / 2 - 47,
               64,
               94);

           UpdateLists();
           Localize();
        }

        #endregion

        #region persistance

        public void Save(string filename)
        {
           Save(filename,
               m_discoveredElements, m_discoveredElements.Count,
               m_discoveredCombinations, m_discoveredCombinations.Count,
               desktopCanvas.Children);
        }

        private void Save()
        {
            Save(Environment.UserName + ".aus",
                m_discoveredElements, m_discoveredElements.Count,
                m_discoveredCombinations, m_discoveredCombinations.Count,
                desktopCanvas.Children);
        }

        private void Save(string filename,
            IEnumerable<AlchemyElement> elements, int noelements,
            IEnumerable<AlchemyCombination> combinations, int nocombinations,
            UIElementCollection desktopelements)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Create(filename)))
            {
                // --- HEADER ---
                // write mark
                writer.Write('A');
                writer.Write('L');
                // writer file version
                writer.Write(CurrentFileVersion);

                // version 2: write the language index
                writer.Write((int)AlchemyResources.Languages.CurrentLanguage);

                // version 3: write combine only new and tab to combine
                writer.Write(UserOptions.CombineOnlyNew);
                writer.Write(UserOptions.TabToCombine);

                // version 4: write total elapse time option and total elapsed seconds
                writer.Write(UserOptions.ShowTimer);
                writer.Write(m_totalElapsedSeconds);

                // --- UNLOCKED ELEMENTS ---
                // write count
                writer.Write(noelements);
                // write discovered elements
                foreach (var element in elements)
                {
                    writer.Write(element.ID);
                }

                // --- UNLOCKED COMBINATIONS ---
                // write count
                writer.Write(nocombinations);
                // write discovered combinations
                foreach (var combination in combinations)
                {
                    writer.Write(combination.InputElement1.ID);
                    writer.Write(combination.InputElement2.ID);
                }

                // --- DESKTOP STATE ---
                if (desktopelements == null)
                {
                    writer.Write(0);
                }
                else
                {
                    // write elements count
                    writer.Write(desktopelements.Count);
                    // write elements data
                    foreach (var child in desktopelements)
                    {
                        ElementControl element = child as ElementControl;
                        writer.Write(element.AlchemyData.ID);
                        writer.Write(Canvas.GetLeft(element));
                        writer.Write(Canvas.GetTop(element));
                        writer.Write(Canvas.GetZIndex(element));
                    }
                }
            }
        }

        private bool Load(string filename)
        {
            AlchemyElementGroup[] groups = AlchemyElementGroups.Groups;
            AlchemyElement[] elements = AlchemyElements.Elements;

            bool loadedOK = false;
            try
            {
               // if user data exists, load it
               if (File.Exists(filename))
               {
                  using (BinaryReader reader = new BinaryReader(File.OpenRead(filename)))
                  {
                     char c1 = reader.ReadChar();
                     char c2 = reader.ReadChar();
                     if (c1 == 'A' && c2 == 'L')
                     {
                        // read file version
                        int fileVersion = reader.ReadInt32();

                        if (fileVersion >= 2)
                        {
                           // version 2: read language
                           AlchemyResources.Languages.CurrentLanguage = reader.ReadInt32();
                        }
                        if (fileVersion >= 3)
                        {
                           // version 3: read combine only new and tab to combine
                           UserOptions.CombineOnlyNew = reader.ReadBoolean();
                           UserOptions.TabToCombine = reader.ReadBoolean();
                        }
                        if (fileVersion >= 4)
                        {
                           // version 4: read show timer and total elapsed time
                           UserOptions.ShowTimer = reader.ReadBoolean();
                           m_totalElapsedSeconds = reader.ReadInt32();
                        }
                        else 
                        {
                           // enable timer show by default
                           UserOptions.ShowTimer = true;
                        }

                        // --- UNLOCKED ELEMENTS ---
                        // read count
                        int elementsCount = reader.ReadInt32();
                        // read the elements
                        for (int i = 0; i < elementsCount; ++i)
                        {
                           int id = reader.ReadInt32();
                           if (id < elements.Length)
                           {
                              m_discoveredElements.Add(elements[id]);
                           }
                        }

                        // --- UNLOCKED COMBINATIONS ---
                        // read count
                        int combinationsCount = reader.ReadInt32();
                        // read combinations
                        for (int i = 0; i < combinationsCount; ++i)
                        {
                           int id1 = reader.ReadInt32();
                           int id2 = reader.ReadInt32();

                           AlchemyCombination combination = AlchemyCombinations.Combinations.Find(id1, id2);
                           if (combination != null)
                           {
                              m_discoveredCombinations.Add(combination);
                           }
                        }

                        // --- DESKTOP STATE ---
                        // read count
                        int desktopCount = reader.ReadInt32();
                        for (int i = 0; i < desktopCount; ++i)
                        {
                           int id = reader.ReadInt32();
                           double left = reader.ReadDouble();
                           double top = reader.ReadDouble();
                           int zindex = reader.ReadInt32();

                           if (id < elements.Length)
                           {
                              ElementControl newcontrol = new ElementControl()
                              {
                                 Label = elements[id].Name,
                                 LabelColor = elements[id].Group.TextBrush,
                                 LabelFontWeight = FontWeights.Normal,
                                 Icon = elements[id].Icon,
                                 AlchemyData = elements[id]
                              };

                              if (left > desktopCanvas.ActualWidth)
                                 left = desktopCanvas.ActualWidth - newcontrol.Width;
                              if (top > desktopCanvas.ActualHeight)
                                 top = desktopCanvas.ActualHeight - newcontrol.Height;

                              Canvas.SetLeft(newcontrol, left);
                              Canvas.SetTop(newcontrol, top);
                              Canvas.SetZIndex(newcontrol, zindex);

                              desktopCanvas.Children.Add(newcontrol);
                           }
                        }

                        loadedOK = true;
                     }
                  }
               }
            }
            catch (Exception)
            {
            }

            // start from scratch
            if (!loadedOK)
            {
                m_discoveredElements.Clear();
                m_discoveredCombinations.Clear();

                // fire, water, air, earth
                m_discoveredElements.Add(elements[ElementIndexes.Fire]);
                m_discoveredElements.Add(elements[ElementIndexes.Water]);
                m_discoveredElements.Add(elements[ElementIndexes.Air]);
                m_discoveredElements.Add(elements[ElementIndexes.Earth]);

                // show timer by default
                UserOptions.ShowTimer = true;
            }

            return loadedOK;
        }

        private void Clear()
        {
           // clear
           m_discoveredElements.Clear();
           m_discoveredCombinations.Clear();
           desktopCanvas.Children.Clear();
           elementsList.ItemsSource = null;
           ShowElementHelp(null);
        }

        private void UpdateFlowDirection()
        {
           labelHelp.FlowDirection = AlchemyResources.Languages.CurrentFlowDirection;
           nonTerminalsSearchBox.FlowDirection = AlchemyResources.Languages.CurrentFlowDirection;
           nonTerminalsLabel.FlowDirection = AlchemyResources.Languages.CurrentFlowDirection;
           nonTerminalsHint.FlowDirection = AlchemyResources.Languages.CurrentFlowDirection;
           desktopTipTop.FlowDirection = AlchemyResources.Languages.CurrentFlowDirection;
           labelHelpTop.FlowDirection = AlchemyResources.Languages.CurrentFlowDirection;
        }

        #endregion

        #region devtools

        [Conditional("DEBUG")]
        private void SaveAll()
        {
            Save("alchemy.aus",
                AlchemyElements.Elements, AlchemyElements.Elements.Length,
                AlchemyCombinations.Combinations, AlchemyCombinations.Combinations.Length,
                null);
        }

        [Conditional("DEBUG")]
        private void CheckCombinations()
        {
            var query = (from c in AlchemyCombinations.Combinations
                        where c.InputElement1.Terminal || c.InputElement2.Terminal
                        select new
                        {
                            Name = c.InputElement1.Terminal ? c.InputElement1.Name : c.InputElement2.Name
                        }).ToList();

            if(query.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("The following elements should not be terminals: ");
                foreach(var o in query)
                    sb.AppendLine(o.Name);

                MessageBox.Show(sb.ToString());
            }
        }

        [Conditional("DEBUG")]
        private void CheckElements()
        {
           Dictionary<int, AlchemyElement> nonterminals = new Dictionary<int, AlchemyElement>();
           foreach (var combination in AlchemyCombinations.Combinations)
           {
              if (!nonterminals.ContainsKey(combination.InputElement1.ID))
                 nonterminals[combination.InputElement1.ID] = combination.InputElement1;
              if (!nonterminals.ContainsKey(combination.InputElement2.ID))
                 nonterminals[combination.InputElement2.ID] = combination.InputElement2;
           }

           StringBuilder sb = new StringBuilder();
           int total = 0;
           sb.AppendLine("The following elements should be terminals: ");
           foreach (var e in AlchemyElements.Elements.Where(x => !x.Terminal))
           {
              if (!nonterminals.ContainsKey(e.ID))
              {
                 sb.AppendLine(e.Name);
                 total++;
              }
           }
           if(total > 0)
              MessageBox.Show(sb.ToString());
        }

        #endregion

    }
}
