using System;
using System.Xml.Serialization;

namespace TestLib
{
    [Serializable]
    public class Answer : ICloneable, IEquatable<Answer>
    {
        [XmlIgnore]
        public Guid guid;
        public string TextAnswer { get; set; }
        public bool IsRight { get; set; }
        public Answer()
        {
            guid = Guid.NewGuid();
        }

        public Answer(string textAnswer, bool isRight)
        {
            guid = Guid.NewGuid();
            TextAnswer = textAnswer;
            IsRight = isRight;
        }
        public bool Equals(Answer other)
        {
            return other is Answer && guid == other.guid &&
                this.TextAnswer.Equals(other.TextAnswer) &&
                this.IsRight.Equals(other.IsRight);

        }
        public object Clone()
        {
            return new Answer(TextAnswer, IsRight);
        }
    }
}
