using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TestLib;

namespace CourseWork_TestDesigner_
{
    public partial class AddNewQuestion : Form
    {
        public List<Answer> answers = new List<Answer>();
        public AddNewQuestion()
        {
            InitializeComponent();
            //bindingSource2.DataSource = answers;
            //dataGridView1.DataSource = bindingSource2;

            bindingSource1.DataSource = answers;
            dataGridView1.DataSource = bindingSource1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddNewAnswer addNewAnswer = new AddNewAnswer(this);
            addNewAnswer.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Doesnt work
            //int dataGridView = dataGridView1.CurrentCell.RowIndex;
            //foreach (DataGridView item in this.dataGridView1.SelectedRows)
            //{
            //    dataGridView1.Rows.RemoveAt(dataGridView);
            //}


            //if(dataGridView1.SelectedRows.Count > 0)
            //{
            //    int rowIndex = dataGridView1.SelectedRows[0].Index;

            //    foreach (var item in answers)
            //    {
            //        dataGridView1.Rows.RemoveAt(rowIndex);
            //    }

            //    //foreach (DataGridView row in dataGridView1.Rows)
            //    //{


            //    //}

            //}


        }
        string imageToSave;
        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                imageToSave = open.FileName;
                pictureBox1.Image = new Bitmap(open.FileName);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }
        public AddNewQuestion(Form1 fr)
        {
            InitializeComponent();
            form1 = fr;

           // bindingSource2.DataSource = form1.questions;
        }
        Form1 form1 = new Form1();

        private void button6_Click(object sender, EventArgs e)
        {
            

            int trueCounter = 0;
            
                foreach (var item in answers)
                {
                    if(item.IsRight == true)
                    {
                        trueCounter++;
                    }

                }
            
            if(trueCounter>0)
            {
                Question question = new Question() { QuestionText = textBox1.Text, Points = Convert.ToInt32(numericUpDown1.Value), Answers = answers, Img = ImgConverter.BitmapToBase64String(imageToSave) };
                form1.questions.Add(question);
                form1.answers2 = question.Answers;
                form1.bindingSource2.DataSource = form1.answers2;
                form1.bindingSource1.DataSource = form1.questions;
                form1.bindingSource1.ResetBindings(false);
                form1.bindingSource2.ResetBindings(false);
                this.Close();
            }
            if(trueCounter == 0)
            {
                label6.ForeColor = Color.Red;
                label6.Text = "incorrect,at least one answer must be true";
            }
            else
            {
                label6.Text = String.Empty;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text == String.Empty)
            {
                label4.ForeColor = Color.Red;
                label4.Text = "incorrect, text is empty";
                button6.Enabled = false;
            }
            else
            {
                label4.Text = String.Empty;
                button6.Enabled = true;
            }
        }
    }
}
