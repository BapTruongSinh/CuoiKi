using System;
using System.Drawing;
using System.Windows.Forms;
using CalendarApp.Models;
using System.Linq;

namespace CalendarApp
{
    public partial class Form1 : Form
    {
        private readonly AppointmentManager appointmentManager;
        private ContextMenuStrip appointmentContextMenu;
        private System.Windows.Forms.Timer reminderTimer;

        public Form1()
        {
            InitializeComponent();
            InitializeTimeSlots();
            appointmentManager = new AppointmentManager();
            InitializeContextMenu();
            this.calendar.DateSelected += Calendar_DateSelected;
            this.Load += Form1_Load;
            this.addAppointmentButton.Click += addAppointmentButton_Click_1;
            InitializeReminderTimer();
            RefreshAppointments();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeRealTimeClock();
        }

        private void InitializeRealTimeClock()
        {
            // Đợi một chút để calendar được render đầy đủ
            this.BeginInvoke(new Action(() =>
            {
                // Tính toán vị trí dựa trên vị trí thực của calendar
                Rectangle calendarBounds = calendar.Bounds;
                int yPos = calendarBounds.Bottom + 5;

                // Cấu hình label hiển thị đồng hồ
                clockLabel.Font = new Font("Segoe UI", 14f, FontStyle.Bold);
                clockLabel.BackColor = Color.White;
                clockLabel.BorderStyle = BorderStyle.FixedSingle;
                clockLabel.Size = new Size(calendarBounds.Width, 35);
                clockLabel.Location = new Point(calendarBounds.Left, yPos);

                // Cấu hình timer
                clockTimer.Interval = 1000; // Cập nhật mỗi giây
                clockTimer.Enabled = true;

                // Cập nhật thời gian ngay lập tức
                UpdateClock();
            }));
        }

        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            UpdateClock();
        }

        private void UpdateClock()
        {
            if (clockLabel != null && !clockLabel.IsDisposed)
            {
                clockLabel.Text = DateTime.Now.ToString("HH:mm:ss");
            }
        }

        private void InitializeReminderTimer()
        {
            reminderTimer = new System.Windows.Forms.Timer();
            reminderTimer.Interval = 60000; // Check every minute
            reminderTimer.Tick += ReminderTimer_Tick;
            reminderTimer.Start();
        }

        private void ReminderTimer_Tick(object sender, EventArgs e)
        {
            CheckReminders();
        }

