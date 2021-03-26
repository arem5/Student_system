using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_system
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_StudentDetail frm = new Frm_StudentDetail(); //Bu sayede bu formdaki numaraya ulaşabiliriz.
            frm.number = maskedTextBox1.Text;
            frm.Show();

        }



        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == "1111")      //Bu özellik text box envirement üzerinden çift tıklayarak açılmıştır.
            {                                       // buranın amacı masked text box içine "1111" değeri girildiğinde Öğretmen sayfasına atması.
                FrmTeacherDetail fr = new FrmTeacherDetail();
                fr.Show();
            }
        }
    }
}
