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
    public partial class studentPrizeWinner : Form
    {
        private const string connectionString = "Data Source=DESKTOP-O4VTNK2;Initial Catalog=COSC_31112_GroupProjectDatabase;Integrated Security=True";
        public studentPrizeWinner()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            String StuIDD = StuIDinput.Text;
            String userid = Form1.SetValueForText1;
            if (userid == StuIDD)
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * from Marks WHERE StudentID='" + StuIDD + "'", con);
                cmd.Parameters.AddWithValue("id", StuIDinput.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int phy = Convert.ToInt32(reader["Physics"].ToString());
                    int chem = Convert.ToInt32(reader["Chemistry"].ToString());
                    int ge = Convert.ToInt32(reader["GE"].ToString());
                    int MathOrBio = Convert.ToInt32(reader["Dependent"].ToString());
                    float averageMark = (float)(phy + chem + ge + MathOrBio) / 4;
                    lblAverageMark.Text = averageMark.ToString();
                    if (averageMark > 90)
                    {
                        MessageBox.Show("Congratulations! You are a MERIT PRIZE Winner.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Sorry...Try to do your best for Next Exam.", "Warning...!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No data Found", "Warning...!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            else { MessageBox.Show("Invalid StudentID", "Warning...!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 formx = new Form1();
            formx.Show();
            this.Close();
        }
    }
}
