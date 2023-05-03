using System;
using System.Collections.Generic;
using System.Text;

namespace DALTestSystemDB
{
    [Serializable]
    public class UserAnswer
    {
        public int Id { get; set; }
        public bool IsChecked { get; set; }
        public virtual Answer Answer { get; set; }
        public virtual UserTest UserTest { get; set; }
    }
}
