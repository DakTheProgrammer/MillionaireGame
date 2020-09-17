namespace millionaire
{
    partial class MainForm
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
            this.QandA_GB = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // QandA_GB
            // 
            this.QandA_GB.BackgroundImage = global::millionaire.Properties.Resources.answerbox;
            this.QandA_GB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.QandA_GB.Location = new System.Drawing.Point(4, 356);
            this.QandA_GB.Name = "QandA_GB";
            this.QandA_GB.Size = new System.Drawing.Size(794, 133);
            this.QandA_GB.TabIndex = 0;
            this.QandA_GB.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::millionaire.Properties.Resources.who_wants_to_be_a_millionaire_template_1_728;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 501);
            this.Controls.Add(this.QandA_GB);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox QandA_GB;
    }
}

