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
using VDS.RDF;
using MyRdfBrowserUserControl;
using RdfUsing;

namespace RdfUsing
{
    /// <summary>
    /// Interaction logic for BrowserWindow.xaml
    /// </summary>
    public partial class BrowserWindow : Window
    {
        #region Fields

        private int tabNumber;
        private bool tabClosing;

        #endregion


        #region Properties

        public Graph myGraph { get; set; }

        #endregion


        #region Methods

        public BrowserWindow()
        {
            InitializeComponent();

            tabNumber = 2;
            tabClosing = false;
        }

        private void TabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tabClosing)
            {
                tabClosing = false;
                return;
            }

            TabItem addItemTab = (TabItem)myTabControl.Items.GetItemAt(myTabControl.Items.Count - 1);
            myTabControl.Items.RemoveAt(myTabControl.Items.Count - 1);
            TabItem item = new TabItem();
            RdfBrowser brw = new RdfBrowser();
            brw.getConfig().myGraph = myGraph;
            if (TripleRadio.IsChecked != null && TripleRadio.IsChecked.Value)
            {
                brw.getConfig().types = BrowsingType.TriplesBrowsing;
            }
            else
            {
                brw.getConfig().types = BrowsingType.RdfBrowsing;
            }
            item.Content = brw;
            item.Background = Brushes.Bisque;
            item.Header = "RDF Browser " + tabNumber++;   //+ (myTabControl.Items.Count + 1);
            myTabControl.Items.Add(item);
            myTabControl.Items.Add(addItemTab);
            ((TabItem)myTabControl.Items[myTabControl.Items.Count - 2]).IsSelected = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            myBrowser.getConfig().myGraph = myGraph;
            setBrowsingTypeForBrowser();
        }

        private void AddTab_Click(object sender, RoutedEventArgs e)
        {
            TabItem_GotFocus(null, null);
        }

        private void CloseTab_Click(object sender, RoutedEventArgs e)
        {
            if (myTabControl.Items.Count == 2) return;   // more than two tabs can exit (note that + is a tab too)

            tabClosing = true;
            myTabControl.Items.RemoveAt(myTabControl.SelectedIndex);
            ((TabItem)myTabControl.Items[myTabControl.Items.Count - 2]).IsSelected = true;
        }

        private void NewTabMenuItem_Click(object sender, RoutedEventArgs e)
        {
            TabItem_GotFocus(null, null);
        }

        private void CloseTabMenuItem_Click(object sender, RoutedEventArgs e)
        {
            CloseTab_Click(null, null);
        }

        private void TypesRadio_Checked(object sender, RoutedEventArgs e)
        {
            setBrowsingTypeForBrowser();
        }

        public void setBrowsingTypeForBrowser()
        {
            if (myBrowser == null) return; // it means window is not loaded yet

            RdfBrowser _browser = ((RdfBrowser) ((TabItem) myTabControl.SelectedItem).Content);

            if (_browser == null) return;

            if (TripleRadio.IsChecked != null && TripleRadio.IsChecked.Value)
            {
                _browser.getConfig().types = BrowsingType.TriplesBrowsing;
            }
            else
            {
                _browser.getConfig().types = BrowsingType.RdfBrowsing;
            }
        }

        //private void BrowseTypeMenuItem_Click(object sender, RoutedEventArgs e)
        //{
        //    if ((MenuItem)sender == BrowseTriplesMenuItem)
        //        BrowseRdfMenuItem.IsChecked = !BrowseTriplesMenuItem.IsChecked;
        //    else
        //        BrowseTriplesMenuItem.IsChecked = !BrowseRdfMenuItem.IsChecked;
        //}

        #endregion
    }
}
