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
using SpartaHack.MVVM;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SpartaHack
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MapPage : Page
    {
        public ObservableValue<List<BitmapImage>> File { get; set; }
        public ObservableValue<string> SelectedPage { get; set; }
        public MapPage()
        {
            this.InitializeComponent();
            MainPage.Title.Value = "Map";
           
            File = new ObservableValue<List<BitmapImage>>();
            SelectedPage = new ObservableValue<string>();
            DataContext = this;
            renderPDF();
        }

        async void renderPDF()
        {
            try
            {
                
                StorageFile file = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(@"LocalFiles\SpartaHack17-map.pdf");
                PdfDocument pdf = await PdfDocument.LoadFromFileAsync(file);


                List<BitmapImage> images = new List<BitmapImage>();
                //pageCount = pdf.PageCount;
                for (uint pageNum = 0; pageNum < pdf.PageCount; pageNum++)
                {
                    PdfPage page = pdf.GetPage(pageNum);

                    InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream();
                    await page.RenderToStreamAsync(stream);

                    BitmapImage source = new BitmapImage();
                    source.SetSource(stream);

                    images.Add(source);

                }
                File.Value = images;
              
            }
            catch { }
        }

        private void flpView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedPage.Value = $"{flpView.SelectedIndex+1} / {File.Value.Count}";
        }
    }
}
