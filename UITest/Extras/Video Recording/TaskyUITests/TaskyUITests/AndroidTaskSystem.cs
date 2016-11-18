using Xamarin.UITest;
using System.Linq;
using System;

namespace TaskyUITests
{
	public class AndroidTaskSystem : ITaskSystem
	{
		readonly IApp app;

		public AndroidTaskSystem(IApp app)
		{
			this.app = app;
		}

		public ITaskSystem Add ()
		{
			app.Tap ("Add Task");
			return this;
		}

        public ITaskSystem Delete(string taskName)
        {
            app.Tap(taskName);
            app.Tap("Delete");
            app.WaitForNoElement(taskName);

            return this;
        }

		public ITaskSystem SetName (string name)
		{
            app.EnterText (c => c.Class("EditText").Index(0), name);
			return this;
		}

		public ITaskSystem SetNotes (string notes)
		{
            app.EnterText (c => c.Class("EditText").Index(1), notes);
			return this;
		}

		public ITaskSystem Save ()
		{
			app.Tap ("Save");
			return this;
		}

		public ITaskSystem Cancel ()
		{
			app.Back ();
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
