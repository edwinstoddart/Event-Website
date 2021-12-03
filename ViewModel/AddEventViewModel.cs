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

        [Required(ErrorMessage = "A Category is required.")]
        public int CategoryId { get; set; }
        public List<SelectListItem> Categories { get; set; }

        [Required(ErrorMessage = "An address is required for the Event.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Please enter a full street address.")]
        public string Address { get; set; }

        [Required]
        [Range(0.0, 100000.0, ErrorMessage = "Please provide a number of Attendees between 0 and 100,000.")]
        public int Attendees { get; set; }

        public bool RSVP { get; set; }

        public bool IsTrue { get { return true; } }

        public AddEventViewModel() { }
        public AddEventViewModel(List<EventCategory> categories)
        {
            Categories = new List<SelectListItem>();

            foreach (EventCategory category in categories)
            {
                Categories.Add(new SelectListItem
                    {
                        Value = category.Id.ToString(),
                        Text = category.Name
                    }
                );
            }
        }
    }
}
