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
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace Server
{

    public partial class Form1 : Form
    {
        //  IPAddress groupAddress;
        //  int localPort = 7777;
        //  int remotePort = 7778;
        //  int ttl = 32;
        ////  UdpClient udpClient;
        //  IPEndPoint remoteEP;

        //  private const string multicastAddress = "234.5.5.11";
        //  private const int multicastPort = 7778;
        //  private UdpClient udpClient;
        //  private List<User> usersToSend = new List<User>();



        private const string multicastAddress = "234.5.5.11";
        private const int multicastPort = 7778;
        private IPAddress groupAddress;
        private int localPort = 7777;
        private int remotePort = 7778;
        private int ttl = 32;
        private IPEndPoint remoteEP;
        private List<User> usersToSend = new List<User>();
        private List<UserTest> userTestToSend = new List<UserTest>();
        private List<DALTestSystemDB.Test> TestToSend = new List<DALTestSystemDB.Test>();
        private List<DALTestSystemDB.Question> QuestionsToSend = new List<DALTestSystemDB.Question>();
        private UdpClient udpClient;
        public Form1()
        {
            InitializeComponent();
            InitializeDataGridViewUsers();
            InitializeDataGridViewGroups();
            InitializeDataGridViewUserTest();
            InitializeDataGridViewTest();
            InitializeUdpClient();

            groupAddress = IPAddress.Parse(multicastAddress);
            remoteEP = new IPEndPoint(groupAddress, remotePort);
            listView1.Items.Add(remoteEP.ToString());

            Task.Factory.StartNew(() => ReceiveThread(remoteEP));
            SendDbInfo(usersToSend);
            SendDbInfoTests(userTestToSend);
            SendDbInfoTestsForClient(TestToSend);
            SendDbInfoQuestionsForClient(QuestionsToSend);

        }

        private void InitializeUdpClient()
        {
            try
            {
                // Initialize the udpClient object
                udpClient = new UdpClient(localPort);
                udpClient.JoinMulticastGroup(groupAddress, ttl);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during initialization
                ////  MessageBox.Show("Error initializing UDP client: " + ex.Message);
            }
        }
        private void ReceiveThread(IPEndPoint remoteEP)
        {
            var formatter = new BinaryFormatter();
            List<User> testResultfromClient;
            byte[] receiveByte;

            while (true)
            {
                receiveByte = udpClient.Receive(ref remoteEP);
                using (var stream = new MemoryStream(receiveByte))
                {
                    testResultfromClient = (List<User>)formatter.Deserialize(stream);
                }
            }
        }

        private void SendDbInfo(List<User> userToInitialize)
        {
            var binaryFormatter = new BinaryFormatter();
            using (var memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, userToInitialize);
                byte[] buffer = memoryStream.ToArray();
                udpClient.Send(buffer, buffer.Length, groupAddress.ToString(), remotePort);
            }
        }
        private void SendDbInfoTests(List<UserTest> userTestToInitialize)
        {
            var binaryFormatter = new BinaryFormatter();
            using (var memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, userTestToInitialize);
                byte[] buffer = memoryStream.ToArray();
                udpClient.Send(buffer, buffer.Length, groupAddress.ToString(), remotePort);
            }
        }
        private void SendUserData(List<User> users)
        {
            try
            {
                // Check if udpClient is null
                ////if (udpClient == null)
                ////{
                ////    MessageBox.Show("UDP client is not initialized.");
                ////    return;
                ////}

                var binaryFormatter = new BinaryFormatter();
                using (var memoryStream = new MemoryStream())
                {
                    binaryFormatter.Serialize(memoryStream, users);
                    byte[] buffer = memoryStream.ToArray();
                    udpClient.Send(buffer, buffer.Length, multicastAddress, multicastPort);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during sending
                //   MessageBox.Show("Error sending data: " + ex.Message);
            }
        }

        //private void SendUserTestData(List<UserTest> userTests)
        //{
        //    // Match UserTest objects with the corresponding User objects
        //    foreach (var userTest in userTests)
        //    {
        //        userTest.User = users.FirstOrDefault(u => u.Id == userTest.User.Id);
        //    }

        //    // Send the updated userTests list over the network
        //    // ...
        //}
        private void SendUserTestData(List<UserTest> userTests)
        {
            try
            {
                // Check if udpClient is null
                ////if (udpClient == null)
                ////{
                ////    MessageBox.Show("UDP client is not initialized.");
                ////    return;
                ////}

                var binaryFormatter = new BinaryFormatter();
                using (var memoryStream = new MemoryStream())
                {
                    binaryFormatter.Serialize(memoryStream, userTests);
                    byte[] buffer = memoryStream.ToArray();
                    udpClient.Send(buffer, buffer.Length, multicastAddress, multicastPort);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during sending
                //   MessageBox.Show("Error sending data: " + ex.Message);
            }
        }
        private void SendDbInfoTestsForClient(List<DALTestSystemDB.Test> TestsForCleint)
        {
            try
            {
                // Check if udpClient is null
                ////if (udpClient == null)
                ////{
                ////    MessageBox.Show("UDP client is not initialized.");
                ////    return;
                ////}

                var binaryFormatter = new BinaryFormatter();
                using (var memoryStream = new MemoryStream())
                {
                    binaryFormatter.Serialize(memoryStream, TestsForCleint);
                    byte[] buffer = memoryStream.ToArray();
                    udpClient.Send(buffer, buffer.Length, multicastAddress, multicastPort);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during sending
                //   MessageBox.Show("Error sending data: " + ex.Message);
            }
        }
        private void SendDbInfoQuestionsForClient(List<DALTestSystemDB.Question> QuestionsForCleint)
        {
            try
            {
                // Check if udpClient is null
                ////if (udpClient == null)
                ////{
                ////    MessageBox.Show("UDP client is not initialized.");
                ////    return;
                ////}

                var binaryFormatter = new BinaryFormatter();
                using (var memoryStream = new MemoryStream())
                {
                    binaryFormatter.Serialize(memoryStream, QuestionsForCleint);
                    byte[] buffer = memoryStream.ToArray();
                    udpClient.Send(buffer, buffer.Length, multicastAddress, multicastPort);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during sending
                //   MessageBox.Show("Error sending data: " + ex.Message);
            }
        }
        private void SendTestData(List<DALTestSystemDB.Test> testForClient)
        {
            try
            {
                // Check if udpClient is null
                ////if (udpClient == null)
                ////{
                ////    MessageBox.Show("UDP client is not initialized.");
                ////    return;
                ////}

                var binaryFormatter = new BinaryFormatter();
                using (var memoryStream = new MemoryStream())
                {
                    binaryFormatter.Serialize(memoryStream, testForClient);
                    byte[] buffer = memoryStream.ToArray();
                    udpClient.Send(buffer, buffer.Length, multicastAddress, multicastPort);
                }
            }
            catch(Exception ex)
            {

            }
            }
        private void SendQuestions(List<DALTestSystemDB.Question> questions)
        {
            try
            {
                var binaryFormatter = new BinaryFormatter();
                using (var memoryStream = new MemoryStream())
                {
                    binaryFormatter.Serialize(memoryStream, questions);
                    byte[] buffer = memoryStream.ToArray();
                    udpClient.Send(buffer, buffer.Length, multicastAddress, multicastPort);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during sending
                // MessageBox.Show("Error sending data: " + ex.Message);
            }
        }
        //private void SendTestData(List<DALTestSystemDB.Test> testsForUser)
        //{
        //    try
        //    {
        //        // Check if udpClient is null
        //        ////if (udpClient == null)
        //        ////{
        //        ////    MessageBox.Show("UDP client is not initialized.");
        //        ////    return;
        //        ////}

        //        var binaryFormatter = new BinaryFormatter();
        //        using (var memoryStream = new MemoryStream())
        //        {
        //            binaryFormatter.Serialize(memoryStream, testsForUser);
        //            byte[] buffer = memoryStream.ToArray();
        //            udpClient.Send(buffer, buffer.Length, multicastAddress, multicastPort);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle any exceptions that occur during sending
        //        //   MessageBox.Show("Error sending data: " + ex.Message);
        //    }
        //}
        List<Group> groups = new List<Group>();
        List<UserTest> userTest = new List<UserTest>();
        List<User> users = new List<User>();
        List<GroupUser> groupUsers = new List<GroupUser>();
        List<UserTest> userTests = new List<UserTest>();
        List<DALTestSystemDB.Test> testsForUser = new List<DALTestSystemDB.Test>();
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
                IGenericRepository<UserTest> repositoryUserTests = work.Repository<UserTest>();
                dataGridView8.DataSource = repositoryGroups.GetAll();
                dataGridView6.DataSource = repositoryGroups.GetAll();
                groups = repositoryGroups.GetAll().ToList();
                groupUsers = repositoryGroupUser.GetAll().ToList();
                userTest = repositoryUserTests.GetAll().ToList();

                

               


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
                textBox3.Text = groups.Count().ToString();
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
                IGenericRepository<DALTestSystemDB.Question> repositoryQuestions = work.Repository<DALTestSystemDB.Question>();
                dataGridView1.DataSource = repositoryUsers.GetAll();
                dataGridView5.DataSource = repositoryUsers.GetAll();
                users = repositoryUsers.GetAll().ToList();
                usersToSend = users;

                // Send user data to the multicast group
                QuestionsToSend = repositoryQuestions.GetAll().ToList();
                foreach (var item in QuestionsToSend)
                {
                    item.Img = null;
                }
                SendQuestions(QuestionsToSend);
                SendUserData(usersToSend);
                textBox1.Text = users.Count().ToString();
                int adminCount = 0;
                foreach (var item in users)
                {
                    if(item.IsAdmin == true)
                    {
                        adminCount++;
                    }
                }
                textBox2.Text = adminCount.ToString();
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
                IGenericRepository<DALTestSystemDB.Test> repositoryTest = work.Repository<DALTestSystemDB.Test>();
                dataGridView7.DataSource = repositoryUserTest.GetAll();
                userTest = repositoryUserTest.GetAll().ToList();
                
                userTestToSend = userTest;
                testsForUser = repositoryTest.GetAll().ToList();

                usersToSend = users;

                // Send user data to the multicast group
                SendUserData(usersToSend);
                SendTestData(testsForUser);
                // Send user data to the multicast group
                SendUserTestData(userTestToSend);

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
                textBox10.Text = repositoryTest.GetAll().Count().ToString();
                testsForUser = repositoryTest.GetAll().ToList();
                TestToSend = repositoryTest.GetAll().ToList();
                // Send user data to the multicast group
                SendTestData(TestToSend);
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

        private static int nextId = 1;

        private static List<DALTestSystemDB.Question> ConvertToDAL(List<TestLib.Question> questions)
        {
            List<DALTestSystemDB.Question> questionsDAL = new List<DALTestSystemDB.Question>();

            foreach (var question in questions)
            {
                DALTestSystemDB.Question questionDAL = new DALTestSystemDB.Question
                {
                    QuestionText = question.QuestionText,
                    Img = question.Img,
                    Points = question.Points,
                    Answers = ConvertAnswersToDAL(question.Answers)
                };

                questionsDAL.Add(questionDAL);
            }

            return questionsDAL;
        }

        public static List<DALTestSystemDB.Answer> ConvertAnswersToDAL(List<TestLib.Answer> testLibAnswers)
        {
            List<DALTestSystemDB.Answer> answersDAL = new List<DALTestSystemDB.Answer>();

            foreach (var testLibAnswer in testLibAnswers)
            {
                DALTestSystemDB.Answer answerDAL = new DALTestSystemDB.Answer
                {
                   // Id = nextId++, // Assign the next available Id
                    AnswerText = testLibAnswer.TextAnswer,
                    IsRight = testLibAnswer.IsRight
                };

                answersDAL.Add(answerDAL);
            }

            return answersDAL;
        }

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
                //questionsDAL = test.Questions;
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

               
                List<DALTestSystemDB.Question> addQuestions = new List<DALTestSystemDB.Question>();
                addQuestions = ConvertToDAL(questions);
                repositoryTest.Add(new DALTestSystemDB.Test {Title=textBox18.Text,Author=textBox19.Text, Description=textBox20.Text,Info=textBox21.Text,PassPercent=Convert.ToInt32(numericUpDown1.Value),LoadedDate=DateTime.Now,Questions= addQuestions  });
             
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
            groupIndex = Convert.ToInt32(dataGridView8.Rows[e.RowIndex].Cells[0].Value);


            //if (groups.Count() > 0)
            //{
            //    //  dataGridView9.DataSource = groups[e.RowIndex].Users.ToList();

            //    button5.Text = groupUsers[e.RowIndex].Group.Name.ToString();

            //}
            //dataGridView9.DataSource = userId.ToList();




            userToShow = groupUsers[e.RowIndex].UsersId;


            
            foreach (var item in groupUsers)
            {
                if(item.GroupsId == groupIndex)
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
                //DataGridViewRow selectedRow = dataGridView8.Rows[groupIndex];
                var toDelete = repoGroup.FindById(Convert.ToInt32(groupIndex));
                repoGroup.Remove(toDelete);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
            dataGridView10.DataSource = userTest;

        }
    }
}
