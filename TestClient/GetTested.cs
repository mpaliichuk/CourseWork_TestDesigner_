using DALTestSystemDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestClient
{
    public partial class GetTested : Form
    {
        public GetTested()
        {
            InitializeComponent();
        }
        public GetTested(Test test)
        {
            InitializeComponent();
            textBox1.Text = test.Author;
            textBox2.Text = test.Title;
            textBox3.Text = test.Description;
            textBox4.Text = test.Info;
            textBox6.Text = "100";
            
            numericUpDown1.Value = test.PassPercent;
            //dataGridView1.DataSource = test.Questions;
            //dataGridView2.DataSource = test.Questions;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
