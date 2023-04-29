using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TestLib
{
    [Serializable]
    public class Question : ICloneable, IEquatable<Question>
    {
        [XmlIgnore]
        public Guid guid;
        public string QuestionText { get; set; }
        public int Points { get; set; }
        public string Img { get; set; }
        public List<Answer> Answers { get; set; }
        public Question()
        {
            guid = Guid.NewGuid();
            QuestionText = String.Empty;
            Points = 0;
            Img = String.Empty;
            Answers = new List<Answer>();

        }

        public Question(string questionText, int points, string img)
        {
            QuestionText = questionText;
            Points = points;
            Img = img;
        }

        public Question(string questionText, int points, string img, List<Answer> answers) : this(questionText, points, img)
        {
            Answers = answers;
        }
        public Question(Question question)
        {
            guid = Guid.NewGuid();
            QuestionText = question.QuestionText;
            Points = question.Points;
            Img = question.Img;
            Answers = question.Answers.Clone<Answer>();
        }

        public bool Equals(Question other)
        {
            return other is Question &&
                this.guid == other.guid &&
                this.QuestionText.Equals(other.QuestionText) &&
                this.Points == other.Points &&
                this.Img.Equals(other.Img) &&
                this.Answers.ScrambledEquals<Answer>(other.Answers);
        }

        public object Clone()
        {
            return new Question(this.QuestionText, this.Points, this.Img, this.Answers.Clone<Answer>());
        }
    }
}
