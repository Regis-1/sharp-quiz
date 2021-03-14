using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Question
    {
        public int questionNo { get; }
        public string description { get; }
        public Answer[] answers { get; set; }

        public Question(int qNo, string desc, Answer[] ans)
        {
            questionNo = qNo;
            description = desc;
            answers = ans;
        }

        public Answer[] ShuffleAnswers()
        {
            answers = answers.OrderBy(i => Guid.NewGuid()).ToArray();
            return answers;
        }
    }
}
