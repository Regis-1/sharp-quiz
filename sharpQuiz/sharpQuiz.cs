using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Engine;

namespace sharpQuiz
{
    public partial class sharpQuiz : Form
    {
        private QuestionReader qr = new QuestionReader();
        private QuestionGiver qg;
        private Question currentQuestion;

        private float correct = 0;
        private float all = 0;
        private float ratio;

        private bool btnClicked = false;

        public sharpQuiz()
        {
            qg = new QuestionGiver(qr.QuestionProcess());

            InitializeComponent();
            lblCorrect.Text = "0%";
            lblAll.Text = "0";

            currentQuestion = qg.NextQuestion();
            AskQuestion(currentQuestion); //initial ask
        }

        public void AskQuestion(Question currentQuestion)
        {
            string[] choices = { "A. ", "B. ", "C. ", "D. " };
            currentQuestion.ShuffleAnswers();

            lblQuestionNo.Text = currentQuestion.questionNo.ToString();
            tbQuestion.Text = currentQuestion.description + "\n\n";
            for (int i = 0; i < 4; i++)
                tbQuestion.Text += choices[i] + currentQuestion.answers[i].description + "\n";
        }
        
        private void Validate(int id)
        {
            if( currentQuestion.answers[id].IsCorrect())
            {
                correct++;   
            }
            all++;
            ratio = (float)(correct / all * 100);
            
            lblAll.Text = all.ToString();
            lblCorrect.Text = ratio.ToString("n2") + "%";

            currentQuestion = qg.NextQuestion();
            AskQuestion(currentQuestion);
        }

        //BUTTONS FUNCTIONS
        private void btnA_Click(object sender, EventArgs e)
        {
            Validate(0);
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            Validate(1);
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            Validate(2);
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            Validate(3);
        }
    }
}
