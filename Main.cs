using System.Collections;

namespace DBFinal
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClientLogin fm = new ClientLogin();
            fm.ShowDialog();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //Console.WriteLine("Fetching employees");
            //var qmanager = new QueryManager();
            //qmanager.GetAllEmployees();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeLogin fm = new EmployeeLogin();
            fm.ShowDialog();
        }
    }
}