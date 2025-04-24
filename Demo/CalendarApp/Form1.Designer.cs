namespace CalendarApp;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        calendar = new MonthCalendar();
        timeSlotPanel = new Panel();
        clockLabel = new Label();
        clockTimer = new System.Windows.Forms.Timer(components);
        addAppointmentButton = new Button();
        SuspendLayout();
        // 
        // calendar
        // 
        calendar.Location = new Point(20, 23);
        calendar.Margin = new Padding(15, 17, 15, 17);
        calendar.MaxSelectionCount = 1;
        calendar.Name = "calendar";
        calendar.TabIndex = 0;
        // 
        // timeSlotPanel
        // 
        timeSlotPanel.AutoScroll = true;
        timeSlotPanel.BorderStyle = BorderStyle.FixedSingle;
        timeSlotPanel.Location = new Point(352, 15);
        timeSlotPanel.Margin = new Padding(5, 6, 5, 6);
        timeSlotPanel.Name = "timeSlotPanel";
        timeSlotPanel.Size = new Size(939, 1031);
        timeSlotPanel.TabIndex = 1;
        // 
        // clockLabel
        // 
        clockLabel.BackColor = Color.White;
        clockLabel.BorderStyle = BorderStyle.FixedSingle;
        clockLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        clockLabel.Location = new Point(20, 276);
        clockLabel.Name = "clockLabel";
        clockLabel.Size = new Size(312, 35);
        clockLabel.TabIndex = 2;
        clockLabel.Text = "00:00:00";
        clockLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // clockTimer
        // 
        clockTimer.Enabled = true;
        clockTimer.Interval = 1000;
        clockTimer.Tick += ClockTimer_Tick;
        // 
        // addAppointmentButton
        // 
        addAppointmentButton.BackColor = Color.Blue;
        addAppointmentButton.FlatStyle = FlatStyle.Flat;
        addAppointmentButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        addAppointmentButton.ForeColor = Color.White;
        addAppointmentButton.Location = new Point(20, 332);
        addAppointmentButton.Name = "addAppointmentButton";
        addAppointmentButton.Size = new Size(312, 40);
        addAppointmentButton.TabIndex = 3;
        addAppointmentButton.Text = "Add Appointment";
        addAppointmentButton.UseVisualStyleBackColor = false;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1297, 1046);
        Controls.Add(addAppointmentButton);
        Controls.Add(clockLabel);
        Controls.Add(timeSlotPanel);
        Controls.Add(calendar);
        Margin = new Padding(5, 6, 5, 6);
        MinimumSize = new Size(1319, 1102);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Calendar App";
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.MonthCalendar calendar;
    private System.Windows.Forms.Panel timeSlotPanel;
    private System.Windows.Forms.Label clockLabel;
    private System.Windows.Forms.Timer clockTimer;
    private System.Windows.Forms.Button addAppointmentButton;
}
