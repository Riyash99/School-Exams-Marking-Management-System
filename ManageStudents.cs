using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace COSC_GroupProject
{
    public partial class ManageStudents : Form
    {
        private const string connectionString = "Data Source=DESKTOP-O4VTNK2;Initial Catalog=COSC_31112_GroupProjectDatabase;Integrated Security=True";
        public ManageStudents()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand commandtoCheckStuID = new SqlCommand("SELECT StudentID from Students WHERE StudentID='" + txtStuID.Text + "'", con);
            String StuID = (String)commandtoCheckStuID.ExecuteScalar();

            if (StuID == txtStuID.Text)
            {
                MessageBox.Show("Marks already listed for the student", "Warning...!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                SqlCommand cmd = new SqlCommand("INSERT into Students values (@StuID,@StuName,@Stream,@Password,@Address,@Telephone,@DOB)", con);
                cmd.Parameters.AddWithValue("@StuID", txtStuID.Text);
                cmd.Parameters.AddWithValue("@StuName", txtStuName.Text);
                cmd.Parameters.AddWithValue("@Stream", txtStream.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                cmd.Parameters.AddWithValue("@Telephone", txtTelephone.Text);
                cmd.Parameters.AddWithValue("@DOB", txtDOB.Text);
                cmd.ExecuteNonQuery();

                con.Close();

                txtStuID.Clear();
                txtStuName.Clear();
                txtStream.Clear();
                txtPassword.Clear();
                txtaddress.Clear();
                txtTelephone.Clear();
                txtDOB.Clear();
                txtSearch.Clear();

                MessageBox.Show("Successfully Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Students set StudentName=@StuName, Stream=@Stream, Password=@Password, Address=@Address, Telephone=@Telephone, DOB=@DOB WHERE StudentID=@StuID", con);
            cmd.Parameters.AddWithValue("@StuID", txtStuID.Text);
            cmd.Parameters.AddWithValue("@StuName", txtStuName.Text);
            cmd.Parameters.AddWithValue("@Stream", txtStream.Text);
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
            cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
            cmd.Parameters.AddWithValue("@Telephone", txtTelephone.Text);
            cmd.Parameters.AddWithValue("@DOB", txtDOB.Text);
            cmd.ExecuteNonQuery();

            con.Close();

            txtStuID.Clear();
            txtStuName.Clear();
            txtStream.Clear();
            txtPassword.Clear();
            txtaddress.Clear();
            txtTelephone.Clear();
            txtDOB.Clear();
            txtSearch.Clear();

            MessageBox.Show("Successfully Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE Students WHERE StudentID=@StuID", con);
            cmd.Parameters.AddWithValue("@StuID", txtStuID.Text);
            cmd.ExecuteNonQuery();

            con.Close();

            txtStuID.Clear();
            txtStuName.Clear();
            txtStream.Clear();
            txtPassword.Clear();
            txtaddress.Clear();
            txtTelephone.Clear();
            txtDOB.Clear();
            txtSearch.Clear();

            MessageBox.Show("Successfully Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT StudentID,StudentName,Stream,Address,Telephone,DOB FROM Students WHERE StudentID=@StuID", con);
            cmd.Parameters.AddWithValue("@StuID", txtSearch.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            txtStuID.Clear();
            txtStuName.Clear();
            txtStream.Clear();
            txtPassword.Clear();
            txtaddress.Clear();
            txtTelephone.Clear();
            txtDOB.Clear();
        }

        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT StudentID,StudentName,Stream,Address,Telephone,DOB FROM Students", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            txtStuID.Clear();
            txtStuName.Clear();
            txtStream.Clear();
            txtPassword.Clear();
            txtaddress.Clear();
            txtTelephone.Clear();
            txtDOB.Clear();
            txtSearch.Clear();
        }

        private void dataGridView_CellContent_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                txtStuID.Text = row.Cells["StudentID"].Value.ToString();
                txtStuName.Text = row.Cells["StudentName"].Value.ToString();
                txtStream.Text = row.Cells["Stream"].Value.ToString();
                txtaddress.Text = row.Cells["Address"].Value.ToString();
                txtTelephone.Text = row.Cells["Telephone"].Value.ToString();
                txtDOB.Text = row.Cells["DOB"].Value.ToString();
                
                txtSearch.Clear();
            }
        }

        private void btnCreatePDF_Click(object sender, EventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 20, 42, 35);

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream("Students.pdf", FileMode.Create));

            doc.Open();

           PdfPTable table = new PdfPTable(dataGridView1.Columns.Count);

            for(int j = 0; j < dataGridView1.Columns.Count; j++)
            {
                table.AddCell(new Phrase(dataGridView1.Columns[j].HeaderText));
            }
           table.HeaderRows = 1;

            for(int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for(int k = 0; k < dataGridView1.Columns.Count; k++)
                {
                    if (dataGridView1[k, i].Value != null)
                    {
                        table.AddCell(new Phrase(dataGridView1[k, i].Value.ToString()));
                   }
               }
           }
           doc.Add(table);

           doc.Close();

           MessageBox.Show("PDF Downloaded", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

           txtStuID.Clear();
           txtStuName.Clear();
           txtStream.Clear();
           txtPassword.Clear();
           txtaddress.Clear();
           txtTelephone.Clear();
           txtDOB.Clear();
           txtSearch.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            String userid = Form1.SetValueForText1;
            if (userid[0] == 'P')
            {
                PrincipalActivities formp = new PrincipalActivities();
                formp.Show();
                this.Close();
            }
            else {
                TeacherActivities form = new TeacherActivities();
                form.Show();
                this.Close();
            }
        }
    }
}