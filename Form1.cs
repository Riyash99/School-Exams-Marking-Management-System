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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace COSC_GroupProject
{ 
    public partial class Form1 : Form
    {
        public static string SetValueForText1 = "";

        private const string connectionString = "Data Source=DESKTOP-O4VTNK2;Initial Catalog=COSC_31112_GroupProjectDatabase;Integrated Security=True";
        private bool isLoggedIn = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userID = txtStuTeachID.Text;
            string password = txtPassword.Text;

            SetValueForText1 = txtStuTeachID.Text;

            if (txtStuTeachID.Text == "")
            {
                MessageBox.Show("Enter the Username", "Warning...!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Enter the password", "Warning...!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    if (userID[0] == 'T')
                    {
                        SqlConnection con = new SqlConnection(connectionString);
                        SqlCommand cmd = new SqlCommand("SELECT * from Teachers where TeacherID = @teacherID and Password = @password", con);
                        cmd.Parameters.AddWithValue("@teacherID", userID);
                        cmd.Parameters.AddWithValue("@password", password);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            TeacherActivities teacherActivitiesForm = new TeacherActivities();
                            teacherActivitiesForm.Show();
                            this.Hide();
                            MessageBox.Show("login successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            isLoggedIn = true;
                        }
                        else { MessageBox.Show("username or password is invalid", "Warning...!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                        
                    }
                    else if (userID[0] == 'S') {
                        SqlConnection con = new SqlConnection(connectionString);
                        SqlCommand cmd = new SqlCommand("SELECT * from Students where StudentID = @studentID and Password = @password", con);
                        cmd.Parameters.AddWithValue("@studentID", userID);
                        cmd.Parameters.AddWithValue("@password", password);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            StudentActivities studentActivitiesForm = new StudentActivities();
                            studentActivitiesForm.StuID = userID;
                            studentActivitiesForm.Show();
                            this.Hide();
                            MessageBox.Show("login successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            isLoggedIn = true;
                        }
                        else { MessageBox.Show("username or password is invalid", "Warning...!", MessageBoxButtons.OK, MessageBoxIcon.Error); }


                    }
                    else if (userID[0] == 'P') {
                        SqlConnection con = new SqlConnection(connectionString);
                        SqlCommand cmd = new SqlCommand("SELECT * from Principals where principalID = @principalID and Password = @password", con);

                        cmd.Parameters.AddWithValue("@principalID", userID);
                        cmd.Parameters.AddWithValue("@password", password);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            PrincipalActivities principalsActivitiesForm = new PrincipalActivities();
                            principalsActivitiesForm.Show();
                            this.Hide();
                            MessageBox.Show("login successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            isLoggedIn = true;
                        }
                        else { MessageBox.Show("username or password is invalid", "Warning...!", MessageBoxButtons.OK, MessageBoxIcon.Error); }


                    }
                    else
                    {
                        MessageBox.Show("username or password is invalid", "Warning...!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
