using System;
using System.Collections.Generic;
using System.Text;

namespace DALTestSystemDB
{
    [Serializable]
    public class GroupUser
    {
        public int GroupsId { get; set; }
        public int UsersId { get; set; }

        public virtual Group Group { get; set; }
        public virtual User User { get; set; }
        public GroupUser()
        {
            Group = new Group();
            User = new User();
        }
    }
}
