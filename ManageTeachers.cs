using iTextSharp.text.pdf;
using iTextSharp.text;
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

namespace COSC_GroupProject
{
    public partial class ManageTeachers : Form
    {
        private const string connectionString = "Data Source=DESKTOP-O4VTNK2;Initial Catalog=COSC_31112_GroupProjectDatabase;Integrated Security=True";
        public ManageTeachers()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand commandtoCheckTeachID = new SqlCommand("SELECT TeacherID from Teachers WHERE TeacherID='" + txtTeachID.Text + "'", con);
            String TeachID = (String)commandtoCheckTeachID.ExecuteScalar();

            if (TeachID == txtTeachID.Text)
            {
                MessageBox.Show("Marks already listed for the Teachers", "Warning...!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                SqlCommand cmd = new SqlCommand("INSERT into Teachers values (@TeachID,@TeachName,@Password,@Address,@Telephone,@DOB)", con);
                cmd.Parameters.AddWithValue("@TeachID", txtTeachID.Text);
                cmd.Parameters.AddWithValue("@TeachName", txtTeachName.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@Telephone", txtTelephone.Text);
                cmd.Parameters.AddWithValue("@DOB", txtDOB.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                cmd.ExecuteNonQuery();

                con.Close();

                txtTeachID.Clear();
                txtTeachName.Clear();
                txtAddress.Clear();
                txtTelephone.Clear();
                txtDOB.Clear();
                txtPassword.Clear();
                txtSearch.Clear();

                MessageBox.Show("Successfully Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Teachers set TeacherName=@TeachName, Password=@Password,  Address=@Address, DOB=@DOB  Telephone=@Telephone WHERE teacherID=@TeachID", con);
            cmd.Parameters.AddWithValue("@TeachID", txtTeachID.Text);
            cmd.Parameters.AddWithValue("@TeachName", txtTeachName.Text);
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
            cmd.Parameters.AddWithValue("@Telephone", txtTelephone.Text);
            cmd.Parameters.AddWithValue("@DOB", txtDOB.Text);
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
            cmd.ExecuteNonQuery();

            con.Close();

            txtTeachID.Clear();
            txtTeachName.Clear();
            txtAddress.Clear();
            txtTelephone.Clear();
            txtDOB.Clear();
            txtPassword.Clear();
            txtSearch.Clear();

            MessageBox.Show("Successfully Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE Teachers WHERE teacherID=@TeachID", con);
            cmd.Parameters.AddWithValue("@TeachID", txtTeachID.Text);
            cmd.ExecuteNonQuery();

            con.Close();

            txtTeachID.Clear();
            txtTeachName.Clear();
            txtAddress.Clear();
            txtTelephone.Clear();
            txtDOB.Clear();
            txtPassword.Clear();
            txtSearch.Clear();

            MessageBox.Show("Successfully Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT TeacherID,TeacherName,Address,Telephone,DOB FROM Teachers WHERE TeacherID=@TeachID", con);
            cmd.Parameters.AddWithValue("@TeachID", txtSearch.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            txtTeachID.Clear();
            txtTeachName.Clear();
            txtAddress.Clear();
            txtTelephone.Clear();
            txtDOB.Clear();
            txtPassword.Clear();

        }

        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT TeacherID,TeacherName,Address,Telephone,DOB FROM Teachers", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            txtTeachID.Clear();
            txtTeachName.Clear();
            txtAddress.Clear();
            txtTelephone.Clear();
            txtDOB.Clear();
            txtPassword.Clear();
            txtSearch.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                txtTeachID.Text = row.Cells["TeacherID"].Value.ToString();
                txtTeachName.Text = row.Cells["TeacherName"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
                txtTelephone.Text = row.Cells["Telephone"].Value.ToString();
                txtDOB.Text = row.Cells["DOB"].Value.ToString();

                txtSearch.Clear();
            }
        }

        private void btnCreatePDF_Click(object sender, EventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 20, 42, 35);

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream("Teachers.pdf", FileMode.Create));

            doc.Open();

            PdfPTable table = new PdfPTable(dataGridView1.Columns.Count);

            for (int j = 0; j < dataGridView1.Columns.Count; j++)
            {
                table.AddCell(new Phrase(dataGridView1.Columns[j].HeaderText));
            }
            table.HeaderRows = 1;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int k = 0; k < dataGridView1.Columns.Count; k++)
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

            txtTeachID.Clear();
            txtTeachName.Clear();
            txtAddress.Clear();
            txtTelephone.Clear();
            txtDOB.Clear();
            txtPassword.Clear();
            txtSearch.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            PrincipalActivities form = new PrincipalActivities();
            form.Show();
            this.Close();
        }
    }
}
