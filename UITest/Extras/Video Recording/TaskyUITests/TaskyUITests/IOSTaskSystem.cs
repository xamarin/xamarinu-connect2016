using System;
using System.Linq;
using Xamarin.UITest;

namespace TaskyUITests
{
	public class IOSTaskSystem : ITaskSystem
	{
		readonly IApp app;

		public IOSTaskSystem(IApp app)
		{
			this.app = app;
		}

		public ITaskSystem Add()
		{
			app.Tap ("Add");
			return this;
		}

        public ITaskSystem Delete(string name)
        {
            app.Tap(name);
            app.Tap("Delete");
            app.WaitForNoElement(name);

            return this;
        }

		public ITaskSystem SetName (string name)
		{
			app.EnterText (c => c.Class ("UITextField").Index (0), name);
			return this;
		}

		public ITaskSystem SetNotes (string notes)
		{
			app.EnterText (c => c.Class ("UITextField").Index (1), notes);
			return this;
		}

		public ITaskSystem Save ()
		{
			app.Tap ("Save");
			return this;
		}

		public ITaskSystem Cancel ()
		{
			app.Tap ("Cancel");
			return this;
		}

		public bool HasItem(string itemName)
		{
			try
			{
				app.WaitForElement(c => c.Marked(itemName));
				return true;
			}
			catch (TimeoutException)
			{
			}
			return false;
		}
	}
}
