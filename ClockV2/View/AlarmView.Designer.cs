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
            this.button_Add = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Remove = new System.Windows.Forms.Button();
            this.button_Edit = new System.Windows.Forms.Button();
            this.textBox_AlarmName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown_Hours = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Minutes = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_Start = new System.Windows.Forms.Button();
            this.label_Output = new System.Windows.Forms.Label();
            this.numericUpDown_Seconds = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label_Output_Countdown = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Hours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Minutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Seconds)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(12, 128);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(80, 25);
            this.button_Add.TabIndex = 0;
            this.button_Add.Text = "button_Add";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.Button_Add_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Alarm Name";
            // 
            // button_Remove
            // 
            this.button_Remove.Location = new System.Drawing.Point(98, 128);
            this.button_Remove.Name = "button_Remove";
            this.button_Remove.Size = new System.Drawing.Size(80, 25);
            this.button_Remove.TabIndex = 1;
            this.button_Remove.Text = "button_Remove";
            this.button_Remove.UseVisualStyleBackColor = true;
            this.button_Remove.Click += new System.EventHandler(this.Button_Remove_Click);
            // 
            // button_Edit
            // 
            this.button_Edit.Location = new System.Drawing.Point(192, 128);
            this.button_Edit.Name = "button_Edit";
            this.button_Edit.Size = new System.Drawing.Size(80, 25);
            this.button_Edit.TabIndex = 2;
            this.button_Edit.Text = "button_Edit";
            this.button_Edit.UseVisualStyleBackColor = true;
            // 
            // textBox_AlarmName
            // 
            this.textBox_AlarmName.Location = new System.Drawing.Point(28, 71);
            this.textBox_AlarmName.Name = "textBox_AlarmName";
            this.textBox_AlarmName.Size = new System.Drawing.Size(156, 20);
            this.textBox_AlarmName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(244, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Alarm Time";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(187, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "H:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(244, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "M:";
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(278, 128);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(80, 25);
            this.button_Start.TabIndex = 11;
            this.button_Start.Text = "button_Start";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.Button_StartTimer_Click);
            // 
            // label_Output
            // 
            this.label_Output.Location = new System.Drawing.Point(12, 192);
            this.label_Output.Name = "label_Output";
            this.label_Output.Size = new System.Drawing.Size(166, 110);
            this.label_Output.TabIndex = 12;
            this.label_Output.Text = "label_Output";
            this.label_Output.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(299, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "S:";
            // 
            // label_Output_Countdown
            // 
            this.label_Output_Countdown.Location = new System.Drawing.Point(0, 0);
            this.label_Output_Countdown.Name = "label_Output_Countdown";
            this.label_Output_Countdown.Size = new System.Drawing.Size(100, 23);
            this.label_Output_Countdown.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(196, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 110);
            this.label6.TabIndex = 16;
            this.label6.Text = "label6";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AlarmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 311);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label_Output_Countdown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDown_Seconds);
            this.Controls.Add(this.label_Output);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown_Minutes);
            this.Controls.Add(this.numericUpDown_Hours);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_AlarmName);
            this.Controls.Add(this.button_Edit);
            this.Controls.Add(this.button_Remove);
            this.Controls.Add(this.button_Add);
            this.Name = "AlarmView";
            this.Text = "AlarmView";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Hours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Minutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Seconds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Remove;
        private System.Windows.Forms.Button button_Edit;
        private System.Windows.Forms.TextBox textBox_AlarmName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown_Hours;
        private System.Windows.Forms.NumericUpDown numericUpDown_Minutes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Label label_Output;
        private System.Windows.Forms.NumericUpDown numericUpDown_Seconds;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_Output_Countdown;
        private System.Windows.Forms.Label label6;
    }
}