using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBFinal
{
    public partial class ProjectsForm : Form
    {
        public ProjectsForm()
        {
            InitializeComponent();
        }

        private void ProjectsForm_Load(object sender, EventArgs e)
        {
            QueryManager queryManager = new QueryManager();
            var relations = queryManager.ProjectsBeingWorkedOn();

            ProjectsFormGridView.ColumnCount = 2;
            ProjectsFormGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ProjectsFormGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ProjectsFormGridView.Columns[0].Name = "Employee Name";
            ProjectsFormGridView.Columns[1].Name = "Project Id";

            for (int i = 0; i < relations.Count; i++)
            {
                ProjectsFormGridView.Rows.Add(relations.ElementAt(i).ElementAt(0), relations.ElementAt(i).ElementAt(1));
            }
        }
    }
}
