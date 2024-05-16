using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MED_X
{
    public partial class Form2 : Form
    {
        ServiceMed Service = new ServiceMed();
        Patient patient;
        public Form2()
        {
            InitializeComponent();
            //this.patient = patient;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {  
            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null)
            {
                var ticket = new Ticket(comboBox2.Text, comboBox1.Text);
                Service.AddNewTicket(ticket);
                //patient.AddTicket(ticket);
                comboBox1.Items.Remove(comboBox1.SelectedItem);
            }
        }
    }
}
