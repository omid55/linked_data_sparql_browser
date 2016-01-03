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
using VDS.RDF;
using VDS.RDF.Query;
using VDS.RDF.Writing;
using VDS.RDF.Writing.Formatting;
using VDS.RDF.Parsing;

namespace RdfUsing
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private Graph myGraph;
        private string dbpeidaNtFileName = "dbpediaTriples.nt";

        public Window1()
        {
            InitializeComponent();

            init();
        }

        public void initComboFromDbPedia()
        {
            //Connect To DBPedia
            SparqlRemoteEndpoint endpoint = new SparqlRemoteEndpoint(new Uri("http://dbpedia.org/sparql"));

            String query = "DESCRIBE ?t WHERE {?a ?t ?b}";

            endpoint.QueryWithResultGraph(query);

            foreach (var result in myGraph.Triples)
            {
                TypesComboBox.Items.Add(result.ToString());
            }
        }

        public void init()
        {
            if (myGraph == null)
            {
                initGraph();
            }

            String sparqlQuery = "SELECT DISTINCT ?t WHERE {?a ?t ?b}";

            SparqlResultSet results = (SparqlResultSet)myGraph.ExecuteQuery(sparqlQuery);

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

        public void initGraph()
        {
            myGraph = new Graph();

            UriNode omid = myGraph.CreateUriNode(new Uri("http://www.omidey.co.cc"));
            UriNode says = myGraph.CreateUriNode(new Uri("http://www.sample.com/says"));
            LiteralNode hello = myGraph.CreateLiteralNode("Hello World!!!");
            LiteralNode sallam = myGraph.CreateLiteralNode("Sallam 2nyaaa!!!", "fa");

            LiteralNode a = myGraph.CreateLiteralNode("A");
            // must be uri for being serializable and for that we can save it
            LiteralNode b = myGraph.CreateLiteralNode("B");
            LiteralNode c = myGraph.CreateLiteralNode("C");

            LiteralNode aa = myGraph.CreateLiteralNode("omid");
            // must be uri for being serializable and for that we can save it
            LiteralNode bb = myGraph.CreateLiteralNode("hast");
            LiteralNode cc = myGraph.CreateLiteralNode("askari");

            myGraph.Assert(new Triple(omid, says, hello));
            myGraph.Assert(new Triple(omid, says, sallam));
            myGraph.Assert(new Triple(a, b, c));
            myGraph.Assert(new Triple(aa, bb, cc));
        }

        public void saveGraph(IGraph g, IRdfWriter w, String fileName)
        {
            if (w is IPrettyPrintingWriter)
            {
                ((IPrettyPrintingWriter)w).PrettyPrintMode = true;
            }

            if (w is IHighSpeedWriter)
            {
                ((IHighSpeedWriter)w).HighSpeedModePermitted = true;
            }

            if (w is ICompressingWriter)
            {
                ((ICompressingWriter)w).CompressionLevel = WriterCompressionLevel.High;
            }

            w.Save(g, fileName);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            // Connect To DBPedia
            //First define a SPARQL Endpoint for DBPedia
            SparqlRemoteEndpoint endpoint = new SparqlRemoteEndpoint(new Uri("http://dbpedia.org/sparql"));

            //Next define our query
            //We're going to ask DBPedia to describe the first thing it finds which is a Person
            String query = "DESCRIBE ?person WHERE {?person a <http://dbpedia.org/ontology/Person>} LIMIT 1";

            //Get the result
            Graph g = endpoint.QueryWithResultGraph(query);

            FastRdfXmlWriter rxtw = new FastRdfXmlWriter();
            rxtw.Save(g, "dbp.txt");

            //foreach (Triple t in g.Triples)
            //{
            //    MessageBox.Show(t.ToString());
            //}

            ////String query = "SELECT ?n ?p WHERE {?n ?p 'Hello World!!!'}";  // like select * => "SELECT ?n ?p ?m WHERE {?n ?p ?m}"
            ////SparqlResultSet res = (SparqlResultSet)myGraph.ExecuteQuery(query);
            ////foreach (SparqlResult r in res)
            ////{
            ////    MessageBox.Show(r.ToString());
            ////}

            ////FastRdfXmlWriter rxtw = new FastRdfXmlWriter();
            ////rxtw.Save(myGraph, "omid.txt");

            //TripleStore ts = new TripleStore();
            //Object res = ts.ExecuteQuery("SELECT * WHERE {?s ?p ?o}");
            //if (res is SparqlResultSet)
            //{
            //    SparqlResultSet results = (SparqlResultSet)res;
            //    foreach (SparqlResult sr in results)
            //    {
            //        Console.WriteLine(sr.ToString());
            //    }
            //}
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            SparqlQueryParser sqp = new SparqlQueryParser();
            string query = null;
            if (TypesComboBox.SelectedValue.ToString().TrimEnd().Length != 0 && SearchTextBox.Text.TrimEnd().Length != 0)
            {
                query = "SELECT ?o WHERE {<" + SearchTextBox.Text + "> <" + TypesComboBox.SelectedValue + "> ?o}";
            }
            else if (TypesComboBox.SelectedValue.ToString().TrimEnd().Length == 0 &&
                     SearchTextBox.Text.TrimEnd().Length != 0)
            {
                query = "SELECT ?o WHERE {<" + SearchTextBox.Text + "> ?t ?o}";
            }
            else if (TypesComboBox.SelectedValue.ToString().TrimEnd().Length != 0 &&
                     SearchTextBox.Text.TrimEnd().Length == 0)
            {
                query = "SELECT ?o WHERE {?s <" + TypesComboBox.SelectedValue + "> ?o}";
            }
            else if (TypesComboBox.SelectedValue.ToString().TrimEnd().Length == 0 &&
                     SearchTextBox.Text.TrimEnd().Length == 0)
            {
                query = "SELECT ?o WHERE {?s ?t ?o}";
            }
            SparqlQuery sparqlQuery = sqp.ParseFromString(query);
            SparqlResultSet results = (SparqlResultSet)myGraph.ExecuteQuery(sparqlQuery);
            foreach (var result in results)
            {
                MessageBox.Show(result.ToString());
            }
            MessageBox.Show("Query Executed In " + sparqlQuery.QueryTime + " ms");
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            // Connect To DBPedia
            //First define a SPARQL Endpoint for DBPedia
            SparqlRemoteEndpoint endpoint = new SparqlRemoteEndpoint(new Uri("http://dbpedia.org/sparql"));

            //Next define our query
            //We're going to ask DBPedia to describe the first thing it finds which is a Person
            String query = "SELECT ?n ?p ?m WHERE {?n ?p ?m} LIMIT 3";
            //"SELECT ?person WHERE {?person a <http://dbpedia.org/ontology/Person>} LIMIT 10";

            SparqlResultSet results = endpoint.QueryWithResultSet(query);
            foreach (var res in results)
            {
                MessageBox.Show(res.ToString());
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SparqlRemoteEndpoint sre = new SparqlRemoteEndpoint(new Uri("http://dbpedia.org/sparql"));
                string query = QueryTextBox.Text;
                myGraph = sre.QueryWithResultGraph(query);

                NTriplesWriter wr = new NTriplesWriter();
                wr.Save(myGraph, dbpeidaNtFileName);

                MessageBox.Show("Saved","Done",MessageBoxButton.OK,MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR4", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NTriplesParser ntp = new NTriplesParser();
                myGraph = new Graph();
                ntp.Load(myGraph, dbpeidaNtFileName);

                MessageBox.Show("Loaded", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR5", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BrowserWindow bw = new BrowserWindow();
                bw.myGraph = myGraph;
                bw.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Message");
                MessageBox.Show(ex.StackTrace, "Stack Trace");
            }
        }

        private void ExecButton_Click(object sender, RoutedEventArgs e)
        {
            // ?? operator 
            //string x = null;
            //string y = null;
            //// z = x, unless x is null, in which case z = y and unless y is null, in that case z="sallam"
            //string z = x ?? y ?? "sallam";

            
            try
            {
                String query = SparlQueryTextBox.Text;
                SparqlResultSet results = (SparqlResultSet)myGraph.ExecuteQuery(query);
                foreach (var res in results)
                {
                    MessageBox.Show(res.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR3", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            init();
        }
    }
}