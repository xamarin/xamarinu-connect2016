using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.UITest;

namespace eXam.AutomatedTests
{
	public class ReviewPage : BasePageObject
	{
		public ReviewPage(IApp app) : base(app)
		{
		}

        public bool HasCorrectCount(int correctCount, int answerCount)
        {
            var text = $"Great! You got {correctCount} out of {answerCount} questions correct";
            var control = app.Query(c => c.Marked(text)).FirstOrDefault();

            return control != null;
        }

		public bool HasResponse(AnsweredQuestion question)
		{
			app.ScrollDownTo(c => c.Marked(question.ReviewText));

			return app.Query(c => c.Marked(question.ReviewText)).Any();
		}

		public bool HasResponses(IEnumerable<AnsweredQuestion> questions)
		{
			foreach (var question in questions)
				if (!HasResponse(question))
					return false;

			return true;
		}
	}
}
