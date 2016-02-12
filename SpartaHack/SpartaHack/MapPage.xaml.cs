using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Net.Http;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Data.Pdf;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SpartaHack
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MapPage : Page
    {
        uint pageCount = 0;
        public MapPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            MainPage.title.Value = "MAP";
            renderPDF();
        }

        async void renderPDF()
        {
            try
            {

                HttpClient client = new HttpClient();

                Stream s = await client.GetStreamAsync("http://www.spartahack.com/map.pdf");
            MemoryStream ms = new MemoryStream();
            await s.CopyToAsync(ms);
            ms.Position = 0;

                // StorageFile file = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(@"PDFs\ios-map.pdf");
                // PdfDocument pdf = await PdfDocument.LoadFromFileAsync(file);
                PdfDocument pdf = await PdfDocument.LoadFromStreamAsync(ms.AsRandomAccessStream());
               
                List<BitmapImage> images = new List<BitmapImage>();
                pageCount = pdf.PageCount;
                for (uint pageNum = 0; pageNum < pdf.PageCount; pageNum++)
                {
                    PdfPage page = pdf.GetPage(pageNum);

                    InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream();
                    await page.RenderToStreamAsync(stream);

                    BitmapImage source = new BitmapImage();
                    source.SetSource(stream);

                    images.Add(source);

                }
                Pdfs.Source = images;
                pgrRing.IsActive = false;
        }
            catch { }
        }

        private void flpView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                txtPage.Text = (flpView.SelectedIndex + 1).ToString() + "/" + pageCount.ToString();
            }
            catch { }
        }
    }
}
