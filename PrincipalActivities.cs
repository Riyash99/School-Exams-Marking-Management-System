using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COSC_GroupProject
{
    public partial class PrincipalActivities : Form
    {
        public PrincipalActivities()
        {
            InitializeComponent();
        }

        private void btnManageStudent_Click(object sender, EventArgs e)
        {
            ManageStudents manageStudents = new ManageStudents();
            manageStudents.Show();
            this.Close();
        }

        private void btnGetTeacherDetails_Click(object sender, EventArgs e)
        {
            ManageTeachers manageTeachers = new ManageTeachers();
            manageTeachers.Show();
            this.Close();
        }

        private void btnManageMarks_Click(object sender, EventArgs e)
        {
            ManageMarks manageMarks = new ManageMarks();
            manageMarks.Show();
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
