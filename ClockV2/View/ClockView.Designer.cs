namespace ClockV2
{
    partial class ClockView
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
            this.Panel_Clock = new System.Windows.Forms.Panel();
            this.ButtonOpenForm2 = new System.Windows.Forms.Button();
            this.ClockViewNextAlarmLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Panel_Clock
            // 
            this.Panel_Clock.Location = new System.Drawing.Point(17, 5);
            this.Panel_Clock.Name = "Panel_Clock";
            this.Panel_Clock.Size = new System.Drawing.Size(300, 300);
            this.Panel_Clock.TabIndex = 1;
            this.Panel_Clock.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Clock_Paint);
            // 
            // ButtonOpenForm2
            // 
            this.ButtonOpenForm2.Location = new System.Drawing.Point(293, 242);
            this.ButtonOpenForm2.Name = "ButtonOpenForm2";
            this.ButtonOpenForm2.Size = new System.Drawing.Size(65, 57);
            this.ButtonOpenForm2.TabIndex = 2;
            this.ButtonOpenForm2.Text = "Alarm+";
            this.ButtonOpenForm2.UseVisualStyleBackColor = true;
            this.ButtonOpenForm2.Click += new System.EventHandler(this.ButtonOpenForm2_Click);
            // 
            // ClockViewNextAlarmLabel
            // 
            this.ClockViewNextAlarmLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClockViewNextAlarmLabel.Location = new System.Drawing.Point(17, 308);
            this.ClockViewNextAlarmLabel.Name = "ClockViewNextAlarmLabel";
            this.ClockViewNextAlarmLabel.Size = new System.Drawing.Size(300, 54);
            this.ClockViewNextAlarmLabel.TabIndex = 3;
            this.ClockViewNextAlarmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ClockView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 371);
            this.Controls.Add(this.ClockViewNextAlarmLabel);
            this.Controls.Add(this.ButtonOpenForm2);
            this.Controls.Add(this.Panel_Clock);
            this.Name = "ClockView";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel_Clock;
        private System.Windows.Forms.Button ButtonOpenForm2;
        private System.Windows.Forms.Label ClockViewNextAlarmLabel;
    }
}

