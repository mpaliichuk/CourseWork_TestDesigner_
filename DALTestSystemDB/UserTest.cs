using System;
using System.Collections.Generic;
using System.Text;

namespace DALTestSystemDB
{
    [Serializable]
    public class UserTest
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public virtual Test Test { get; set; }
        public int PointsGrade { get; set; }
        public bool IsPassed { get; set; }
        public DateTime? TakedDate { get; set; }
        public bool IsTaked { get; set; }
        public virtual ICollection<UserAnswer> UserAnswers { get; set; }

        public UserTest()
        {
            UserAnswers = new List<UserAnswer>();
        }
    }
}
