using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class QuestionGiver
    {
        private Random rand;
        private List<Question> qList;

        public QuestionGiver(List<Question> q)
        {
            rand = new Random();
            qList = q;
        }

        public Question NextQuestion()
        {
            int qCount = qList.Count();

            return qList[rand.Next(1,qCount)];
        }
    }
}
