using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace COSC_GroupProject
{
    public partial class StudentMarks : Form
    {
        public String StuIDD { get; set; }

        private const string connectionString = "Data Source=DESKTOP-O4VTNK2;Initial Catalog=COSC_31112_GroupProjectDatabase;Integrated Security=True";

        public StudentMarks()
        {
            InitializeComponent();
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * from Marks WHERE StudentID='" + StuIDD + "'", con);
            cmd.Parameters.AddWithValue("id", lblStuID.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read()) { 
                lblStuID.Text = reader["StudentId"].ToString();
                lblStuName.Text = reader["StudentName"].ToString();
                lblStream.Text = reader["Stream"].ToString();
                lblPhysics.Text = reader["Physics"].ToString();
                lblChemistry.Text = reader["Chemistry"].ToString();
                lblGE.Text = reader["GE"].ToString();
                lblMathsBio.Text = reader["Dependent"].ToString();
                
                if (lblStream.Text == "Bio")
                {
                    label8.Text = "Biology";
                }
                else if (lblStream.Text == "Maths")
                {
                    label8.Text = "Combined-Maths";
                }
                else { MessageBox.Show("Invalid Stream.", "Warning...!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
            {
                MessageBox.Show("No data Found", "Warning...!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        private void btnStuHome_Click(object sender, EventArgs e)
        {
            Form1 formStu = new Form1();
            formStu.Show();
            this.Close();
        }
    }
}
