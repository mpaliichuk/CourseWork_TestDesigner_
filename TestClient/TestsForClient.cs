using DALTestSystemDB;
using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestClient
{
    public partial class TestsForClient : Form
    {
        private string userName;
        public TestsForClient()
        {
            InitializeComponent();
        }
        public TestsForClient(User user)
        {
            InitializeComponent();
           
            label4.Text = user.Login;
        }
        public TestsForClient(IGenericRepository<Test> test)
        {
            InitializeComponent();

            dataGridView1.DataSource = test;
        
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
