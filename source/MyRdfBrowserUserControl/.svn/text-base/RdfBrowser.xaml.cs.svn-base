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
using MyRdfResultControl;
using VDS.RDF.Query;
using VDS.RDF.Parsing;
using VDS.RDF;
using VDS.RDF.Writing;
using Microsoft.Win32;
using System.ComponentModel;
using System.Threading;

namespace MyRdfBrowserUserControl
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class RdfBrowser : UserControl
    {
        #region Fields

        private BrowsingConfig config;
        private int currentUriIndex = 0;

        private const int POPUP_QUERY_LIMIT = 10;

        #endregion


        #region Methods

        public RdfBrowser()
        {
            InitializeComponent();

            config = new BrowsingConfig();
            MyRdfRes.setResultSet(new SparqlResultSet());
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            loadingPopup.StaysOpen = false;
            loadingPopup.IsOpen = false;
            popLink.IsOpen = true;
            popLink.StaysOpen = true;
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            string address = (string)e.Argument;
            this.Dispatcher.Invoke(new Action(() => browseThisAddress(address, MyRdfResInPopup,true)));
        }

        public void setConfig(ref BrowsingConfig g)
        {
            config = g;
        }

        public BrowsingConfig getConfig()
        {
            return config;
        }

        // for runing and set an address of entity from outside of RdfBrowser class 
        public void browseThisAddress(String address, MyWpfRdfResultControl _RdfRes, bool isPopup)
        {
            browseFunction(_RdfRes, address,isPopup);
        }

        public void navigateTo()
        {
            string browse = browseComboBox.Text.TrimEnd();
            if (browseComboBox.Items.Contains(browse))
            {
                browseComboBox.Items.Remove(browse);
            }
            browseComboBox.Items.Insert(0, browse);

            browseFunction(MyRdfRes, browse,false);
        }

        public void navigateTo(String address)
        {
            browseComboBox.Text = address;
            navigateTo();
        }

        public void browseFunction(MyWpfRdfResultControl _RdfRes, String browse,bool isPopup)
        {
            if (browse == null)
                return;

            try
            {
                SparqlQueryParser sqp = new SparqlQueryParser();
                string query = null;
                int len = TypesComboBox.Text.Length;
                if (len != 0 && browse.Length != 0)
                {
                    query = "SELECT * WHERE { {<" + browse + "> <" + TypesComboBox.Text + "> ?object} UNION {?subject <" + TypesComboBox.Text + "> <" + browse + ">} } ORDER BY ?object";
                }
                else if (len == 0 && browse.Length != 0)
                {
                    query = "SELECT * WHERE { {?subject ?type <" + browse + ">} UNION {<" + browse + "> ?type ?object} } ORDER BY ?type";
                }
                else if (len != 0 && browse.Length == 0)
                {
                    query = "SELECT * WHERE {?subject <" + TypesComboBox.Text + "> ?object} ORDER BY ?subject ?object";
                }
                else if (len == 0 && browse.Length == 0)
                {
                    query = "SELECT * WHERE {?subject ?type ?object} ORDER BY ?subject ?type ?object LIMIT 20";
                }

                if(isPopup)
                {
                    query += " LIMIT " + POPUP_QUERY_LIMIT;
                }

                SparqlQuery sparqlQuery = sqp.ParseFromString(query);
                SparqlResultSet results = null;

                if (config.endpoint != null)
                {
                    results = config.endpoint.QueryWithResultSet(query);
                }
                else
                {
                    results = (SparqlResultSet)config.myGraph.ExecuteQuery(sparqlQuery);
                }

                _RdfRes.setResultSet(results);
                _RdfRes.Href_Click = Href_Click;
                _RdfRes._popUp = popLink;

                if (config.types == BrowsingType.RdfBrowsing)
                {
                    _RdfRes.initForRdfTypeBrowing();
                }
                else      // BrowsingType.TriplesBrowsing
                {
                    _RdfRes.initForTripleBrowing();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR1", MessageBoxButton.OK, MessageBoxImage.Error);
                MessageBox.Show(ex.StackTrace, "ERROR1(StackTrace)", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void initTypesComboBox()
        {
            String sparqlQuery = "SELECT ?t WHERE {?a ?t ?b} LIMIT 10";
            SparqlResultSet results = null;

            if (config.endpoint != null)
            {
                results = config.endpoint.QueryWithResultSet(sparqlQuery);
            }
            else
            {
                results = (SparqlResultSet)config.myGraph.ExecuteQuery(sparqlQuery);
            }

            TypesComboBox.Items.Clear();
            TypesComboBox.Items.Add("");

            foreach (var result in results)
            {
                TypesComboBox.Items.Add(result.Value("t"));
            }

            if (results.Count > 0)
            {
                TypesComboBox.SelectedIndex = 0;
            }
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            navigateTo();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            init();
        }

        public void init()
        {
            initTypesComboBox();

            if (browseComboBox.Items.Count == 0)
            {
                browseComboBox.Items.Add("");
            }
        }

        public void Href_Click(object sender, MouseButtonEventArgs e)
        {
            Run _run = ((Run)e.Source);
            navigateTo(_run.Text);
        }

        #endregion

        private void Connect2WebButton_Click(object sender, RoutedEventArgs e)
        {
            ConnectToWebWindow con = new ConnectToWebWindow();
            con.setConfig(ref config);
            con.ShowDialog();
            initTypesComboBox();   // << CHECK HERE UNCOMMENT THIS LINE >>
        }

        private void SaveGraphButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.InitialDirectory = Environment.CurrentDirectory;
                sfd.Filter = "RDF Files (*.rdf)|*.rdf|Turtle Files (*.ttl)|*.ttl|All Files (*.*)|*.*";
                if (sfd.ShowDialog().Value)
                {
                    string savePath = sfd.FileName;

                    NTriplesWriter wr = new NTriplesWriter();
                    wr.Save(config.myGraph, savePath);

                    MessageBox.Show("Your Current Graph Saved Successfully", "Save Graph", MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR2", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void browseComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                navigateTo();
            }
        }

        private void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentUriIndex > 0)
            {
                browseComboBox.SelectedIndex = --currentUriIndex;
                browseFunction(MyRdfRes, browseComboBox.SelectedItem.ToString(),false);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentUriIndex < browseComboBox.Items.Count - 1)
            {
                browseComboBox.SelectedIndex = ++currentUriIndex;
                browseFunction(MyRdfRes, browseComboBox.SelectedItem.ToString(),false);
            }
        }

        private void popLink_MouseLeave(object sender, MouseEventArgs e)
        {
            popLink.StaysOpen = false;
            popLink.IsOpen = false;
            popLink.IsEnabled = false;
        }

        private void popLink_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            loadingPopup.IsOpen = true;
            loadingPopup.StaysOpen = true;
            String address = (String)popLink.Tag;
            BackgroundWorker _worker = new BackgroundWorker();
            _worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            _worker.RunWorkerAsync(address);
        }
    }
}
