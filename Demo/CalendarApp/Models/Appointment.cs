using System;
using System.Collections.Generic;

namespace CalendarApp.Models
{
    public class Appointment
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int? ReminderMinutes { get; set; }
        public bool IsGroupMeeting { get; set; }
        public List<string> Participants { get; set; }

        public Appointment()
        {
            Participants = new List<string>();
        }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Name) &&
                   !string.IsNullOrWhiteSpace(Location) &&
                   StartTime < EndTime;
        }

        public TimeSpan Duration => EndTime - StartTime;

        public bool Overlaps(Appointment other)
        {
            return (StartTime < other.EndTime && EndTime > other.StartTime);
        }

        public bool IsSimilarTo(Appointment other)
        {
            return Name.Equals(other.Name, StringComparison.OrdinalIgnoreCase) &&
                   Math.Abs((Duration - other.Duration).TotalMinutes) < 1;
        }
    }
} 