using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

namespace eXam.AutomatedTests
{
	public class AppNav
	{
		protected readonly IApp app;

		public AppNav(IApp app)
		{
			this.app = app;
		}

        string[] ids = new string[] { "startExamButton", "questionPage", "resultText" };

        public AppNavPage CurrentPage
		{
			get
			{
				for (int i = 0; i < ids.Length; i++)
				{
					if (app.Query(c => c.Marked(ids[i])).Any())
						return (AppNavPage)i;
				}

				throw new ArgumentException("None of the pages could be found");
			}
		}

		public void AssertPage(AppNavPage page)
		{
            app.WaitForElement(ids[(int)page]);

            Assert.AreEqual(page, CurrentPage);
		}
	}
}
