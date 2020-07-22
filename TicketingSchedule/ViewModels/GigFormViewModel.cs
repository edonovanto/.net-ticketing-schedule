﻿using System;
using System.Collections.Generic;
using TicketingSchedule.Models;

namespace TicketingSchedule.ViewModels
{
    public class GigFormViewModel
    {
        public string Venue { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public byte Genre { get; set; }
        public IEnumerable<Genre> Genres { get; set; }

        public DateTime DateTime
        {
            get
            {
                return DateTime.Parse($"{Date} {Time}");
            }
        }
    }
}