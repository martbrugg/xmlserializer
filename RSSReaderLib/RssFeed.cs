using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RSSReaderLib
{
    // Classes for deserialization
    public class RssFeed
    {
        public RssChannel Channel { get; set; }
    }

    public class RssChannel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        public List<RssItem> Items { get; set; }
    }

    public class RssItem
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        public string PubDate { get; set; }
    }
}
