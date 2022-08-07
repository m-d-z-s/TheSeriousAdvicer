namespace TheSeriousAdvicer
{
    partial class Form1
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Ran = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.AddSerial = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(489, 332);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(419, 37);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = "Choose the series";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Ran
            // 
            this.Ran.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Ran.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ran.Location = new System.Drawing.Point(647, 394);
            this.Ran.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Ran.Name = "Ran";
            this.Ran.Size = new System.Drawing.Size(131, 54);
            this.Ran.TabIndex = 1;
            this.Ran.Text = "Random";
            this.Ran.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.Ran.UseVisualStyleBackColor = true;
            this.Ran.Visible = false;
            this.Ran.Click += new System.EventHandler(this.Ran_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.Image = global::TheSeriousAdvicer.Properties.Resources.HSlNJy1;
            this.label1.Location = new System.Drawing.Point(661, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Add new series";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.textBox1.Location = new System.Drawing.Point(489, 114);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(419, 34);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "Series name";
            this.textBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseDown);
            // 
            // AddSerial
            // 
            this.AddSerial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddSerial.Location = new System.Drawing.Point(647, 159);
            this.AddSerial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddSerial.Name = "AddSerial";
            this.AddSerial.Size = new System.Drawing.Size(131, 54);
            this.AddSerial.TabIndex = 5;
            this.AddSerial.Text = "Add";
            this.AddSerial.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.AddSerial.UseVisualStyleBackColor = true;
            this.AddSerial.Visible = false;
            this.AddSerial.Click += new System.EventHandler(this.AddSerial_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.Image = global::TheSeriousAdvicer.Properties.Resources.HSlNJy1;
            this.label2.Location = new System.Drawing.Point(573, 282);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(259, 29);
            this.label2.TabIndex = 6;
            this.label2.Text = "Choose from existing";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::TheSeriousAdvicer.Properties.Resources.HSlNJy1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(975, 537);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AddSerial);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Ran);
            this.Controls.Add(this.comboBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button Ran;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button AddSerial;
        private System.Windows.Forms.Label label2;
    }
}

