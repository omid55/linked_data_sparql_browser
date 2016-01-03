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
using Microsoft.Win32;
using VDS.RDF.Parsing;
using VDS.RDF.Query;
using VDS.RDF;

namespace MyRdfBrowserUserControl
{
    /// <summary>
    /// Interaction logic for ConnectToWebWindow.xaml
    /// </summary>
    public partial class ConnectToWebWindow : Window
    {
        #region Fields

        private BrowsingConfig config;

        #endregion


        #region Methods

        public void setConfig(ref BrowsingConfig g)
        {
            config = g;
        }

        public BrowsingConfig getMyGraph()
        {
            return config;
        }

        public ConnectToWebWindow()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.CurrentDirectory;
            ofd.Filter = "RDF Files (*.rdf)|*.rdf|Turtle Files (*.ttl)|*.ttl|All Files (*.*)|*.*";
            if(ofd.ShowDialog().Value)
            {
                PathTextBox.Text = ofd.FileName;
            }
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (RemoteRadio.IsChecked != null)
                {
                    if (RemoteRadio.IsChecked.Value) // Remote Endpoint Mode
                    {
                        config.endpoint = new SparqlRemoteEndpoint(new Uri(UrlTextBox.Text));

                        MessageBox.Show("Application Connected To Endpoint Successfully", "Connected", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else // File Mode
                    {
                        config.endpoint = null;

                        NTriplesParser ntp = new NTriplesParser();
                        config.myGraph.Clear();
                        ntp.Load(config.myGraph, PathTextBox.Text);

                        MessageBox.Show("Graph Loaded From File Successfully", "Connected", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR6", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RemoteRadio_Checked(object sender, RoutedEventArgs e)
        {
            RemoteWrap.IsEnabled = true;
            FileWrap.IsEnabled = false;
        }

        private void FileRadio_Checked(object sender, RoutedEventArgs e)
        {
            RemoteWrap.IsEnabled = false;
            FileWrap.IsEnabled = true;
        }

        #endregion
    }
}