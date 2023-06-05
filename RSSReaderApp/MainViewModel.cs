using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RSSReaderLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RSSReaderApp
{
    partial class MainViewModel : ObservableObject
    {

        [ObservableProperty]
        private RssFeed feed;
        [ObservableProperty]
        private string rssUrl = "https://www.derstandard.at/rss";
        [ObservableProperty]
        private string channelTitle = "No Title";
        [ObservableProperty]
        private List<RssItem> items;

        [ObservableProperty]
        private string btnLoadText = "Laden";
        public MainViewModel()
        {
        }

        [RelayCommand]

        private void LoadFeed()
        {
            string rssUrl = "https://www.derstandard.at/rss";
            var reader= new RssReader();
            reader.ReadRSS(this.RssUrl);
            this.Feed = reader.Feed;
            this.ChannelTitle = this.Feed.Channel.Title;
            this.Items = this.Feed.Channel.Items;
        }
    }
}
