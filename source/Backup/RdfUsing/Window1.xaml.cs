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

namespace RdfUsing
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        public void saveGraph(IGraph g,IRdfWriter w,String fileName)
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
            /* Connect To DBPedia
            //First define a SPARQL Endpoint for DBPedia
            SparqlRemoteEndpoint endpoint = new SparqlRemoteEndpoint(new Uri("http://dbpedia.org/sparql"));

            //Next define our query
            //We're going to ask DBPedia to describe the first thing it finds which is a Person
            String query = "DESCRIBE ?person WHERE {?person a <http://dbpedia.org/ontology/Person>} LIMIT 1";

            //Get the result
            Graph g = endpoint.QueryWithResultGraph(query);

            FastRdfXmlWriter rxtw = new FastRdfXmlWriter();
            rxtw.Save(g, "dbp.txt");*/


            Graph g = new Graph();

            UriNode omid = g.CreateUriNode(new Uri("http://www.omidey.co.cc"));
            UriNode says = g.CreateUriNode(new Uri("http://www.sample.com/says"));
            LiteralNode hello = g.CreateLiteralNode("Hello World!!!");
            LiteralNode sallam = g.CreateLiteralNode("Sallam 2nyaaa!!!", "fa");

            g.Assert(new Triple(omid, says, hello));
            g.Assert(new Triple(omid, says, sallam));

            //foreach (Triple t in g.Triples)
            //{
            //    MessageBox.Show(t.ToString());
            //}

            String query = "SELECT ?n ?p WHERE {?n ?p 'Hello World!!!'}";  // like select * => "SELECT ?n ?p ?m WHERE {?n ?p ?m}"
            SparqlResultSet res = (SparqlResultSet)g.ExecuteQuery(query);
            foreach (SparqlResult r in res)
            {
                MessageBox.Show(r.ToString());
            }

            FastRdfXmlWriter rxtw = new FastRdfXmlWriter();
            rxtw.Save(g, "omid.txt");

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
    }
}
