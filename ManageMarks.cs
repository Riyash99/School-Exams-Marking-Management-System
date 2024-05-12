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
    public partial class ManageMarks : Form
    {
        private const string connectionString = "Data Source=DESKTOP-O4VTNK2;Initial Catalog=COSC_31112_GroupProjectDatabase;Integrated Security=True";
        public ManageMarks()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand commandtoCheckStuID = new SqlCommand("SELECT StudentID from Marks WHERE StudentID='" + txtStuID.Text + "'", con);
            String StuID = (String)commandtoCheckStuID.ExecuteScalar();

            if (StuID == txtStuID.Text)
            {
                MessageBox.Show("Marks already listed for the student", "Warning...!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                SqlCommand cmd = new SqlCommand("INSERT into Marks values (@StuID,@StuName,@Stream,@Dependent,@Chemistry,@Physics,@GE)", con);
                cmd.Parameters.AddWithValue("@StuID", txtStuID.Text);
                cmd.Parameters.AddWithValue("@StuName", txtStuName.Text);
                cmd.Parameters.AddWithValue("@Stream", txtStream.Text);
                cmd.Parameters.AddWithValue("@Dependent", int.Parse(txtDependent.Text));
                cmd.Parameters.AddWithValue("@Chemistry", int.Parse(txtChemistry.Text));
                cmd.Parameters.AddWithValue("@Physics", int.Parse(txtPhysics.Text));
                cmd.Parameters.AddWithValue("@GE", int.Parse(txtGE.Text));
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Successfully Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            txtStuID.Clear();
            txtStuName.Clear();
            txtStream.Clear();
            txtDependent.Clear();
            txtChemistry.Clear();
            txtPhysics.Clear();
            txtGE.Clear();
            txtSearch.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Marks set StudentName=@StuName, Stream=@Stream, Dependent=@Dependent, Chemistry=@Chemistry, Physics=@Physics, GE=@GE WHERE StudentID=@StuID", con);
            cmd.Parameters.AddWithValue("@StuID", txtStuID.Text);
            cmd.Parameters.AddWithValue("@StuName", txtStuName.Text);
            cmd.Parameters.AddWithValue("@Stream", txtStream.Text);
            cmd.Parameters.AddWithValue("@Dependent", int.Parse(txtDependent.Text));
            cmd.Parameters.AddWithValue("@Chemistry", int.Parse(txtChemistry.Text));
            cmd.Parameters.AddWithValue("@Physics", int.Parse(txtPhysics.Text));
            cmd.Parameters.AddWithValue("@GE", int.Parse(txtGE.Text));
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Successfully Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtStuID.Clear();
            txtStuName.Clear();
            txtStream.Clear();
            txtDependent.Clear();
            txtChemistry.Clear();
            txtPhysics.Clear();
            txtGE.Clear();
            txtSearch.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE Marks WHERE StudentID=@StuID", con);
            cmd.Parameters.AddWithValue("@StuID", txtStuID.Text);
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Successfully Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtStuID.Clear();
            txtStuName.Clear();
            txtStream.Clear();
            txtDependent.Clear();
            txtChemistry.Clear();
            txtPhysics.Clear();
            txtGE.Clear();
            txtSearch.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Marks WHERE StudentID=@StuID", con);
            cmd.Parameters.AddWithValue("@StuID", txtSearch.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                label5.Text = reader["Stream"].ToString();
                if (label5.Text == "Bio")
                {
                    label6.Text = "Biology";
                    label5.Text = "Stream";
                }
                else if (label5.Text == "Maths")
                {
                    label6.Text = "Combined-Maths";
                    label5.Text = "Stream";
                }
                else { MessageBox.Show("Invalid Stream.", "Warning...!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            txtStuID.Clear();
            txtStuName.Clear();
            txtStream.Clear();
            txtDependent.Clear();
            txtChemistry.Clear();
            txtPhysics.Clear();
            txtGE.Clear();
        }

        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Marks", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            txtStuID.Clear();
            txtStuName.Clear();
            txtStream.Clear();
            txtDependent.Clear();
            txtChemistry.Clear();
            txtPhysics.Clear();
            txtGE.Clear();
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
                txtDependent.Text = row.Cells["Dependent"].Value.ToString();
                txtChemistry.Text = row.Cells["Chemistry"].Value.ToString();
                txtPhysics.Text = row.Cells["Physics"].Value.ToString();
                txtGE.Text = row.Cells["GE"].Value.ToString();
            }

            txtSearch.Clear();
        }

        private void btnCreatePDF_Click(object sender, EventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 20, 42, 35);

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream("Marks.pdf", FileMode.Create));

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

            txtStuID.Clear();
            txtStuName.Clear();
            txtStream.Clear();
            txtDependent.Clear();
            txtChemistry.Clear();
            txtPhysics.Clear();
            txtGE.Clear();
            txtSearch.Clear();
        }

        private void label6_Click(object sender, EventArgs e)
        {

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
            else
            {
                TeacherActivities form = new TeacherActivities();
                form.Show();
                this.Close();
            }
        }
    }
}
