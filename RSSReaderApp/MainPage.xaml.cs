
using RSSReaderLib;

namespace RSSReaderApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            this.BindingContext = new MainViewModel();
        }


        private void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            RssItem item = args.SelectedItem as RssItem;
            this.OpenPage(item.Link);
            
        }

        async Task OpenPage(string link)
        {
            try
            {
                Uri uri = new Uri(link);
                await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                // An unexpected error occurred. No browser may be installed on the device.
            }
        }
    }
}