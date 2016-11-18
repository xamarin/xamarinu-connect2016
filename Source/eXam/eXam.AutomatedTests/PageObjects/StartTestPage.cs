using System;
using System.Linq;
using Xamarin.UITest;

namespace eXam.AutomatedTests
{
	public class StartTestPage : BasePageObject
	{
		public StartTestPage(IApp app) : base(app)
		{
		}

		public StartTestPage StartTest()
		{
			app.Screenshot("Starting Test");

            app.WaitForElement(c => c.Marked("startExamButton"));
            app.Tap(c => c.Marked("startExamButton"));
			app.WaitForElement(c => c.Marked("questionPage"));

			return this;
		}
	}
}
