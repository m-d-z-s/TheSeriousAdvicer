namespace TheSeriousAdvicer
{
    partial class WatchedListQuestionnaire
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
            this.Title = new System.Windows.Forms.Label();
            this.QYes = new System.Windows.Forms.Button();
            this.QNo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Title.Location = new System.Drawing.Point(197, 21);
            this.Title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(169, 48);
            this.Title.TabIndex = 1;
            this.Title.Text = "I love Ira!\r\nShe loves me also!";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // QYes
            // 
            this.QYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.QYes.Location = new System.Drawing.Point(35, 107);
            this.QYes.Name = "QYes";
            this.QYes.Size = new System.Drawing.Size(193, 44);
            this.QYes.TabIndex = 2;
            this.QYes.Text = "Yes";
            this.QYes.UseVisualStyleBackColor = true;
            this.QYes.Click += new System.EventHandler(this.QYes_Click);
            // 
            // QNo
            // 
            this.QNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.QNo.Location = new System.Drawing.Point(604, 107);
            this.QNo.Name = "QNo";
            this.QNo.Size = new System.Drawing.Size(193, 44);
            this.QNo.TabIndex = 3;
            this.QNo.Text = "No";
            this.QNo.UseVisualStyleBackColor = true;
            this.QNo.Click += new System.EventHandler(this.QNo_Click);
            // 
            // WatchedListQuestionnaire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 190);
            this.Controls.Add(this.QNo);
            this.Controls.Add(this.QYes);
            this.Controls.Add(this.Title);
            this.Name = "WatchedListQuestionnaire";
            this.Text = "WatchedListQuestionnaire";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button QYes;
        private System.Windows.Forms.Button QNo;
    }
}