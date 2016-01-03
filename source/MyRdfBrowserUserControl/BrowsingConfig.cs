using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VDS.RDF;
using VDS.RDF.Query;

namespace MyRdfBrowserUserControl
{
    public class BrowsingConfig
    {
        public Graph myGraph { get; set; }
        public SparqlRemoteEndpoint endpoint { get; set; }
        public BrowsingType types { get; set; }

        public BrowsingConfig()
        {
            endpoint = null;
            myGraph = new Graph();
            types = BrowsingType.TriplesBrowsing;
        }
    }
}