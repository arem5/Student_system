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
    public partial class Frm_StudentDetail : Form
    {
        public Frm_StudentDetail()
        {
            InitializeComponent();
        }

        public string number;
        SqlConnection connection_path = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;
                    Initial Catalog=Db_SystemOfStudent;Integrated Security=True");
        // Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Db_SystemOfStudent;Integrated Security=True
        private void Frm_StudentDetail_Load(object sender, EventArgs e)
        {
            lblNumber.Text = number;
            connection_path.Open();
            SqlCommand comnd = new SqlCommand("select * from TBL_Lesson where Student_Number =@p1");
            comnd.Parameters.AddWithValue("@p1", number);
            comnd.Connection = connection_path;
            SqlDataReader dr = comnd.ExecuteReader();

            while(dr.Read())
            {
                lblName.Text = dr[2].ToString() + " " + dr[3].ToString();
                lblExam_1.Text = dr[4].ToString();
                lblExam_2.Text = dr[5].ToString();
                lblExam_3.Text = dr[6].ToString();
                lblAvg.Text = dr[7].ToString();
                lblStatus.Text = dr[8].ToString();

            }
            connection_path.Close();

        }
    }
}
