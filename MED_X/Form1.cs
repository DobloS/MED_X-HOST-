using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MED_X
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Пациент")
            {
                Form2 f = new Form2();
                f.Show();
                this.Close();
            }
            else if (comboBox1.Text == "Врач")
            {
                Form3 f = new Form3();
                f.Show();
                this.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel2.Location = new Point(15, 12);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true;
            panel1.Location = new Point(15, 145);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Пациент")
            {
                label2.Text = "СНИЛС";
                label4.Text = "Пароль";
            }
            else if (comboBox1.Text == "Врач")
            {
                label2.Text = "Логин";
                label4.Text = "Пароль";
            }
        }
    }
}
