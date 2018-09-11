using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventoApp.Models
{
    public class Event
    {
        //Database Model for the Event Table
        //ID property is marked for the primary key
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string CreateEventTitle { get; set; }
        public string CreateEventVenue { get; set; }
        public string CreateEventTag { get; set; }
        public string CreateEventGuests { get; set; }
        public string CreateEventDescription { get; set; }
        public string CreateEventDate { get; set; }
        public string CreateEventTime { get; set; }
        public string ImagePath { get; set; }
        //public string CreationDate { get; set; }

        public Event(string EventTitle, string EventVenue, string EventTag, string EventGuests, string EventDescription, string EventDate, string EventTime, string ImgPath)
        {
            CreateEventTitle = EventTitle;
            CreateEventVenue = EventVenue;
            CreateEventTag = EventTag;
            CreateEventGuests = EventGuests;
            CreateEventDescription = EventDescription;
            CreateEventDate = EventDate;
            CreateEventTime = EventTime;
            ImagePath = ImgPath;
            //ImageBytes = ImageB;
            //CreationDate = DateTime.Now.ToString();
        }
        public Event()
        {

        }
        
        /*
         * CreateEventTitle CreateEventVenue CreateEventTag CreateEventGuests CreateEventDescription CreateEventDate  CreateEventTime
         */
    }
    

}