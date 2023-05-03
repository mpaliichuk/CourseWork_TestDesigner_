using System;
using System.Collections.Generic;
using System.Text;

namespace DALTestSystemDB
{
    [Serializable]
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string Img { get; set; }
        public int Points { get; set; }
        public virtual Test Test { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }

        public Question()
        {
            Answers = new List<Answer>();
        }
    }
}
