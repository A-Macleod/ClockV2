namespace ClockV2
{
    partial class AlarmView
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
            this.button_Add_Alarm = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.button_Remove_Alarm = new System.Windows.Forms.Button();
            this.button_Edit_Alarm = new System.Windows.Forms.Button();
            this.textBox_AlarmName = new System.Windows.Forms.TextBox();
            this.labelTime = new System.Windows.Forms.Label();
            this.numericUpDown_Hours = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Minutes = new System.Windows.Forms.NumericUpDown();
            this.labelHours = new System.Windows.Forms.Label();
            this.labelMinutes = new System.Windows.Forms.Label();
            this.button_Start_Alarm = new System.Windows.Forms.Button();
            this.label_AlarmsOutput = new System.Windows.Forms.Label();
            this.numericUpDown_Seconds = new System.Windows.Forms.NumericUpDown();
            this.labelSeconds = new System.Windows.Forms.Label();
            this.label_Output_Countdown = new System.Windows.Forms.Label();
            this.label_Countdown = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Hours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Minutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Seconds)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Add_Alarm
            // 
            this.button_Add_Alarm.Location = new System.Drawing.Point(8, 128);
            this.button_Add_Alarm.Name = "button_Add_Alarm";
            this.button_Add_Alarm.Size = new System.Drawing.Size(84, 25);
            this.button_Add_Alarm.TabIndex = 0;
            this.button_Add_Alarm.Text = "Add Alarm";
            this.button_Add_Alarm.UseVisualStyleBackColor = true;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(65, 23);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(64, 13);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "Alarm Name";
            // 
            // button_Remove_Alarm
            // 
            this.button_Remove_Alarm.Location = new System.Drawing.Point(98, 128);
            this.button_Remove_Alarm.Name = "button_Remove_Alarm";
            this.button_Remove_Alarm.Size = new System.Drawing.Size(84, 25);
            this.button_Remove_Alarm.TabIndex = 0;
            this.button_Remove_Alarm.Text = "Stop Remove";
            this.button_Remove_Alarm.UseVisualStyleBackColor = true;
            this.button_Remove_Alarm.Click += new System.EventHandler(this.ButtonRemoveClick);
            // 
            // button_Edit_Alarm
            // 
            this.button_Edit_Alarm.Location = new System.Drawing.Point(188, 128);
            this.button_Edit_Alarm.Name = "button_Edit_Alarm";
            this.button_Edit_Alarm.Size = new System.Drawing.Size(84, 25);
            this.button_Edit_Alarm.TabIndex = 0;
            this.button_Edit_Alarm.Text = "Edit Alarm";
            this.button_Edit_Alarm.UseVisualStyleBackColor = true;
            // 
            // textBox_AlarmName
            // 
            this.textBox_AlarmName.Location = new System.Drawing.Point(28, 71);
            this.textBox_AlarmName.Name = "textBox_AlarmName";
            this.textBox_AlarmName.Size = new System.Drawing.Size(156, 20);
            this.textBox_AlarmName.TabIndex = 3;
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(244, 23);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(59, 13);
            this.labelTime.TabIndex = 5;
            this.labelTime.Text = "Alarm Time";
            // 
            // numericUpDown_Hours
            // 
            this.numericUpDown_Hours.Location = new System.Drawing.Point(190, 71);
            this.numericUpDown_Hours.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numericUpDown_Hours.MaximumSize = new System.Drawing.Size(59, 0);
            this.numericUpDown_Hours.Name = "numericUpDown_Hours";
            this.numericUpDown_Hours.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_Hours.TabIndex = 6;
            // 
            // numericUpDown_Minutes
            // 
            this.numericUpDown_Minutes.Location = new System.Drawing.Point(246, 72);
            this.numericUpDown_Minutes.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown_Minutes.MaximumSize = new System.Drawing.Size(59, 0);
            this.numericUpDown_Minutes.Name = "numericUpDown_Minutes";
            this.numericUpDown_Minutes.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_Minutes.TabIndex = 7;
            // 
            // labelHours
            // 
            this.labelHours.AutoSize = true;
            this.labelHours.Location = new System.Drawing.Point(187, 55);
            this.labelHours.Name = "labelHours";
            this.labelHours.Size = new System.Drawing.Size(18, 13);
            this.labelHours.TabIndex = 8;
            this.labelHours.Text = "H:";
            // 
            // labelMinutes
            // 
            this.labelMinutes.AutoSize = true;
            this.labelMinutes.Location = new System.Drawing.Point(244, 56);
            this.labelMinutes.Name = "labelMinutes";
            this.labelMinutes.Size = new System.Drawing.Size(19, 13);
            this.labelMinutes.TabIndex = 9;
            this.labelMinutes.Text = "M:";
            // 
            // button_Start_Alarm
            // 
            this.button_Start_Alarm.Location = new System.Drawing.Point(278, 128);
            this.button_Start_Alarm.Name = "button_Start_Alarm";
            this.button_Start_Alarm.Size = new System.Drawing.Size(84, 25);
            this.button_Start_Alarm.TabIndex = 0;
            this.button_Start_Alarm.Text = "Start Timer";
            this.button_Start_Alarm.UseVisualStyleBackColor = true;
            this.button_Start_Alarm.Click += new System.EventHandler(this.ButtonStartTimerClick);
            // 
            // label_AlarmsOutput
            // 
            this.label_AlarmsOutput.Location = new System.Drawing.Point(12, 192);
            this.label_AlarmsOutput.Name = "label_AlarmsOutput";
            this.label_AlarmsOutput.Size = new System.Drawing.Size(166, 110);
            this.label_AlarmsOutput.TabIndex = 12;
            this.label_AlarmsOutput.Text = "Debug : Alarm Names";
            this.label_AlarmsOutput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDown_Seconds
            // 
            this.numericUpDown_Seconds.Location = new System.Drawing.Point(302, 72);
            this.numericUpDown_Seconds.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown_Seconds.Name = "numericUpDown_Seconds";
            this.numericUpDown_Seconds.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_Seconds.TabIndex = 13;
            // 
            // labelSeconds
            // 
            this.labelSeconds.AutoSize = true;
            this.labelSeconds.Location = new System.Drawing.Point(299, 55);
            this.labelSeconds.Name = "labelSeconds";
            this.labelSeconds.Size = new System.Drawing.Size(17, 13);
            this.labelSeconds.TabIndex = 15;
            this.labelSeconds.Text = "S:";
            // 
            // label_Output_Countdown
            // 
            this.label_Output_Countdown.Location = new System.Drawing.Point(0, 0);
            this.label_Output_Countdown.Name = "label_Output_Countdown";
            this.label_Output_Countdown.Size = new System.Drawing.Size(100, 23);
            this.label_Output_Countdown.TabIndex = 0;
            // 
            // label_Countdown
            // 
            this.label_Countdown.Location = new System.Drawing.Point(196, 192);
            this.label_Countdown.Name = "label_Countdown";
            this.label_Countdown.Size = new System.Drawing.Size(166, 110);
            this.label_Countdown.TabIndex = 16;
            this.label_Countdown.Text = "Debug : Alarm Countdown";
            this.label_Countdown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AlarmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 311);
            this.Controls.Add(this.label_Countdown);
            this.Controls.Add(this.label_Output_Countdown);
            this.Controls.Add(this.labelSeconds);
            this.Controls.Add(this.numericUpDown_Seconds);
            this.Controls.Add(this.label_AlarmsOutput);
            this.Controls.Add(this.button_Start_Alarm);
            this.Controls.Add(this.labelMinutes);
            this.Controls.Add(this.labelHours);
            this.Controls.Add(this.numericUpDown_Minutes);
            this.Controls.Add(this.numericUpDown_Hours);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBox_AlarmName);
            this.Controls.Add(this.button_Edit_Alarm);
            this.Controls.Add(this.button_Remove_Alarm);
            this.Controls.Add(this.button_Add_Alarm);
            this.Name = "AlarmView";
            this.Text = "AlarmView";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Hours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Minutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Seconds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Add_Alarm;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button button_Remove_Alarm;
        private System.Windows.Forms.Button button_Edit_Alarm;
        private System.Windows.Forms.TextBox textBox_AlarmName;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.NumericUpDown numericUpDown_Hours;
        private System.Windows.Forms.NumericUpDown numericUpDown_Minutes;
        private System.Windows.Forms.Label labelHours;
        private System.Windows.Forms.Label labelMinutes;
        private System.Windows.Forms.Button button_Start_Alarm;
        private System.Windows.Forms.Label label_AlarmsOutput;
        private System.Windows.Forms.NumericUpDown numericUpDown_Seconds;
        private System.Windows.Forms.Label labelSeconds;
        private System.Windows.Forms.Label label_Output_Countdown;
        private System.Windows.Forms.Label label_Countdown;
    }
}