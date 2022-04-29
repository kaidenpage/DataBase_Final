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
    public partial class Client : Form
    {
        public Client(string username)
        {
            this.username = username;
            InitializeComponent();
        }

        private string username;
        private void Client_Load(object sender, EventArgs e)
        {
            lbluser.Text = lbluser.Text + " " + username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Main back = new Main();
            back.Show();

        }
    }
}
