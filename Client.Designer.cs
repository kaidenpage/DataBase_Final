namespace DBFinal
{
    partial class Client
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
            this.lbluser = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbluser
            // 
            this.lbluser.AutoSize = true;
            this.lbluser.Location = new System.Drawing.Point(12, 9);
            this.lbluser.Name = "lbluser";
            this.lbluser.Size = new System.Drawing.Size(63, 15);
            this.lbluser.TabIndex = 0;
            this.lbluser.Text = "Welcome: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(214, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please enter your Info if you havent done so already.";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(237, 111);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(233, 86);
            this.button1.TabIndex = 2;
            this.button1.Text = "Info Tab";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 371);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(707, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "If you have already submitted your information, a representative will reach out t" +
    "o you in the near future. Thank you for your patience.";
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbluser);
            this.Name = "Client";
            this.Text = "Client Portal";
            this.Load += new System.EventHandler(this.Client_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Label lbluser;
        private Label label1;
        private Button button1;
        private Label label2;
    }
}