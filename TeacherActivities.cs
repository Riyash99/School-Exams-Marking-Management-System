using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COSC_GroupProject
{
    public partial class TeacherActivities : Form
    {
        private const string connectionString = "Data Source=DESKTOP-O4VTNK2;Initial Catalog=COSC_31112_GroupProjectDatabase;Integrated Security=True";
        public TeacherActivities()
        {
            InitializeComponent();
        }

        private void TeacherActivities_Load(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Close();
        }

        private void btnManageStudent_Click(object sender, EventArgs e)
        {
            ManageStudents manageStudents = new ManageStudents();
            manageStudents.Show();
            this.Close();
        }

        private void btnManageMarks_Click(object sender, EventArgs e)
        {
            ManageMarks manageMarks = new ManageMarks();
            manageMarks.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
