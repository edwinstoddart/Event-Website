using CodingEvents.Data;
using CodingEvents.Models;
using CodingEvents.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
        private EventDbContext context;

        public EventsController(EventDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /events
        [HttpGet]
        public IActionResult Index()
        {
            List<Event> events = context.Events.ToList();
            return View(events);
        }

        // GET: /events/add
        [HttpGet]
        public IActionResult Add()
        {
            AddEventViewModel addEventViewModel = new AddEventViewModel();
            return View(addEventViewModel);
        }
        // POST: /events/add
        [HttpPost]
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            if (ModelState.IsValid)
            {
                Event newEvent = new Event
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    ContactEmail = addEventViewModel.ContactEmail,
                    Type = addEventViewModel.Type,
                    Address = addEventViewModel.Address,
                    Attendees = addEventViewModel.Attendees,
                    RSVP = addEventViewModel.RSVP
                };
                context.Events.Add(newEvent);
                context.SaveChanges();
                return Redirect("/events");
            }
            return View(addEventViewModel);
        }

        // GET: /events/delete
        [HttpGet]
        public IActionResult Delete()
        {
            ViewBag.events = context.Events.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (int eventId in eventIds)
            {
                Event theEvent = context.Events.Find(eventId);
                context.Events.Remove(theEvent);
            }
            context.SaveChanges();

            return Redirect("/events");
        }
        // GET: /events/edit/{eventId}
        [Route("/events/edit/{eventId}")]
        public IActionResult Edit(int eventId)
        {
            ViewBag.eventToEdit = context.Events.Find(eventId);
            ViewBag.title = $"Edit Event {ViewBag.eventToEdit.Name} (id={ViewBag.eventToEdit.Id})";
            return View();
        }
        [HttpPost("/events/edit")]
        public IActionResult SubmitEditEventForm(int eventId, string name, string description, string contactEmail, string address, int attendees, bool rSVP)
        {
            Event eventToEdit = context.Events.Find(eventId);
            eventToEdit.Name = name;
            eventToEdit.Description = description;
            eventToEdit.ContactEmail = contactEmail;
            eventToEdit.Address = address;
            eventToEdit.Attendees = attendees;
            eventToEdit.RSVP = rSVP;
            return Redirect("/events");
        }
    }
}
