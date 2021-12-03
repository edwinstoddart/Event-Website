using CodingEvents.Data;
using CodingEvents.Models;
using CodingEvents.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.Controllers
{
    public class TagController : Controller
    {
        private EventDbContext context;
        public TagController(EventDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Tag> tags = context.Tags.ToList();
            return View(tags);
        }

        public IActionResult Add()
        {
            AddTagViewModel addTagViewModel = new AddTagViewModel();
            return View(addTagViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddTagViewModel addTagViewModel)
        {
            if (ModelState.IsValid)
            {
                Tag newTag = new Tag
                {
                    Name = addTagViewModel.Name
                };

                context.Tags.Add(newTag);
                context.SaveChanges();
                return Redirect("/tag/");
            }

            return View("Add", addTagViewModel);
        }

        // GET: /Tag/AddEvent/
        public IActionResult AddEvent(int id)
        {
            Event theEvent = context.Events.Find(id);
            List<Tag> possibleTags = context.Tags.ToList();

            AddEventTagViewModel viewModel = new AddEventTagViewModel(theEvent, possibleTags);

            return View(viewModel);
        }

        // POST: /Tag/AddEvent/int?
        [HttpPost]
        public IActionResult AddEvent(AddEventTagViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                int eventId = viewModel.EventId;
                int tagId = viewModel.TagId;

                List<EventTag> existingItems = context.EventTags
                    .Where(et => et.EventId == eventId)
                    .Where(et => et.TagId == tagId)
                    .ToList();

                if (existingItems.Count == 0)
                {
                    EventTag eventTag = new EventTag
                    {
                        EventId = eventId,
                        TagId = tagId
                    };

                    context.EventTags.Add(eventTag);
                    context.SaveChanges();
                }

                return Redirect("/events/detail/" + eventId);
            }

            return View(viewModel);
        }

        public IActionResult Detail(int id)
        {
            List<EventTag> eventTags = context.EventTags
                .Where(et => et.TagId == id)
                .Include(et => et.Event)
                .Include(et => et.Tag)
                .ToList();

            return View(eventTags);
        }
    }
}
