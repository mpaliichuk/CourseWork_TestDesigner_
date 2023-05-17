using DALTestSystemDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class AddNewGroup : Form
    {
        public List<User> usersToAddToGroup = new List<User>();
        public List<GroupUser> groupUsersToAdd = new List<GroupUser>();
        public AddNewGroup()
        {
            InitializeComponent();
            bindingSource1.DataSource = usersToAddToGroup;
            dataGridView1.DataSource = bindingSource1;
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
                IGenericRepository<GroupUser> repositoryGroupUser = work.Repository<GroupUser>();

                Group groupToAdd = new Group
                {
                    Name = textBox1.Text,
                    Description = textBox2.Text,
                    IsAdminGroup = checkBox1.Checked
                };

                foreach (User user in usersToAddToGroup)
                {
                    // Find the existing user in the database
                    User existingUser = work.Repository<User>().FindById(user.Id);
                    existingUser.Groups.Add(groupToAdd);

                    GroupUser groupUser = new GroupUser()
                    {
                        User = existingUser,
                        Group = groupToAdd,
                        //UsersId = existingUser.Id,
                        //GroupsId = groupToAdd.Id
                             
                    };
                    groupUsersToAdd.Add(groupUser);
                    
                    // Add the existing user to the group
                    groupToAdd.Users.Add(existingUser);
                  //  groupToAdd.Users.Add(user);
                }
                foreach (var item in groupUsersToAdd)
                {
                    repositoryGroupUser.Add(item);
                }


                repositoryGroup.Add(groupToAdd);

              //  work.SaveChanges(); // Save changes to the database

                dataGridView1.DataSource = repositoryGroup.GetAll();
            }

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddUserToGroup addUserToGroup = new AddUserToGroup(this);
            addUserToGroup.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