        private void CheckReminders()
        {
            var now = DateTime.Now;
            var appointments = appointmentManager.GetAppointmentsForDay(now.Date);
            
            foreach (var appointment in appointments)
            {
                if (!appointment.ReminderMinutes.HasValue) continue;

                DateTime reminderTime = appointment.StartTime.AddMinutes(-appointment.ReminderMinutes.Value);
                TimeSpan difference = now - reminderTime;

                // Chỉ hiển thị thông báo nếu trong khoảng 1 phút so với thời điểm reminder
                if (Math.Abs(difference.TotalMinutes) <= 1)
                {
                    MessageBox.Show(
                        $"Reminder: You have an appointment '{appointment.Name}' at {appointment.Location} " +
                        $"starting in {appointment.ReminderMinutes.Value} minutes.",
                        "Appointment Reminder",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (clockTimer != null)
            {
                clockTimer.Stop();
                clockTimer.Dispose();
            }
            if (reminderTimer != null)
            {
                reminderTimer.Stop();
                reminderTimer.Dispose();
            }
        }

        private void InitializeContextMenu()
        {
            appointmentContextMenu = new ContextMenuStrip();

            var editItem = new ToolStripMenuItem("Edit Appointment");
            editItem.Click += (s, e) =>
            {
                if (appointmentContextMenu.SourceControl is Button button &&
                    button.Tag is Appointment appointment)
                {
                    ShowEditAppointmentDialog(appointment);
                }
            };

            var deleteItem = new ToolStripMenuItem("Delete Appointment");
            deleteItem.Click += (s, e) =>
            {
                if (appointmentContextMenu.SourceControl is Button button &&
                    button.Tag is Appointment appointment)
                {
                    var result = MessageBox.Show(
                        $"Are you sure you want to delete the appointment '{appointment.Name}'?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        appointmentManager.DeleteAppointment(appointment);
                        RefreshAppointments();
                    }
                }
            };

            appointmentContextMenu.Items.AddRange(new ToolStripItem[] { editItem, deleteItem });
        }

        private void InitializeTimeSlots()
        {
            // Tạo panel chính cho time slots
            timeSlotPanel.AutoScroll = true;
            timeSlotPanel.Height = 24 * 40; // 24 giờ * 40 pixels mỗi giờ
            timeSlotPanel.Paint += TimeSlotPanel_Paint;

            // Thêm labels cho các giờ
            for (int hour = 0; hour < 24; hour++)
            {
                Label timeLabel = new Label
                {
                    Text = hour.ToString("00") + ":00",
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleRight,
                    Location = new Point(10, hour * 40),
                    Size = new Size(50, 40)
                };
                timeSlotPanel.Controls.Add(timeLabel);
            }

            // Thêm sự kiện click cho timeSlotPanel
            timeSlotPanel.MouseClick += TimeSlotPanel_MouseClick;
        }

        private void TimeSlotPanel_Paint(object sender, PaintEventArgs e)
        {
            // Vẽ các đường kẻ ngang cho mỗi giờ
            using (Pen pen = new Pen(Color.LightGray))
            {
                for (int hour = 0; hour <= 24; hour++)
                {
                    int y = hour * 40;
                    e.Graphics.DrawLine(pen, 70, y, timeSlotPanel.Width - 10, y);
                }
            }
        }

        private void TimeSlotPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X < 70) return; // Ignore clicks in the time label area

            // Tính toán giờ và phút dựa trên vị trí click
            int scrollOffset = timeSlotPanel.VerticalScroll.Value;
            int totalY = e.Y + scrollOffset;
            double hourDecimal = totalY / 40.0;

            if (hourDecimal >= 0 && hourDecimal < 24)
            {
                int hour = (int)hourDecimal;
                int minute = (int)((hourDecimal - hour) * 60);
                // Làm tròn đến 15 phút gần nhất
                minute = (minute / 15) * 15;

                var startTime = calendar.SelectionStart.Date
                    .AddHours(hour)
                    .AddMinutes(minute);

                ShowAddAppointmentDialog(startTime);
            }
        }

        private void ShowAddAppointmentDialog(DateTime startTime, Appointment existingAppointment = null)
        {
            try
            {
                using (var dialog = new AppointmentDialog(startTime))
                {
                    if (existingAppointment != null)
                    {
                        dialog.SetAppointment(existingAppointment);
                    }

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        HandleAppointmentDialogResult(dialog.Appointment);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error showing appointment dialog: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleAppointmentDialogResult(Appointment appointment)
        {
            if (appointmentManager.TryAddAppointment(appointment, out string message, out Appointment existingAppointment))
            {
                MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshAppointments();
                return;
            }

            // Chỉ hỏi về việc tham gia group meeting khi cả hai cuộc hẹn đều là group meeting
            if (existingAppointment != null && 
                existingAppointment.IsGroupMeeting && 
                appointment.IsGroupMeeting)
            {
                var result = MessageBox.Show(
                    "A similar group meeting already exists at this time.\nWould you like to join this meeting as a participant?",
                    "Join Group Meeting",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes && appointmentManager.JoinGroupMeeting(Environment.UserName, appointment))
                {
                    MessageBox.Show("Successfully joined the group meeting!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshAppointments();
                }
                return;
            }

            // Xử lý trường hợp trùng thời gian thông thường
            var conflictResult = MessageBox.Show(
                message,
                "Time Conflict",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning);

            switch (conflictResult)
            {
                case DialogResult.Yes:
                    if (appointmentManager.TryAddAppointment(appointment, out string overrideMessage, out _, true))
                    {
                        MessageBox.Show(overrideMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshAppointments();
                    }
                    break;

                case DialogResult.No:
                    using (var dialog = new AppointmentDialog(appointment.StartTime))
                    {
                        dialog.SetAppointment(appointment);
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            HandleAppointmentDialogResult(dialog.Appointment);
                        }
                    }
                    break;
            }
        }

        private void ShowEditAppointmentDialog(Appointment existingAppointment)
        {
            using (var dialog = new AppointmentDialog(existingAppointment.StartTime))
            {
                dialog.SetAppointment(existingAppointment);
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // Lưu trạng thái reminder cũ
                    bool hadReminder = existingAppointment.ReminderMinutes.HasValue;
                    string oldName = existingAppointment.Name;

                    appointmentManager.UpdateAppointment(existingAppointment, dialog.Appointment);

                    // Nếu bỏ reminder, cần refresh để xóa reminder indicator
                    if (hadReminder && !dialog.Appointment.ReminderMinutes.HasValue)
                    {
                        // Xóa reminder indicator cũ nếu có
                        for (int i = timeSlotPanel.Controls.Count - 1; i >= 0; i--)
                        {
                            Control control = timeSlotPanel.Controls[i];
                            if (control is Panel && control.Tag != null && 
                                control.Tag.ToString() == "reminder_" + oldName)
                            {
                                timeSlotPanel.Controls.RemoveAt(i);
                                break;
                            }
                        }
                    }
                    RefreshAppointments();
                }
            }
        }

        private void Calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            RefreshAppointments();
        }

        private void RefreshAppointments()
        {
            if (timeSlotPanel == null) return;

            try
            {
                // Xóa tất cả các appointment buttons và reminder indicators hiện tại
                for (int i = timeSlotPanel.Controls.Count - 1; i >= 0; i--)
                {
                    Control control = timeSlotPanel.Controls[i];
                    if (control is Button || control is Panel)
                    {
                        if (control.Tag != null && 
                            (control.Tag is Appointment || control.Tag.ToString().StartsWith("reminder_")))
                        {
                            timeSlotPanel.Controls.RemoveAt(i);
                        }
                    }
                }

                // Hiển thị các cuộc hẹn cho ngày được chọn
                var appointments = appointmentManager.GetAppointmentsForDay(calendar.SelectionStart);
                foreach (var appointment in appointments)
                {
                    double startHourDecimal = appointment.StartTime.Hour + (appointment.StartTime.Minute / 60.0);
                    double endHourDecimal = appointment.EndTime.Hour + (appointment.EndTime.Minute / 60.0);

                    if (startHourDecimal >= 0 && startHourDecimal < 24 && endHourDecimal > startHourDecimal && endHourDecimal <= 24)
                    {
                        string buttonText = $"{appointment.Name}\n{appointment.Location}\n{appointment.StartTime.ToString("HH:mm")} - {appointment.EndTime.ToString("HH:mm")}";
                        if (appointment.IsGroupMeeting && appointment.Participants.Any())
                        {
                            buttonText += $"\nParticipants: {string.Join(", ", appointment.Participants)}";
                        }

                        // Tính toán vị trí và kích thước chung
                        int top = (int)(startHourDecimal * 40);
                        int height = (int)((endHourDecimal - startHourDecimal) * 40);
                        int baseLeft = 70;
                        int width = timeSlotPanel.Width - 90;

                        // Tạo appointment button
                        var button = new Button
                        {
                            Text = buttonText,
                            BackColor = appointment.IsGroupMeeting ? System.Drawing.Color.LightBlue : System.Drawing.Color.LightGreen,
                            Tag = appointment,
                            Width = width,
                            Height = height,
                            Location = new Point(baseLeft, top),
                            Anchor = AnchorStyles.Left | AnchorStyles.Right,
                            ContextMenuStrip = appointmentContextMenu
                        };

                        timeSlotPanel.Controls.Add(button);

                        // Thêm reminder indicator nếu có reminder
                        if (appointment.ReminderMinutes.HasValue)
                        {
                            var reminderPanel = new Panel
                            {
                                BackColor = System.Drawing.Color.Yellow,
                                Tag = "reminder_" + appointment.Name,
                                Width = width / 9,
                                Height = height,
                                Location = new Point(baseLeft, top)
                            };

                            var reminderLabel = new Label
                            {
                                Text = appointment.ReminderMinutes.Value.ToString(),
                                AutoSize = false,
                                TextAlign = ContentAlignment.MiddleCenter,
                                Dock = DockStyle.Fill,
                                Font = new Font("Segoe UI", 9f, FontStyle.Bold)
                            };

                            reminderPanel.Controls.Add(reminderLabel);
                            timeSlotPanel.Controls.Add(reminderPanel);
                            reminderPanel.BringToFront();
                        }
                    }
                }

                timeSlotPanel.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing appointments: {ex.Message}", "Refresh Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addAppointmentButton_Click_1(object sender, EventArgs e)
        {
            ShowAddAppointmentDialog(GetCurrentSelectedDateTime());
        }

        private DateTime GetCurrentSelectedDateTime()
        {
            return calendar.SelectionStart.Date.Add(DateTime.Now.TimeOfDay);
        }
    }
}
