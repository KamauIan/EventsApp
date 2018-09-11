using EventoApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using EventoApp.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace EventoApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchView : Page
    {
        ObservableCollection<Event> Db_EventList = new ObservableCollection<Event>();
        public SearchView()
        {
            this.InitializeComponent();
            this.Loaded += SearchView_Loaded;
        }


        private void SearchView_Loaded(object sender, RoutedEventArgs e)
        {
            ReadAllEvents dbevents = new ReadAllEvents();
            Db_EventList = dbevents.GetAllEvents(); //Gets all DB events

            if (Db_EventList.Count > 0)
            {
                EventoListView.ItemsSource = Db_EventList.OrderByDescending(i => i.Id).ToList();
            }
            

        }
        private void SearchAutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            var SearchItem = SearchAutoSuggestBox.Text.Trim();
            SearchEvents dbevents = new SearchEvents();
            //Db_EventList = dbevents.SearchAllEvent(SearchItem);
            if (Db_EventList.Count > 0)
            {
                EventoListView.ItemsSource = Db_EventList.OrderByDescending(i => i.Id).ToList();
            }
            else
            {
                EventoListView.ItemsSource = null;
            }
            
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
