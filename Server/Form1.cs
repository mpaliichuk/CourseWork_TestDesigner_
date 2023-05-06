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

namespace Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeDataGridViewUsers();
            InitializeDataGridViewGroups();
        }

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
                dataGridView8.DataSource = repositoryGroups.GetAll();
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
               

                numericUpDown1.Value = test.PassPercent;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

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
    }
}
