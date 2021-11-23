using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.ViewModel
{
    public class AddEventViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a description for your event.")]
        [StringLength(500, ErrorMessage = "Description is too long!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "A Contact Email Address is required.")]
        [EmailAddress]
        public string ContactEmail { get; set; }

        public EventType Type { get; set; }
        public List<SelectListItem> EventTypes { get; set; } = new List<SelectListItem>
        {
            new SelectListItem(EventType.Conference.ToString(), ((int)EventType.Conference).ToString()),
            new SelectListItem(EventType.Meetup.ToString(),     ((int)EventType.Meetup).ToString()),
            new SelectListItem(EventType.Workshop.ToString(),   ((int)EventType.Workshop).ToString()),
            new SelectListItem(EventType.Social.ToString(),     ((int)EventType.Social).ToString())
        };

        [Required(ErrorMessage = "An address is required for the Event.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Please enter a full street address.")]
        public string Address { get; set; }

        [Required]
        [Range(0.0, 100000.0, ErrorMessage = "Please provide a number of Attendees between 0 and 100,000.")]
        public int Attendees { get; set; }

        public bool RSVP { get; set; }

        public bool IsTrue { get { return true; } }
    }
}
