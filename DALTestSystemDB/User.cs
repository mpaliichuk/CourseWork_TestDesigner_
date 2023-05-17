using System;
using System.Collections.Generic;
using System.Text;

namespace DALTestSystemDB
{
    [Serializable]
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsArchived { get; set; }
        public DateTime RegisterDate { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<UserTest> UserTests { get; set; }
        public virtual List<GroupUser> GroupUsers { get; set; }

        public User()
        {
            Groups = new List<Group>();
            UserTests = new List<UserTest>();
            GroupUsers = new List<GroupUser>();
        }
    }
}
