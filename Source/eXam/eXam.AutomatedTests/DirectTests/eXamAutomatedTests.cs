using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

namespace eXam.AutomatedTests
{
	//[TestFixture]
	public class eXamAutomatedTests
	{
		IApp app;

		//[SetUp]
		public void StartApp()
		{
			app = ConfigureApp.Android
		                  	  .PreferIdeSettings()
			                  .StartApp();
		}

		bool IsOnQuestionPage()
		{
			return app.Query(c => c.Marked("questionPage")).Any();
		}

		//[Test]
		public void eXamTestDirect_StartTheTestAndThenCancel_ShouldWork()
		{
			// Start the Test
			app.Tap(c => c.Marked("startExamButton"));

			// Wait for the first question
			app.WaitForElement(c => c.Marked("questionPage"));

			// Go back
			app.Back();

			// We should see the home page again
			Assert.IsTrue(app.Query(c => c.Marked("startExamButton")).Any());
		}

		//[Test]
		public void PerformTestDirect_AnswerAllQuestions_ShouldBeOK()
		{
			var r = new Random();

			var allAnswers = new List<AnsweredQuestion>();

			// Start the Test
			app.Tap(c => c.Marked("startExamButton"));

			// Answer the Questions
			while (IsOnQuestionPage())
			{
				var currentQuestion = new AnsweredQuestion();

				// We have a question page
				currentQuestion.Text = app.Query(c => c.Marked("questionText"))[0].Text;

				// Let's answer the question
				currentQuestion.Answer = r.Next(2) == 0;

				app.Tap(c => c.Marked(currentQuestion.Answer ? "trueButton" : "falseButton"));
				app.WaitForElement(c => c.Marked("resultText"));

                // Get the status to see if it is correct or incorrect
                var response = app.Query(c => c.Marked("resultText")).FirstOrDefault().Text;

                currentQuestion.WasCorrect = response == "Correct";

				allAnswers.Add(currentQuestion);

				// Move on to the next question, unless we are on the last one
				app.Tap(c => c.Marked("nextButton"));

				try
				{
					app.WaitForElement(c => c.Marked("questionPage"));
				}
				catch
				{
					break;
				}
			}

			// See that we have questions
			Assert.Greater(allAnswers.Count, 0);

			// Let's see that we have answers
			Assert.IsTrue(app.Query(c => c.Marked(allAnswers[0].ReviewText)).Any());
		}
	}
}
