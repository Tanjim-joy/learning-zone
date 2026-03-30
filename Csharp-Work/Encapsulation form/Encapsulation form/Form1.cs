using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encapsulation_form
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
            Employee employeedel = new Employee();
            employeedel.employeeId = int.Parse(txtId.Text);
            employeedel.employeeName = txtname.Text;
            employeedel.employeeAge = int.Parse(txtage.Text);
            employeedel.employeePositions = textposition.Text;

            Form1 frm = new Form1();
            frm.id.Text = employeedel.employeeId.ToString();
            frm.Name.Text = employeedel.employeeName;
            frm.Age.Text = employeedel.employeeAge.ToString();
            //frm.postions = employeedel.employeePositions;
            frm.ShowDialog();
            
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}



