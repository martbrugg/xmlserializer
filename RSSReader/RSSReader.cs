using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;

namespace RSSReader
{
    public class RssReader
    {
        public void ReadRSS(string url)
        {
            try
            {
                // Download the RSS feed XML
                string xmlString;
                using (var webClient = new WebClient())
                {
                    xmlString = webClient.DownloadString(url);
                }

                // Create an XML reader
                parseXMLSimple(xmlString);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private RssFeed parseXMLSimple(string xmlString)
        {
            var feed = new RssFeed();
            // Parse the XML string into an XElement
            var xml = XElement.Parse(xmlString);

            // Access the RSS elements using LINQ to XML
            var channelElement = xml.Element("channel");

            
            if (channelElement != null)
            {   
                // Access the channel elements
                var title = channelElement.Element("title")?.Value;
                var description = channelElement.Element("description")?.Value;
                var link = channelElement.Element("link")?.Value;

                // Print the channel information
                Console.WriteLine($"Title: {title}");
                Console.WriteLine($"Description: {description}");
                Console.WriteLine($"Link: {link}");

                feed.Channel = new RssChannel()
                {
                    Title = title,
                    Description = description,
                    Link = link,
                    Items = new List<RssItem>()
                };

                // Access the item elements
                var itemElements = channelElement.Elements("item");
                
                Console.WriteLine("Items:");
                foreach (var itemElement in itemElements)
                {
                    var itemTitle = itemElement.Element("title")?.Value;
                    var itemDescription = itemElement.Element("description")?.Value;
                    var itemLink = itemElement.Element("link")?.Value;
                    var itemPubDate = itemElement.Element("pubDate")?.Value;

                    RssItem item = new RssItem()
                    {
                        Title = itemTitle,
                        Description = itemDescription,
                        Link = itemLink,
                        PubDate = itemPubDate
                    };
                    feed.Channel.Items.Add(item);

                    // Print the item information
                    Console.WriteLine($"- Title: {itemTitle}");
                    Console.WriteLine($"  Description: {itemDescription}");
                    Console.WriteLine($"  Link: {itemLink}");
                    Console.WriteLine($"  PubDate: {itemPubDate}");
                }
            }
        }
    }
}
