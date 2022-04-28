using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace DBFinal
{
    public partial class ClientLogin : Form
    {
        public ClientLogin()
        {
            InitializeComponent();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClientRegister fm = new ClientRegister();
            fm.ShowDialog();
        }

        private void ClientLogin_Load(object sender, EventArgs e)
        {
          
        }
    }
}
