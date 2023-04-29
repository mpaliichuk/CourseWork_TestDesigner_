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
    public partial class AddNewAnswer : Form
    {
        public AddNewAnswer()
        {
            InitializeComponent();
        }
        public AddNewAnswer(AddNewQuestion fr)
        {
            InitializeComponent();
            frm = fr;
           // bindingSource1.DataSource = frm.answers;
        }
        AddNewQuestion frm = new AddNewQuestion();
        private void button1_Click(object sender, EventArgs e)
        {
            Answer answer = new Answer() { TextAnswer = textBox1.Text, IsRight = checkBox1.Checked };
            frm.answers.Add(answer);
            frm.bindingSource1.ResetBindings(false);
            this.Close();


            //Question question = new Question() { QuestionText = textBox1.Text, Points = Convert.ToInt32(33), Answers = new List<Answer>(), Img = "123" };
            //form1.questions.Add(question);
            //form1.bindingSource1.ResetBindings(false);
            //this.Close();
        }
    }
}
