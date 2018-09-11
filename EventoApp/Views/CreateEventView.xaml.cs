using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.FileProperties;
using Windows.UI.Xaml.Media.Imaging;
using EventoApp.Models;
using EventoApp.ViewModels;
using Windows.UI.Popups;
using Windows.ApplicationModel.Activation;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using EventoApp.Converters;



// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace EventoApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateEventView : Page
    {
        EventsDB Db_Event = new EventsDB();

        public CreateEventView()
        {
            this.InitializeComponent();
        }

        public async void PickAFileButton_Click(object sender, RoutedEventArgs e)
        {
            
            FileOpenPicker picker = new FileOpenPicker();
            picker.ViewMode = PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");

            StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {

                string ImagePath = file.Path;
                this.ImagePath.Text = ImagePath;
                var stream = await file.OpenAsync(FileAccessMode.Read);
                BitmapImage image = new BitmapImage();
                image.SetSource(stream);
                EventPosterImage.Source = image;
            }
            else
            {
                this.ImagePath.Text = "Operation cancelled.";
            }
            
        }

        private async void CreateEventPostBtn_Click(object sender, RoutedEventArgs e)
        {
            
            if (CreateEventTitle.Text != "" &
                CreateEventVenue.Text != "" &
                CreateEventTag.Text != "" &
                CreateEventGuests.Text != "" &
                CreateEventDescription.Text != "")
            {
                Db_Event.Insert(new Event(
                    CreateEventTitle.Text.Trim(),
                    CreateEventVenue.Text.Trim(),
                    CreateEventTag.Text.Trim(),
                    CreateEventGuests.Text.Trim(),
                    CreateEventDescription.Text.Trim(),
                    CreateEventDate.Date.ToString(),
                    CreateEventTime.Time.ToString(),
                    ImagePath.Text.Trim()
                    
                    ));
                Frame.Navigate(typeof(EventsView));
            }
            else
            {
                MessageDialog messageDialog = new MessageDialog("Please Fill in all fields");
                await messageDialog.ShowAsync();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
        }

        private void home_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
