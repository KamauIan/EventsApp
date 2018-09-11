using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace EventoApp.ViewModels
{
    class Configuration
    {
        public partial class CreateEventView : Page
        {
            public static void DisplayResult(Image image, StorageItemThumbnail thumbnail)
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.SetSource(thumbnail);
                image.Source = bitmapImage;

            }
        }

    }
}
