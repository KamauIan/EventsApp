using SQLite;
using SQLite.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EventoApp.Models
{
    class Database
    {
        string path;
        SQLiteConnection conn;

        public Database()
        {
            //Create a path for the database location on the local device
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path,
                "EventoUser.sqlite");
            conn = new SQLiteConnection(path, true);


            //create Tables on the above database
            conn.CreateTable<User>();
            //conn.CreateTable<Event>();

        }
        //Table structure for the User Table
        public int Register(User user)
        {
            int code = 1;
            try
            {
                conn.Insert(new User()
                {
                    UserName = user.UserName,
                    Password = user.Password,
                    Email = user.Email
                });
            }
            catch (SQLiteException ex)
            {
                code = -1;
            }
            return code;
        }
        //Login Check
        public bool Login(string user, string password)
        {
            var query = conn.Table<User>().Where(t => t.UserName == user && t.Password == password);
            if (query.Count() > 0)
                return true;
            else
                return false;
        }
      /*  
        public int CreateEvent(Event events)
        {
            int check = 1;
            try
            {
                conn.Insert(new Event()
                {
                    CreateEventTitle = events.CreateEventTitle,
                    CreateEventVenue = events.CreateEventVenue,
                    CreateEventTag = events.CreateEventTag,
                    CreateEventGuests = events.CreateEventGuests,
                    CreateEventDescription = events.CreateEventDescription,
                    CreateEventDate = events.CreateEventDate,
                    CreateEventTime = events.CreateEventTime
                });
                
            }
            catch (SQLiteException)
            {
                check = -1;
            }
            return check;

        }

    */
        

 

    }
}
