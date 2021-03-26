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


namespace Student_system
{
    public partial class FrmTeacherDetail : Form
    {
        public FrmTeacherDetail()
        {
            InitializeComponent();
        }
        SqlConnection connection_path = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;
                    Initial Catalog=Db_SystemOfStudent;Integrated Security=True");

        private void FrmTeacherDetail_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'db_SystemOfStudentDataSet.TBL_Lesson' table. You can move, or remove it, as needed.
            this.tBL_LessonTableAdapter.Fill(this.db_SystemOfStudentDataSet.TBL_Lesson);
            lblPass.Text = db_SystemOfStudentDataSet.TBL_Lesson.Count(x => x.Status == true).ToString();

            lblFail.Text = db_SystemOfStudentDataSet.TBL_Lesson.Count(x => x.Status == false).ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection_path.Open();
            SqlCommand cmnd = new SqlCommand("insert into TBL_Lesson (Student_Number,Student_Name,Student_Surname) values (@P1,@P2,@P3)", connection_path);
            cmnd.Parameters.AddWithValue("@P1", mskNumber.Text);
            cmnd.Parameters.AddWithValue("@P2", txtName.Text);
            cmnd.Parameters.AddWithValue("@P3", txtSurname.Text);
            cmnd.ExecuteNonQuery();
            connection_path.Close();
            MessageBox.Show("Student successfully added!");
            this.tBL_LessonTableAdapter.Fill(this.db_SystemOfStudentDataSet.TBL_Lesson);    //Listeye otomatik günceller ve gösterir.

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selected = dataGridView1.SelectedCells[0].RowIndex;
            mskNumber.Text = dataGridView1.Rows[selected].Cells[1].Value.ToString();
            txtName.Text = dataGridView1.Rows[selected].Cells[2].Value.ToString();
            txtSurname.Text = dataGridView1.Rows[selected].Cells[3].Value.ToString();
            txtEx1.Text = dataGridView1.Rows[selected].Cells[4].Value.ToString();
            txtEx2.Text = dataGridView1.Rows[selected].Cells[5].Value.ToString();
            txtEx3.Text = dataGridView1.Rows[selected].Cells[6].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            lblPass.Text = db_SystemOfStudentDataSet.TBL_Lesson.Count(x => x.Status == true).ToString();

            lblFail.Text = db_SystemOfStudentDataSet.TBL_Lesson.Count(x => x.Status == false).ToString();
            string status;
            
            double avg, e1, e2, e3;
            e1 = Convert.ToDouble(txtEx1.Text);
            e2 = Convert.ToDouble(txtEx2.Text);
            e3 = Convert.ToDouble(txtEx3.Text);

            avg = (e1 + e2 + e3) / 3;
            lblAvg.Text = avg.ToString();

            if (avg >=50)
            {
                status = "True";
            }
            else
            {
                status = "False";
            }

            connection_path.Open();
            SqlCommand cmnd = new SqlCommand("update TBL_Lesson set Student_Exam_1=@P1," +
                "Student_Exam_2=@P2,Student_Exam_3=@P3,Average =@A1,Status=@S1 where Student_Number = @N1 ");
            cmnd.Parameters.AddWithValue("@P1", txtEx1.Text);
            cmnd.Parameters.AddWithValue("@P2", txtEx2.Text);
            cmnd.Parameters.AddWithValue("@P3", txtEx3.Text);
            cmnd.Parameters.AddWithValue("@A1", decimal.Parse(lblAvg.Text));
            cmnd.Parameters.AddWithValue("@S1", status);
            cmnd.Parameters.AddWithValue("@N1", mskNumber.Text);
            cmnd.Connection = connection_path;
            cmnd.ExecuteNonQuery();
            
            connection_path.Close();
            MessageBox.Show("Student successfully updated!");
            this.tBL_LessonTableAdapter.Fill(this.db_SystemOfStudentDataSet.TBL_Lesson);



        }


    }
}
