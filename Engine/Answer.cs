using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Answer
    {
        public string description { get; set; }
        private bool correct;

        public Answer(string desc, bool corr)
        {
            description = desc;
            correct = corr;
        }

        public bool IsCorrect()
        {
            return correct;
        }
    }
}
