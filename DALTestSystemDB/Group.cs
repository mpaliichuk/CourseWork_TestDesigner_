using System;
using System.Collections.Generic;
using System.Text;

namespace DALTestSystemDB
{
    [Serializable]
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsAdminGroup { get; set; }

        public virtual List<GroupUser> GroupUsers { get; set; }
        public virtual ICollection<User> Users { get; set; }

        public Group()
        {
            Users = new List<User>();
            GroupUsers = new List<GroupUser>();
        }
    }
}
