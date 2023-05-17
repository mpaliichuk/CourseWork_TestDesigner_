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
        public TestsForClient(string userName)
        {
            InitializeComponent();
            this.userName = userName;
            label4.Text = userName;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
