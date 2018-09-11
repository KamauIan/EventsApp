using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using EventoApp.Models;
using System.Collections.ObjectModel;
using System.IO;

namespace EventoApp.Models
{
    class EventsDB
    {
        string path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "EventoApp.sqlite");
        SQLiteConnection conn;
        //Create Table 
        public void CreateDatabase(string path)
        {
            if (!CheckFileExists(path).Result)
            {
                //path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Evento.sqlite");
                using (conn = new SQLiteConnection(path, true))
                {
                    conn.CreateTable<Event>();
                }
            }
        }
        private async Task<bool> CheckFileExists(string fileName)
        {
            try
            {
                var store = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return true;
            }
            catch
            {
                return false;
            }
        }
        // Insert the new Event in the Event table. 
        public void Insert(Event objEvent)
        {
            //path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Evento.sqlite");
            using (conn = new SQLiteConnection(path, true))
            {
                conn.RunInTransaction(() =>
                {
                    conn.Insert(objEvent);
                });
            }
        }
        // Retrieve the specific Event from the database.   
        public Event ReadEvent(int eventid)
        {
            //path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Evento.sqlite");
            using (conn = new SQLiteConnection(path, true))
            {
                var existingevent = conn.Query<Event>("select * from Event where Id =" + eventid).FirstOrDefault();
                return existingevent;
            }
        }
        public ObservableCollection<Event> ReadAllEvents()
        {
            try
            {
                //path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Evento.sqlite");
                using (conn = new SQLiteConnection(path, true))
                {
                    List<Event> myCollection = conn.Table<Event>().ToList<Event>();
                    ObservableCollection<Event> EventList = new ObservableCollection<Event>(myCollection);
                    return EventList;
                }
            }
            catch
            {
                return null;
            }

        }
        //Update existing contact 
        public void UpdateDetails(Event ObjEvent)
        {
            //path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Evento.sqlite");
            using (conn = new SQLiteConnection(path, true))
            {

                var existingEvent = conn.Query<Event>("select * from Event where Id =" + ObjEvent.Id).FirstOrDefault();
                if (existingEvent != null)
                {

                    conn.RunInTransaction(() =>
                    {
                        conn.Update(ObjEvent);
                    });
                }

            }
        }
        //Delete all eventlist or delete Event table   
        public void DeleteAllEvent()
        {
            //path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Evento.sqlite");
            using (conn = new SQLiteConnection(path, true))
            {

                conn.DropTable<Event>();
                conn.CreateTable<Event>();
                conn.Dispose();
                conn.Close();

            }
        }
        //Delete specific event   
        public void DeleteEvent(int Id)
        {

            using (conn = new SQLiteConnection(path, true))
            {
                //path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Evento.sqlite");
                var existingevent = conn.Query<Event>("select * from Event where Id =" + Id).FirstOrDefault();
                if (existingevent != null)
                {
                    conn.RunInTransaction(() =>
                    {
                        conn.Delete(existingevent);
                    });
                }
            }
        }
        //public void Find(Event searchItem)
        //{
        //    var searchEvent = conn.Query<Event>("Select * from Event where CreateEventTitle =" + searchItem);
        //    //path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Evento.sqlite");
        //    using (conn = new SQLiteConnection(path, true))
        //    {

                
        //    }
        //}
        //public Event SearchEvent(string SearchItem)
        //{
        //    try
        //    {
        //        //path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Evento.sqlite");
        //        using (conn = new SQLiteConnection(path, true))
        //        {
        //            //List<Event> myCollection = conn.Query<Event>("Select * from Event where CreateEventTitle ="+ SearchItem).ToList<Event>();
        //            //ObservableCollection<Event> searchEvent = new ObservableCollection<Event>(myCollection);
        //            var searchEvent = conn.Query<Event>("Select * from Event where CreateEventTitle =" + SearchItem).FirstOrDefault();
        //            return searchEvent;
        //        }
        //    }
        //    catch
        //    {
        //        return null;
        //    }

        //}
    }
}
