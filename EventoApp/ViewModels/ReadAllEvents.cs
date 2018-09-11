using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Collections.ObjectModel;
using EventoApp.Models;
using EventoApp.ViewModels;
namespace EventoApp.ViewModels
{
    class ReadAllEvents
    {
        EventsDB Db_Events = new EventsDB();
        public ObservableCollection<Event> GetAllEvents()
        {
            return Db_Events.ReadAllEvents();
        }
    }
}
