using DALTestSystemDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        public List<Question> questionsAnswers;
        public List<Answer> answers;
        public List<Answer> answersToSelect = new List<Answer>();
        public List<Question> questionsToSelect = new List<Question>();
        public GetTested(Test test,List<Question> questionsToPass,List<Answer> answersToPass)
        {
            InitializeComponent();
            questionsAnswers = questionsToPass;
            answers = answersToPass;
           // dataGridView1.DataSource = questionsToPass;
          //  dataGridView2.DataSource = answersToPass;
            dataGridView2.DataSource = answersToSelect;

            textBox1.Text = test.Author;
            textBox2.Text = test.Title;
            textBox3.Text = test.Description;
            textBox4.Text = test.Info;
     
            textBox6.Text = "100";
            
            numericUpDown1.Value = test.PassPercent;
            foreach (var questionToPass in questionsToPass)
            {
                if (questionToPass.TestId == test.Id)
                {
                    questionsToSelect.Add(questionToPass);
                }
            }
            textBox5.Text = questionsToSelect.Count.ToString();
            dataGridView1.DataSource = questionsToSelect;
            //dataGridView2.DataSource = test.Questions;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
        int index;
      
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            answersToSelect.Clear();
            index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            int idToCompare;
            //foreach (Question item in test.Questions)
            //{

            //}
          

            if (answers.Count() > 0)
            {
                idToCompare = Convert.ToInt32(selectedRow.Cells[0].Value);
                
                    foreach (var answer in answers)
                    {
                        if (answer.QuestionId == idToCompare)
                        {
                            answersToSelect.Add(answer);
                        }
                    }
                
                //dataGridView2.DataSource = answersToSelect;
                // pictureBox1.Image = ImgConverter.Base64StringToBitmap(questions[e.RowIndex].Img);
                
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = answersToSelect;
            }



            //DataGridViewRow selectedRow = dataGridView1.Rows[index];
            //textBox1.Text = selectedRow.Cells[3].Value.ToString();
            //textBox2.Text = selectedRow.Cells[4].Value.ToString();
            //textBox4.Text = selectedRow.Cells[1].Value.ToString();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}
