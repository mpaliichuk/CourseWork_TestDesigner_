using System;
using System.Collections.Generic;
using System.Text;

namespace DALTestSystemDB
{
    [Serializable]
    public class Test
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Info { get; set; }
        public int PassPercent { get; set; }
        [field: NonSerialized] public bool IsArchived { get; set; }
        [field: NonSerialized] public DateTime LoadedDate { get; set; }
        public virtual ICollection<UserTest> UserTests { get; set; }
        public virtual ICollection<Question> Questions { get; set; }

        public Test()
        {
            Questions = new List<Question>();
            UserTests = new List<UserTest>();
        }

    }
}
