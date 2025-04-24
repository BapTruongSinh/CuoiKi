using System;
using System.Drawing;
using System.Windows.Forms;
using CalendarApp.Models;

namespace CalendarApp
{
    public partial class AppointmentDialog : Form
    {
        private DateTime startTime;
        public Appointment Appointment { get; private set; }

        public AppointmentDialog(DateTime startTime)
        {
            InitializeComponent();
            this.startTime = startTime;
            this.datePicker.Value = startTime.Date;
            this.startTimePicker.Value = startTime;
            this.endTimePicker.Value = startTime.AddHours(1);

            // Enable/disable reminder minutes based on checkbox
            this.reminderCheckBox.CheckedChanged += (s, e) =>
            {
                this.reminderMinutesUpDown.Enabled = this.reminderCheckBox.Checked;
            };

            // Add event handlers
            this.saveButton.Click += SaveButton_Click;
            this.cancelButton.Click += CancelButton_Click;
            this.datePicker.ValueChanged += StartDateTime_ValueChanged;
            this.startTimePicker.ValueChanged += StartDateTime_ValueChanged;
            this.endTimePicker.ValueChanged += EndDateTime_ValueChanged;
        }

        private void StartDateTime_ValueChanged(object sender, EventArgs e)
        {
            // Update end time if it's less than start time
            var startDateTime = this.datePicker.Value.Date.Add(this.startTimePicker.Value.TimeOfDay);
            var endDateTime = this.datePicker.Value.Date.Add(this.endTimePicker.Value.TimeOfDay);

            if (endDateTime <= startDateTime)
            {
                this.endTimePicker.Value = startDateTime.AddHours(1);
            }
        }

        private void EndDateTime_ValueChanged(object sender, EventArgs e)
        {
            // Ensure end time is not before start time
            var startDateTime = this.datePicker.Value.Date.Add(this.startTimePicker.Value.TimeOfDay);
            var endDateTime = this.datePicker.Value.Date.Add(this.endTimePicker.Value.TimeOfDay);

            if (endDateTime <= startDateTime)
            {
                this.endTimePicker.Value = startDateTime.AddHours(1);
            }
        }

        public void SetAppointment(Appointment appointment)
        {
            this.nameTextBox.Text = appointment.Name;
            this.locationTextBox.Text = appointment.Location;
            this.descriptionTextBox.Text = appointment.Description;
            this.datePicker.Value = appointment.StartTime.Date;
            this.startTimePicker.Value = appointment.StartTime;
            this.endTimePicker.Value = appointment.EndTime;
            this.reminderCheckBox.Checked = appointment.ReminderMinutes.HasValue;
            if (appointment.ReminderMinutes.HasValue)
            {
                this.reminderMinutesUpDown.Value = appointment.ReminderMinutes.Value;
            }
            this.isGroupMeetingCheckBox.Checked = appointment.IsGroupMeeting;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Please enter an appointment name.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(locationTextBox.Text))
            {
                MessageBox.Show("Please enter a location.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create appointment date/times
            var date = datePicker.Value.Date;
            var startDateTime = date.Add(startTimePicker.Value.TimeOfDay);
            var endDateTime = date.Add(endTimePicker.Value.TimeOfDay);

            // Validate times
            if (endDateTime <= startDateTime)
            {
                MessageBox.Show("End time must be after start time.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create the appointment
            Appointment = new Appointment
            {
                Name = nameTextBox.Text,
                Location = locationTextBox.Text,
                Description = descriptionTextBox.Text,
                StartTime = startDateTime,
                EndTime = endDateTime,
                ReminderMinutes = reminderCheckBox.Checked ? (int?)reminderMinutesUpDown.Value : null,
                IsGroupMeeting = isGroupMeetingCheckBox.Checked
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
} 