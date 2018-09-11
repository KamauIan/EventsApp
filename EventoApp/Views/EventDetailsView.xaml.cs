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
using System.Collections.ObjectModel;
using EventoApp.Models;
using EventoApp.ViewModels;
using EventoApp.Converters;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace EventoApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EventDetailsView : Page
    {
        EventsDB Db_Helper = new EventsDB();
        Event currentEvent = new Event();
        public EventDetailsView()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            currentEvent = e.Parameter as Event;
            EventTitle.Text = currentEvent.CreateEventTitle;//get EventTitle
            EventVenue.Text = currentEvent.CreateEventVenue;
            EventType.Text = currentEvent.CreateEventTag;
            EventDate.Text = currentEvent.CreateEventDate;
            EventGuests.Text = currentEvent.CreateEventGuests;
            EventTime.Text = currentEvent.CreateEventTime;
            EventDescription.Text = currentEvent.CreateEventDescription;
            EventImage.Source = new BitmapImage(new Uri(currentEvent.ImagePath));
            
        }

        private void EventGuests_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void EventImage_GettingFocus(UIElement sender, GettingFocusEventArgs args)
        {

        }
    }
}
