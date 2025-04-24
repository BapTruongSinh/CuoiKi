namespace CalendarApp
{
    partial class AppointmentDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            nameLabel = new Label();
            locationLabel = new Label();
            descriptionLabel = new Label();
            dateLabel = new Label();
            endTimeLabel = new Label();
            reminderLabel = new Label();
            meetingTypeLabel = new Label();
            nameTextBox = new TextBox();
            locationTextBox = new TextBox();
            descriptionTextBox = new TextBox();
            datePicker = new DateTimePicker();
            startTimePicker = new DateTimePicker();
            endTimePicker = new DateTimePicker();
            reminderCheckBox = new CheckBox();
            reminderMinutesUpDown = new NumericUpDown();
            minutesLabel = new Label();
            isGroupMeetingCheckBox = new CheckBox();
            saveButton = new Button();
            cancelButton = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)reminderMinutesUpDown).BeginInit();
            SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.Location = new Point(33, 38);
            nameLabel.Margin = new Padding(5, 0, 5, 0);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(133, 44);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "Name:";
            // 
            // locationLabel
            // 
            locationLabel.Location = new Point(33, 96);
            locationLabel.Margin = new Padding(5, 0, 5, 0);
            locationLabel.Name = "locationLabel";
            locationLabel.Size = new Size(133, 44);
            locationLabel.TabIndex = 1;
            locationLabel.Text = "Location:";
            // 
            // descriptionLabel
            // 
            descriptionLabel.Location = new Point(33, 154);
            descriptionLabel.Margin = new Padding(5, 0, 5, 0);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(133, 44);
            descriptionLabel.TabIndex = 2;
            descriptionLabel.Text = "Description:";
            // 
            // dateLabel
            // 
            dateLabel.Location = new Point(33, 212);
            dateLabel.Margin = new Padding(5, 0, 5, 0);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new Size(133, 44);
            dateLabel.TabIndex = 3;
            dateLabel.Text = "Date:";
            // 
            // endTimeLabel
            // 
            endTimeLabel.Location = new Point(308, 269);
            endTimeLabel.Margin = new Padding(5, 0, 5, 0);
            endTimeLabel.Name = "endTimeLabel";
            endTimeLabel.Size = new Size(108, 31);
            endTimeLabel.TabIndex = 4;
            endTimeLabel.Text = "End Time:";
            // 
            // reminderLabel
            // 
            reminderLabel.Location = new Point(33, 327);
            reminderLabel.Margin = new Padding(5, 0, 5, 0);
            reminderLabel.Name = "reminderLabel";
            reminderLabel.Size = new Size(133, 44);
            reminderLabel.TabIndex = 5;
            reminderLabel.Text = "Reminder:";
            // 
            // meetingTypeLabel
            // 
            meetingTypeLabel.Location = new Point(33, 385);
            meetingTypeLabel.Margin = new Padding(5, 0, 5, 0);
            meetingTypeLabel.Name = "meetingTypeLabel";
            meetingTypeLabel.Size = new Size(133, 44);
            meetingTypeLabel.TabIndex = 6;
            meetingTypeLabel.Text = "Meeting Type:";
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(183, 38);
            nameTextBox.Margin = new Padding(5, 6, 5, 6);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(414, 31);
            nameTextBox.TabIndex = 7;
            // 
            // locationTextBox
            // 
            locationTextBox.Location = new Point(183, 96);
            locationTextBox.Margin = new Padding(5, 6, 5, 6);
            locationTextBox.Name = "locationTextBox";
            locationTextBox.Size = new Size(414, 31);
            locationTextBox.TabIndex = 8;
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.Location = new Point(183, 154);
            descriptionTextBox.Margin = new Padding(5, 6, 5, 6);
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.Size = new Size(414, 31);
            descriptionTextBox.TabIndex = 9;
            // 
            // datePicker
            // 
            datePicker.Format = DateTimePickerFormat.Short;
            datePicker.Location = new Point(183, 212);
            datePicker.Margin = new Padding(5, 6, 5, 6);
            datePicker.Name = "datePicker";
            datePicker.Size = new Size(164, 31);
            datePicker.TabIndex = 10;
            // 
            // startTimePicker
            // 
            startTimePicker.CustomFormat = "HH:mm";
            startTimePicker.Format = DateTimePickerFormat.Custom;
            startTimePicker.Location = new Point(162, 269);
            startTimePicker.Margin = new Padding(5, 6, 5, 6);
            startTimePicker.Name = "startTimePicker";
            startTimePicker.ShowUpDown = true;
            startTimePicker.Size = new Size(114, 31);
            startTimePicker.TabIndex = 11;
            // 
            // endTimePicker
            // 
            endTimePicker.CustomFormat = "HH:mm";
            endTimePicker.Format = DateTimePickerFormat.Custom;
            endTimePicker.Location = new Point(414, 269);
            endTimePicker.Margin = new Padding(5, 6, 5, 6);
            endTimePicker.Name = "endTimePicker";
            endTimePicker.ShowUpDown = true;
            endTimePicker.Size = new Size(114, 31);
            endTimePicker.TabIndex = 12;
            // 
            // reminderCheckBox
            // 
            reminderCheckBox.Location = new Point(176, 318);
            reminderCheckBox.Margin = new Padding(5, 6, 5, 6);
            reminderCheckBox.Name = "reminderCheckBox";
            reminderCheckBox.Size = new Size(83, 44);
            reminderCheckBox.TabIndex = 13;
            reminderCheckBox.Text = "Set";
            // 
            // reminderMinutesUpDown
            // 
            reminderMinutesUpDown.Enabled = false;
            reminderMinutesUpDown.Location = new Point(283, 327);
            reminderMinutesUpDown.Margin = new Padding(5, 6, 5, 6);
            reminderMinutesUpDown.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            reminderMinutesUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            reminderMinutesUpDown.Name = "reminderMinutesUpDown";
            reminderMinutesUpDown.Size = new Size(83, 31);
            reminderMinutesUpDown.TabIndex = 14;
            reminderMinutesUpDown.Value = new decimal(new int[] { 15, 0, 0, 0 });
            // 
            // minutesLabel
            // 
            minutesLabel.Location = new Point(383, 327);
            minutesLabel.Margin = new Padding(5, 0, 5, 0);
            minutesLabel.Name = "minutesLabel";
            minutesLabel.Size = new Size(167, 44);
            minutesLabel.TabIndex = 15;
            minutesLabel.Text = "minutes before";
            // 
            // isGroupMeetingCheckBox
            // 
            isGroupMeetingCheckBox.Location = new Point(183, 385);
            isGroupMeetingCheckBox.Margin = new Padding(5, 6, 5, 6);
            isGroupMeetingCheckBox.Name = "isGroupMeetingCheckBox";
            isGroupMeetingCheckBox.Size = new Size(250, 44);
            isGroupMeetingCheckBox.TabIndex = 16;
            isGroupMeetingCheckBox.Text = "Group Meeting";
            // 
            // saveButton
            // 
            saveButton.Location = new Point(333, 462);
            saveButton.Margin = new Padding(5, 6, 5, 6);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(125, 44);
            saveButton.TabIndex = 17;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += SaveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(475, 462);
            cancelButton.Margin = new Padding(5, 6, 5, 6);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(125, 44);
            cancelButton.TabIndex = 18;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += CancelButton_Click;
            // 
            // label1
            // 
            label1.Location = new Point(50, 269);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(102, 31);
            label1.TabIndex = 19;
            label1.Text = "Start Time:";
            // 
            // AppointmentDialog
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 540);
            Controls.Add(label1);
            Controls.Add(nameLabel);
            Controls.Add(locationLabel);
            Controls.Add(descriptionLabel);
            Controls.Add(dateLabel);
            Controls.Add(endTimeLabel);
            Controls.Add(reminderLabel);
            Controls.Add(meetingTypeLabel);
            Controls.Add(nameTextBox);
            Controls.Add(locationTextBox);
            Controls.Add(descriptionTextBox);
            Controls.Add(datePicker);
            Controls.Add(startTimePicker);
            Controls.Add(endTimePicker);
            Controls.Add(reminderCheckBox);
            Controls.Add(reminderMinutesUpDown);
            Controls.Add(minutesLabel);
            Controls.Add(isGroupMeetingCheckBox);
            Controls.Add(saveButton);
            Controls.Add(cancelButton);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(5, 6, 5, 6);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AppointmentDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Appointment";
            ((System.ComponentModel.ISupportInitialize)reminderMinutesUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label endTimeLabel;
        private System.Windows.Forms.Label reminderLabel;
        private System.Windows.Forms.Label meetingTypeLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox locationTextBox;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.DateTimePicker startTimePicker;
        private System.Windows.Forms.DateTimePicker endTimePicker;
        private System.Windows.Forms.CheckBox reminderCheckBox;
        private System.Windows.Forms.NumericUpDown reminderMinutesUpDown;
        private System.Windows.Forms.Label minutesLabel;
        private System.Windows.Forms.CheckBox isGroupMeetingCheckBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private Label label1;
    }
} 