using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Security;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COSC_GroupProject
{
    public partial class StudentActivities : Form
    {
        public String StuID { get; set; }

        private const string connectionString = "Data Source=DESKTOP-O4VTNK2;Initial Catalog=COSC_31112_GroupProjectDatabase;Integrated Security=True";
        public StudentActivities()
        {
            InitializeComponent();
        }

        private void btnStudentMarksheet_Click(object sender, EventArgs e)
        {
            StudentMarks studentMarks = new StudentMarks();
            studentMarks.StuIDD = StuID;
            studentMarks.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            studentPrizeWinner formS = new studentPrizeWinner();
            formS.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Close();
        }
    }
}
