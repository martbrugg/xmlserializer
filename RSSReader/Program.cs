// See https://aka.ms/new-console-template for more information
using RSSReader;

Console.WriteLine("Hello, World!");

string rssUrl = "https://www.derstandard.at/rss";
var reader = new RssReader();
reader.ReadRSS(rssUrl);
