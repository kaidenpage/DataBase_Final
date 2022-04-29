namespace DBFinal
{
    partial class ProjectsForm
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
            this.ProjectsFormGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectsFormGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ProjectsFormGridView
            // 
            this.ProjectsFormGridView.AllowUserToAddRows = false;
            this.ProjectsFormGridView.AllowUserToDeleteRows = false;
            this.ProjectsFormGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProjectsFormGridView.Location = new System.Drawing.Point(12, 12);
            this.ProjectsFormGridView.Name = "ProjectsFormGridView";
            this.ProjectsFormGridView.ReadOnly = true;
            this.ProjectsFormGridView.RowTemplate.Height = 25;
            this.ProjectsFormGridView.Size = new System.Drawing.Size(776, 426);
            this.ProjectsFormGridView.TabIndex = 0;
            this.ProjectsFormGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProjectsFormGridView_CellContentClick);
            // 
            // ProjectsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ProjectsFormGridView);
            this.Name = "ProjectsForm";
            this.Text = "ProjectsForm";
            this.Load += new System.EventHandler(this.ProjectsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProjectsFormGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView ProjectsFormGridView;
    }
}