﻿/*
using CodingEvents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.Data
{
    public class EventData
    {
        // store events
        private static Dictionary<int, Event> Events = new Dictionary<int, Event>();
        
        // add events
        public static void Add(Event newEvent)
        {
            Events.Add(newEvent.Id, newEvent);
        }

        // retreive events
        public static IEnumerable<Event> GetAll()
        {
            return Events.Values;
        }

        // retreive single event
        public static Event GetById(int Id)
        {
            return Events[Id];
        }

        // remove single event
        public static void Remove(int Id)
        {
            Events.Remove(Id);
        }
    }
}
*/