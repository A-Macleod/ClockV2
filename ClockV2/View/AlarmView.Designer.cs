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
            this.button3 = new System.Windows.Forms.Button();
            this.textBox_AlarmName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown_Hours = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Minutes = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label_Output = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Hours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Minutes)).BeginInit();
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
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(192, 128);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 25);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
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
            this.numericUpDown_Hours.Location = new System.Drawing.Point(222, 72);
            this.numericUpDown_Hours.Name = "numericUpDown_Hours";
            this.numericUpDown_Hours.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_Hours.TabIndex = 6;
            // 
            // numericUpDown_Minutes
            // 
            this.numericUpDown_Minutes.Location = new System.Drawing.Point(285, 72);
            this.numericUpDown_Minutes.Name = "numericUpDown_Minutes";
            this.numericUpDown_Minutes.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_Minutes.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(219, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "H:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(284, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "M:";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(278, 128);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(80, 25);
            this.button4.TabIndex = 11;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label_Output
            // 
            this.label_Output.Location = new System.Drawing.Point(12, 182);
            this.label_Output.Name = "label_Output";
            this.label_Output.Size = new System.Drawing.Size(346, 110);
            this.label_Output.TabIndex = 12;
            this.label_Output.Text = "label_Output";
            this.label_Output.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AlarmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 311);
            this.Controls.Add(this.label_Output);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown_Minutes);
            this.Controls.Add(this.numericUpDown_Hours);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_AlarmName);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button_Remove);
            this.Controls.Add(this.button_Add);
            this.Name = "AlarmView";
            this.Text = "AlarmView";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Hours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Minutes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Remove;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox_AlarmName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown_Hours;
        private System.Windows.Forms.NumericUpDown numericUpDown_Minutes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label_Output;
    }
}