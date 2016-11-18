using System;
using System.Linq;
using Xamarin.UITest;

namespace eXam.AutomatedTests
{
    /// <summary>
    /// A Simple base Page object that is used. Often you will have pages in your application
    /// that have shared functionality; For example you could have a hamburger navigation in your app 
    /// and you want some shared code to open the flyout and navigate to a particular page
    /// </summary>
	public class BasePageObject
	{
		protected readonly IApp app;

		public BasePageObject(IApp app)
		{
			this.app = app;
		}
	}

    /// <summary>
    /// A Generic version which is useful if you are making fluent-page objects
    /// </summary>
    /// <typeparam name="T"></typeparam>
	public class BasePageObject<T> : BasePageObject
	{
		public BasePageObject(IApp app) : base(app)
		{
		}
	}
}
