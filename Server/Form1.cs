using Microsoft.Extensions.Configuration;
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
using DALTestSystemDB;
using Microsoft.EntityFrameworkCore;
using Repository;
using TestLib;
using Answer = TestLib.Answer;

namespace Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeDataGridViewUsers();
            InitializeDataGridViewGroups();
            InitializeDataGridViewUserTest();
            InitializeDataGridViewTest();
           // InitializeDataGridViewGroupUser();
        }
        List<Group> groups = new List<Group>();
        List<UserTest> userTest = new List<UserTest>();
        List<User> users = new List<User>();
        List<GroupUser> groupUsers = new List<GroupUser>();
        int userToShow;
        public List<int> groupId = new List<int>();
       public List<int> userId = new List<int>();
        private void InitializeDataGridViewGroups()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<TestSystemContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;

            using (GenericUnitOfWork work = new GenericUnitOfWork(new TestSystemContext(options)))
            {
                IGenericRepository<Group> repositoryGroups = work.Repository<Group>();
                IGenericRepository<User> repositoryUsers = work.Repository<User>();
                IGenericRepository<GroupUser> repositoryGroupUser = work.Repository<GroupUser>();
                dataGridView8.DataSource = repositoryGroups.GetAll();
                dataGridView6.DataSource = repositoryGroups.GetAll();
                groups = repositoryGroups.GetAll().ToList();
                groupUsers = repositoryGroupUser.GetAll().ToList();
                //foreach(Group group in groups)
                //{
                //    group.Users = repositoryUsers.GetAll().ToList();
                //}
            
                foreach (var user in groupUsers)
                {
                   // button5.Text += user.UsersId.ToString();
                   
                  
                    groupId.Add(user.GroupsId);

                  
                    userId.Add(user.UsersId);
                    // group.Users = repositoryUsers.GetAll().ToList();
                }
             
            }
        }

        public void InitializeDataGridViewUsers()
        {
            //using(var users = new TestSystemContext())
            //{
            //    dataGridView1.DataSource = users.Users.ToList();
            //}

            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<TestSystemContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;

            using (GenericUnitOfWork work = new GenericUnitOfWork(new TestSystemContext(options)))
            {
                IGenericRepository<User> repositoryUsers = work.Repository<User>();
                dataGridView1.DataSource = repositoryUsers.GetAll();
                dataGridView5.DataSource = repositoryUsers.GetAll();
                users = repositoryUsers.GetAll().ToList();
            }
        }
        private void InitializeDataGridViewUserTest()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<TestSystemContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;

            using (GenericUnitOfWork work = new GenericUnitOfWork(new TestSystemContext(options)))
            {
                IGenericRepository<UserTest> repositoryUserTest = work.Repository<UserTest>();
                dataGridView7.DataSource = repositoryUserTest.GetAll();
                userTest = repositoryUserTest.GetAll().ToList();
            }
        }
        private void InitializeDataGridViewTest()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<TestSystemContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;

            using (GenericUnitOfWork work = new GenericUnitOfWork(new TestSystemContext(options)))
            {
                IGenericRepository<DALTestSystemDB.Test> repositoryTest = work.Repository<DALTestSystemDB.Test>();
                dataGridView2.DataSource = repositoryTest.GetAll();
            }
        }
        private void InitializeDataGridViewGroupUser()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<TestSystemContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;

            using (GenericUnitOfWork work = new GenericUnitOfWork(new TestSystemContext(options)))
            {
                IGenericRepository<DALTestSystemDB.GroupUser> repositoryGroupUser = work.Repository<DALTestSystemDB.GroupUser>();
               // dataGridView8.DataSource = repositoryGroupUser.GetAll();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<TestSystemContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;

            using (GenericUnitOfWork work = new GenericUnitOfWork(new TestSystemContext(options)))
            {
               IGenericRepository<Group> repositoryGroup = work.Repository<Group>();
                repositoryGroup.Add(new Group {Name ="Students" });
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            e.Node.Tag = this.treeView1.SelectedNode.Name;
            activePanel.Visible = false;
            switch(e.Node.Tag)
            {
                case "General":
                    activePanel = panelGeneral;
                    break;
                case "Users":
                    activePanel = panelUsers;
                    break;
                case "Groups":
                    activePanel = panelGroups;
                    break;
                case "Tests":
                    activePanel = panelTests;
                    break;
                case "Tests explorer":
                    activePanel = panelTestsExplorer;
                    break;
                case "Load test":
                    activePanel = panelLoadTests;
                    break;
                case "Assignteststousers":
                    activePanel = panelAssignTests;
                    break;
                case "Reviewtestresults":
                    activePanel = panelReviewTests;
                    break;
                case "Server":
                    activePanel = panelServer;
                    break;

            }
            activePanel.Dock = DockStyle.Fill;
            activePanel.Visible = true;
        }

        private void AddUserBtn_Click(object sender, EventArgs e)
        {
            AddNewUser addNewUser = new AddNewUser();
            addNewUser.ShowDialog();
        }

        private void EditUserBtn_Click(object sender, EventArgs e)
        {
            EditSelectedUser editSelectedUser = new EditSelectedUser();
            editSelectedUser.ShowDialog();
        }

        private void DeleteUserBtn_Click(object sender, EventArgs e)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<TestSystemContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;
            using (GenericUnitOfWork work = new GenericUnitOfWork(new TestSystemContext(options)))
            {
                IGenericRepository<User> repoUser = work.Repository<User>();
                DataGridViewRow selectedRow = dataGridView1.Rows[index];
                var toDelete = repoUser.FindById(Convert.ToInt32(selectedRow.Cells[0].Value));
                repoUser.Remove(toDelete);
            }

        }
        int index;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddNewGroup addNewGroup = new AddNewGroup();
            addNewGroup.ShowDialog();
        }
        public List<TestLib.Question> questions = new List<TestLib.Question>();
        public List<DALTestSystemDB.Question> questionsDAL = new List<DALTestSystemDB.Question>();
        private void button3_Click(object sender, EventArgs e)
        {
           
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "XML Files(*.xml;)|*.xml;";
            if (open.ShowDialog() == DialogResult.OK)
            {
                string result = Path.GetFullPath(open.FileName);
                TestLib.Test test = Serializer.Deserialize<TestLib.Test>(File.ReadAllText(result));
                // Question question = Serializer.Deserialize<Question>(File.ReadAllText(result));
                textBox19.Text = test.Author;
                textBox18.Text = test.Title;
                textBox20.Text = test.Description;
                textBox21.Text = test.Info;
                textBox22.Text = test.Questions.Count().ToString();
                textBox23.Text = test.PassPercent.ToString();
                dataGridView3.DataSource = test.Questions;
                //dataGridView2.DataSource = question.Answers;
                // List<Question> forTEst =  new List<Question>();
                dataGridView4.DataSource = test.Questions.Count() > 0 ? test.Questions[0].Answers : new List<Answer>();
                questions = test.Questions;
                //string imageToSave = test.Questions[0].Img;
                //pictureBox1.Image = ImgConverter.BitmapToBase64String(imageToSave);

                if(ImgConverter.Base64StringToBitmap(questions[index].Img) != null)
                {
                    pictureBox1.Image = ImgConverter.Base64StringToBitmap(questions[index].Img);
                }
                else
                {
                    pictureBox1.Image = null;
                }
                
                numericUpDown1.Value = test.PassPercent;







               // DALTestSystemDB.Test testDAL = Serializer.Deserialize<DALTestSystemDB.Test>(File.ReadAllText(result));
                // Question question = Serializer.Deserialize<Question>(File.ReadAllText(result));
                //testDAL.Author = textBox19.Text;
                //testDAL.Title = textBox18.Text;
                //testDAL.Description = textBox20.Text;
                //testDAL.Info = textBox21.Text;
                ////testDAL.Questions.Count().ToString() = textBox22.Text;
                //testDAL.PassPercent = Convert.ToInt32(textBox23.Text);
                //dataGridView3.DataSource = testDAL.Questions;
                //dataGridView2.DataSource = question.Answers;
                // List<Question> forTEst =  new List<Question>();
               //dataGridView4.DataSource = testDAL.Questions.Count() > 0 ? testDAL.Questions[0].Answers : new List<Answer>();
              // questionsDAL = testDAL.Questions.ToList();
                //string imageToSave = test.Questions[0].Img;
                //pictureBox1.Image = ImgConverter.BitmapToBase64String(imageToSave);
            }






            //OpenFileDialog open = new OpenFileDialog();
            //open.Filter = "XML Files(*.xml;)|*.xml;";
            //if (open.ShowDialog() == DialogResult.OK)
            //{
            //    string result = Path.GetFullPath(open.FileName);
            //    test = Serializer.Deserialize<Test>(File.ReadAllText(result));
            //    // Question question = Serializer.Deserialize<Question>(File.ReadAllText(result));
            //    textBox1.Text = test.Author;
            //    textBox2.Text = test.Title;
            //    textBox3.Text = test.Description;
            //    textBox4.Text = test.Info;
            //    textBox5.Text = test.Questions.Count().ToString();
            //    dataGridView1.DataSource = test.Questions;
            //    dataGridView2.DataSource = test.Questions.Count() > 0 ? test.Questions[0].Answers : new List<Answer>();
            //    questions = test.Questions;
            //    // List<Question> forTEst =  new List<Question>();


            //    numericUpDown1.Value = test.PassPercent;
            //}
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<TestSystemContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;

            using (GenericUnitOfWork work = new GenericUnitOfWork(new TestSystemContext(options)))
            {
                IGenericRepository<DALTestSystemDB.Test> repositoryTest = work.Repository<DALTestSystemDB.Test>();
                
                repositoryTest.Add(new DALTestSystemDB.Test {Title=textBox18.Text,Author=textBox19.Text, Description=textBox20.Text,Info=textBox21.Text,PassPercent=Convert.ToInt32(numericUpDown1.Value),LoadedDate=DateTime.Now,Questions=questionsDAL  });
             
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox19.Text = String.Empty;
            textBox18.Text = String.Empty;
            textBox20.Text = String.Empty;
            textBox21.Text = String.Empty;
            textBox22.Text = String.Empty;
            textBox23.Text = String.Empty;
            dataGridView3.DataSource = null;
            dataGridView4.DataSource = null;
            numericUpDown1.Value = 0;
            pictureBox1.Image = null;
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (questions.Count() > 0)
            {
                dataGridView4.DataSource = questions[e.RowIndex].Answers;
                pictureBox1.Image = ImgConverter.Base64StringToBitmap(questions[e.RowIndex].Img);
            }
        }
        int groupIndex;
       public List<int> allUsersInGroup = new List<int>();
        private void dataGridView8_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            allUsersInGroup.Clear();
            groupIndex = e.RowIndex;
            //if (groups.Count() > 0)
            //{
            //    //  dataGridView9.DataSource = groups[e.RowIndex].Users.ToList();

            //    button5.Text = groupUsers[e.RowIndex].Group.Name.ToString();

            //}
            //dataGridView9.DataSource = userId.ToList();



           
            userToShow = groupUsers[e.RowIndex].UsersId;


            
            foreach (var item in groupUsers)
            {
                if(item.GroupsId == groupIndex +1)
                {
                   allUsersInGroup.Add(item.UsersId);
                }
                else
                {
                   
                }
            }


            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<TestSystemContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;

            using (GenericUnitOfWork work = new GenericUnitOfWork(new TestSystemContext(options)))
            {
                List<User> newList = new List<User>();
                
                foreach (var item in allUsersInGroup)
                {
                    IGenericRepository<User> repositoryUser = work.Repository<User>();
                    User existingUser = work.Repository<User>().FindById(item);
                    newList.Add(existingUser);
                }
                dataGridView9.DataSource = newList;
            };

                


           

        }

        private void dataGridView8_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        int userIdToAssignTest;
        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (groups.Count() > 0)
            {
                //index = e.RowIndex;
                //DataGridViewRow selectedRow = dataGridView1.Rows[index];
                //textBox1.Text = selectedRow.Cells[3].Value.ToString();
                DataGridViewRow selectedRow = dataGridView5.Rows[e.RowIndex];
                userIdToAssignTest = Convert.ToInt32(selectedRow.Cells[0].Value);
                dataGridView6.DataSource = groups[e.RowIndex].Users;
                //dataGridView7.DataSource = userTest[e.RowIndex].Test;
                dataGridView7.DataSource = users[e.RowIndex].UserTests;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AssignTest assignTest = new AssignTest(userIdToAssignTest);
            assignTest.ShowDialog();
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<TestSystemContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;
            using (GenericUnitOfWork work = new GenericUnitOfWork(new TestSystemContext(options)))
            {
                IGenericRepository<Group> repoGroup = work.Repository<Group>();
                DataGridViewRow selectedRow = dataGridView8.Rows[groupIndex];
                var toDelete = repoGroup.FindById(Convert.ToInt32(selectedRow.Cells[0].Value));
                repoGroup.Remove(toDelete);
            }
        }
    }
}
