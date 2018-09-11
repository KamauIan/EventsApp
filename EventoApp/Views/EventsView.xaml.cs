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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace EventoApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EventsView : Page
    {
        ObservableCollection<Event> Db_EventList = new ObservableCollection<Event>();
        public EventsView()
        {
            this.InitializeComponent();
            this.Loaded += ReadEventList_Loaded;
        }

        private void searchBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            
        }

        private void ReadEventList_Loaded(object sender, RoutedEventArgs e)
        {
            ReadAllEvents dbevents = new ReadAllEvents();
            Db_EventList = dbevents.GetAllEvents(); //Gets all DB events

            if (Db_EventList.Count > 0)
            {
                //btnDelete.IsEnabled = true;
            }
            EventoListView.ItemsSource = Db_EventList.OrderByDescending(i => i.Id).ToList();
        }
        private void EventoListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            if (EventoListView.SelectedIndex != -1)
            {
                Event listitem = EventoListView.SelectedItem as Event;//get selected listbox item Event ID

                Frame.Navigate(typeof(EventDetailsView), listitem);
            }
        }
    }
    
}
