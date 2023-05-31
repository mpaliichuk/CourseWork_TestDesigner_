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
        Test getTested;
        List<Question> getQuestions;
        List<Answer> getAnswers;
        public TestsForClient()
        {
            InitializeComponent();
        }
        public TestsForClient(User user)
        {
            InitializeComponent();
           
            label4.Text = user.Login;
        }
        public TestsForClient(Test test,User user,List<UserTest> userTest,List<Question> userQuestions,List<Answer> answersForClient)
        {
            InitializeComponent();
            getQuestions = userQuestions;
            List<UserTest> userTestsForCetainUser = new List<UserTest>();
            getAnswers = answersForClient;
            foreach (var item in userTest)
            {
                if(item.UserId == user.Id)
                {
                    userTestsForCetainUser.Add(item);
                }
            }

            //List<Question> questionsForCetainUser = new List<Question>();
            //foreach (var item in userQuestions)
            //{
            //    if (item.Test.Id == user)
            //    {
            //        questionsForCetainUser.Add(item);
            //    }
            //}
            label4.Text = user.FirstName;
            dataGridView1.DataSource = userTestsForCetainUser;
            getTested = test;
        
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetTested tested = new GetTested(getTested, getQuestions,getAnswers);
            tested.ShowDialog();
        }
    }
}
