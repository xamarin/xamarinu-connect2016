using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

namespace eXam.AutomatedTests
{
	[TestFixture(Platform.Android)]
    // [TestFixture(Platform.iOS)]
    public class FluenteXamAutomatedTests
	{
		Platform platform;

		public FluenteXamAutomatedTests(Platform platform)
		{
			this.platform = platform;
		}

		IApp app;
		AppNav navigation;
		SimpleContainer container;

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);

			container = new SimpleContainer();
			container.Register<IApp>(() => app);

			navigation = container.Create<AppNav>();
		}

		[Test]
		public void eXamTest_StartTheTestAndThenCancel_ShouldWork()
		{
			var startPage = container.Create<StartTestPage>();
			var questionPage = container.Create<QuestionPage>();

			// Start the Test
			startPage.StartTest();
			navigation.AssertPage(AppNavPage.Question);

			// Go Back
			app.Screenshot("Viewing Question");
			questionPage.GoBack();

			// We should see the home page again
			navigation.AssertPage(AppNavPage.Home);
		}

		[Test]
		public void PerformTest_AnswerAllQuestions_ShouldBeOK()
		{
			// Arrange
			var startPage = container.Create<StartTestPage>();
			var reviewPage = container.Create<ReviewPage>();

			// Act
			startPage.StartTest();
			navigation.AssertPage(AppNavPage.Question);

			var allQuestions = new List<QuestionPage>();

			while (navigation.CurrentPage == AppNavPage.Question)
			{
				var questionPage = container.Create<QuestionPage>();

				allQuestions.Add(questionPage);

				questionPage
					.AnswerWithRandomAnswer()
					.NextQuestion();
			}

            // Assert
            var questionCount = allQuestions.Count;
            var correctCount = allQuestions.Count(q => q.currentQuestion.WasCorrect);

			app.Screenshot("Reviewing Answers");

            Assert.IsTrue(reviewPage.HasCorrectCount(correctCount, questionCount));
		}
	}
}
