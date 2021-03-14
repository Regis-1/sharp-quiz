using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class QuestionReader
    {
        private List<Question> q;
        private readonly string path = "questions.txt";
        private int qCounter;

        public QuestionReader()
        {
            q = new List<Question>();
            qCounter = 0;
        }

        public List<Question> QuestionProcess() 
        {
            //Reading from file and separating each Question
            string[] fileLines = System.IO.File.ReadAllLines(this.path);

            bool readQ = false;
            bool readA = false;
            bool readC = false;
            bool endOfQuestion = false;

            string[] description = new string[5];
            int aCounter = 0;
            int correctIndex = 0;

            foreach (string line in fileLines)
            {
                if (line == "[Q]")
                {
                    qCounter++;
                    readQ = true;
                }
                else if (line == "[A]")
                {
                    readQ = false;
                    readA = true;
                }
                else if (line == "[C]")
                {
                    aCounter = 0;
                    readA = false;
                    readC = true;
                }
                else
                {
                    if (readQ)
                    {
                        description[0] += line;
                    }
                    else if (readA)
                    {
                        description[aCounter + 1] += line;
                        aCounter++;
                    }
                    else if (readC)
                    {
                        if (!Int32.TryParse(line, out correctIndex))
                            Console.WriteLine("Parsing ERROR!");
                        readC = false;
                        endOfQuestion = true;    
                    }
                }

                if (endOfQuestion)
                {
                    Answer[] ans = new Answer[4];
                    for (int i = 0; i < 4; i++)
                    {
                        ans[i] = new Answer(description[i + 1], i == correctIndex);
                    }
                    q.Add(new Question(qCounter, description[0], ans));
                    for (int i = 0; i < 5; i++)
                        description[i] = "";
                    endOfQuestion = false;
                }
            }

            return q;
        }
    }
}
