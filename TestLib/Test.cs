using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestLib
{
    [Serializable]
    public class Test : IComparable<Test>, IEquatable<Test>
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Info { get; set; }
        public int PassPercent { get; set; }
        public List<Question> Questions { get; set; }

        public Test()
        {
            Author = string.Empty;
            Title = string.Empty;
            Info = string.Empty;
            PassPercent = 0;
            Questions = new List<Question>();
        }

        public Test(string author, string title, string description, string info, int passPercent, string img, List<Question> questions)
        {
            Author = author;
            Title = title;
            Description = description;
            Info = info;
            PassPercent = passPercent;
            Questions = questions;
        }

        public int CompareTo(Test other)
        {
            if (other == null) return 1;
            if (other.Title != null)
                return this.Title.CompareTo(other.Title);
            else
                throw new ArgumentException("Object is not a Test");
        }

        public bool Equals(Test other)
        {
            return other is Test &&
                this.Author == other.Author &&
                this.Title == other.Title &&
                this.Description == other.Description &&
                this.Info == other.Info &&
                this.PassPercent == other.PassPercent &&
                this.Questions.SequenceEqual(other.Questions);
        }
    }
}
