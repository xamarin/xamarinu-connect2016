using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;

namespace TestWeatherAppUI
{
    /// <summary>
    /// This demonstrates connecting to an Android App that was built using Cordova. 
    /// The app is from the Microsoft Cordova Samples repository and this app is available at
    /// https://github.com/Microsoft/cordova-samples/tree/master/weather-app
    /// You would need to build a version of the application using the Cordova tools and and make sure that you 
    /// sign-up for an appopriate Weather API key from http://openweathermap.org/ and paste the API key into the
    /// weather.js file
    /// </summary>
	[TestFixture]
	public class Tests
	{
		AndroidApp app;

		[SetUp]
		public void BeforeEachTest()
		{
			app = ConfigureApp
				.Android
				.EnableLocalScreenshots()
				.ApkFile ("../../Cordova-WeatherApp.apk")
				.StartApp();
		}

		[Test]
		public void WeatherApp_TestSearchCapability_ShouldDisplayCorrectLocation()
		{
			// Tap on the Zip Code input
			app.WaitForElement(c => c.Css("#zip-code-input"));

			app.Screenshot("Entering the Zip Code");
			app.Tap(c => c.Css("#zip-code-input"));

			// Enter the Zip Code
			app.EnterText("90210");

			// Perform the Search
			app.Screenshot("Performing the Search");
			app.Tap(c => c.Css("#get-weather-btn"));

			// Wait for the title to appear
			app.WaitFor(() => app.Query(c => c.Css("#title")).First().TextContent == "Beverly Hills");

			// Check the correct postcode appears
			app.Screenshot("Viewing the Search Results");
		}
	}
}
