using System;
using System.Linq;
using Xamarin.UITest;

namespace eXam.AutomatedTests
{
	public class QuestionPage : BasePageObject
	{
		public QuestionPage(IApp app) : base(app)
		{
		}

		public AnsweredQuestion currentQuestion { get; set; } = new AnsweredQuestion();

		public QuestionPage AnswerQuestion(bool answer)
		{
			currentQuestion.Text = app.Query(c => c.Marked("questionText"))[0].Text;
			currentQuestion.Answer = answer;

			app.Tap(c => c.Marked(currentQuestion.Answer ? "trueButton" : "falseButton"));
			app.WaitForElement(c => c.Marked("resultText"));

			app.Screenshot("Answer: " + currentQuestion.Text);

            // Get the status to see if it is correct or incorrect
            var response = app.Query(c => c.Marked("resultText"))[0].Text;
            currentQuestion.WasCorrect = response == "Correct";

			return this;
		}

		Random r = new Random();

		public QuestionPage AnswerWithRandomAnswer()
		{
			return AnswerQuestion(r.Next(2) == 1);
		}

		public QuestionPage NextQuestion()
		{
			app.Tap(c => c.Marked("nextButton"));

            // We want to get either another Question Page or the Results Page
            app.WaitFor(() => app.Query(c => c.Marked("questionPage")).Any() ||
                app.Query(c => c.Marked("resultText")).Any());

			return this;
		}

		public QuestionPage GoBack()
		{
			app.Back();

			return this;
		}

		public QuestionPage WaitToAppear()
		{
			app.WaitForElement(c => c.Marked("questionPage"));

			return this;
		}
	}
}
