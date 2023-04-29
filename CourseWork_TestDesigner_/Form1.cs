using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestLib;

namespace CourseWork_TestDesigner_
{
    public partial class Form1 : Form
    {
        public List<Question> questions = new List<Question>();
        public List<Answer> answers2 = new List<Answer>();
        public Form1()
        {
            InitializeComponent();
            bindingSource1.DataSource = questions;
            dataGridView1.DataSource = bindingSource1;

            bindingSource2.DataSource = answers2;
            dataGridView2.DataSource = bindingSource2;
        }

        //public Form1(AddNewQuestion fr)
        //{


        //}

        private void button1_Click(object sender, EventArgs e)
        {
            //If i remove here this it will add answers
            //If this stays it will add questions to Form1 (Fix it)
            //AddNewQuestion addNewQuestion = new AddNewQuestion(this);
            
            //AddNewQuestion addNewQuestion = new AddNewQuestion();
            //addNewQuestion.ShowDialog();

            AddNewQuestion addNewQuestion = new AddNewQuestion(this);
            addNewQuestion.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void createNewTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
            textBox5.Text = String.Empty;
            textBox6.Text = String.Empty;
            numericUpDown1.Value = 0;
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            pictureBox1.Image = null;
        }

        private void openTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
        

            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "XML Files(*.xml;)|*.xml;";
            if (open.ShowDialog() == DialogResult.OK)
            {
                string result = Path.GetFullPath(open.FileName);
                Test test = Serializer.Deserialize<Test>(File.ReadAllText(result));
               // Question question = Serializer.Deserialize<Question>(File.ReadAllText(result));
                textBox1.Text = test.Author;
                textBox2.Text = test.Title;
                textBox3.Text = test.Description;
                textBox4.Text = test.Info;
                textBox5.Text = test.Questions.Count().ToString();
                dataGridView1.DataSource = test.Questions;
               // dataGridView2.DataSource = question.Answers;
                

                numericUpDown1.Value = test.PassPercent;
            }


        }

        private void saveTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string xmlName = textBox2.Text;
            Test test = new Test();
            test.Author = textBox1.Text;
            test.Title = textBox2.Text;
            test.Description = textBox3.Text;
            test.Info = textBox4.Text;
            test.PassPercent = Convert.ToInt32(numericUpDown1.Value);
            test.Questions = questions;
            File.WriteAllText("D:\\C#_CourseProject_Backups\\XMLTests\\" + xmlName + ".xml",Serializer.Serialize<Test>(test));

        }

        private void closeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
