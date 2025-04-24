using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CalendarApp.Models;

namespace CalendarApp
{
    public class AppointmentManager
    {
        private List<Appointment> appointments;
        private List<(DateTime time, string appointmentName)> reminders;

        public AppointmentManager()
        {
            appointments = new List<Appointment>();
            reminders = new List<(DateTime time, string appointmentName)>();
        }

        public bool TryAddAppointment(Appointment appointment, out string message, out Appointment existingAppointment, bool isOverride = false)
        {
            existingAppointment = null;
            
            // Kiểm tra xem có cuộc hẹn nào trùng thời gian không
            var overlappingAppointment = appointments
                .FirstOrDefault(a => a.StartTime < appointment.EndTime && a.EndTime > appointment.StartTime);

            if (overlappingAppointment != null)
            {
                existingAppointment = overlappingAppointment;
                
                if (!isOverride)
                {
                    string appointmentType = overlappingAppointment.IsGroupMeeting ? "group meeting" : "appointment";
                    message = $"An existing {appointmentType} '{overlappingAppointment.Name}' at {overlappingAppointment.Location} " +
                            $"already exists between {overlappingAppointment.StartTime:HH:mm} and {overlappingAppointment.EndTime:HH:mm}\n\n" +
                            "Would you like to:\n" +
                            "Yes - Override the existing appointment\n" +
                            "No - Edit the time of your new appointment\n" +
                            "Cancel - Cancel adding the new appointment";
                    return false;
                }

                // Nếu là override, xóa cuộc hẹn cũ
                appointments.Remove(overlappingAppointment);
            }

            appointments.Add(appointment);
            message = "Appointment added successfully!";
            return true;
        }

        // Overload cũ để duy trì tương thích
        public bool TryAddAppointment(Appointment appointment, out string message, bool isOverride = false)
        {
            return TryAddAppointment(appointment, out message, out _, isOverride);
        }

        public void UpdateAppointment(Appointment oldAppointment, Appointment newAppointment)
        {
            // Remove old reminder if exists
            if (oldAppointment.ReminderMinutes.HasValue)
            {
                var oldReminderTime = oldAppointment.StartTime.AddMinutes(-oldAppointment.ReminderMinutes.Value);
                reminders.RemoveAll(r => r.time == oldReminderTime && r.appointmentName == oldAppointment.Name);
            }

            // Add new reminder if set
            if (newAppointment.ReminderMinutes.HasValue)
            {
                var newReminderTime = newAppointment.StartTime.AddMinutes(-newAppointment.ReminderMinutes.Value);
                reminders.Add((newReminderTime, newAppointment.Name));
            }

            var index = appointments.IndexOf(oldAppointment);
            if (index != -1)
            {
                appointments[index] = newAppointment;
            }
        }

        public void DeleteAppointment(Appointment appointment)
        {
            // Remove reminder if exists
            if (appointment.ReminderMinutes.HasValue)
            {
                var reminderTime = appointment.StartTime.AddMinutes(-appointment.ReminderMinutes.Value);
                reminders.RemoveAll(r => r.time == reminderTime && r.appointmentName == appointment.Name);
            }
            
            appointments.Remove(appointment);
        }

        public List<Appointment> GetAppointmentsForDay(DateTime date)
        {
            return appointments
                .Where(a => a.StartTime.Date == date.Date)
                .OrderBy(a => a.StartTime)
                .ToList();
        }

        public List<(DateTime time, string appointmentName)> GetUpcomingReminders(DateTime currentTime)
        {
            return reminders
                .Where(r => r.time > currentTime && r.time <= currentTime.AddMinutes(5))
                .OrderBy(r => r.time)
                .ToList();
        }

        public bool JoinGroupMeeting(string userName, Appointment newAppointment)
        {
            var existingAppointments = GetAppointmentsForDay(newAppointment.StartTime.Date);
            
            foreach (var existing in existingAppointments)
            {
                if (IsTimeOverlap(existing, newAppointment) &&
                    existing.Name.Equals(newAppointment.Name, StringComparison.OrdinalIgnoreCase) &&
                    existing.Location.Equals(newAppointment.Location, StringComparison.OrdinalIgnoreCase))
                {
                    // Đảm bảo đây là group meeting
                    existing.IsGroupMeeting = true;
                    
                    // Thêm người dùng vào danh sách tham gia nếu chưa có
                    if (!existing.Participants.Contains(userName))
                    {
                        existing.Participants.Add(userName);
                    }
                    return true;
                }
            }
            
            return false;
        }

        private bool IsTimeOverlap(Appointment a1, Appointment a2)
        {
            return a1.StartTime < a2.EndTime && a2.StartTime < a1.EndTime;
        }
    }
} 