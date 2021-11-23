using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.Models
{
    public class Event
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactEmail { get; set; }
        public EventType Type { get; set; }
        public string Address { get; set; }
        public int Attendees { get; set; }
        public bool RSVP { get; set; }
        public int Id { get; set; }

        public Event()
        {
        }
        public Event(string name, string description, string contactEmail, EventType type, string address, int attendees)
        {
            Name = name;
            Description = description;
            ContactEmail = contactEmail;
            Type = type;
            Address = address;
            Attendees = attendees;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return obj is Event @event &&
                   Id == @event.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}