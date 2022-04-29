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
    public partial class Employee : Form
    {
        public Employee(string username)
        {
            this.username = username;
            InitializeComponent();
        }
        private string username;

        private void Employee_Load(object sender, EventArgs e)
        {
            lbluser.Text = lbluser.Text + " " + username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Supplier fm = new Supplier();
            fm.ShowDialog();
        }
       

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Main logout = new Main();
            logout.Show();

        }

        private void ProjectsBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            ProjectsForm frm = new ProjectsForm();
            frm.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Inventory fm = new Inventory();
            fm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeAdmin fm = new EmployeeAdmin();
            fm.ShowDialog();
        }
    }
}
