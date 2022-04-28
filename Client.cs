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

        //public Client(string username)
        public Client(string username)
        {
            this.username = username;
            InitializeComponent();
        }

        private string username;

        private void Client_Load(object sender, EventArgs e)
        {
            labelUser.Text = labelUser.Text + username;
        }
    }
}
