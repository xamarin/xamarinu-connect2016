using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

namespace eXam.AutomatedTests
{
	public static class AppInitializer
	{
		public static IApp StartApp(Platform platform)
		{
			if (platform == Platform.Android)
				return ConfigureApp
					.Android
                    .ApkFile(@"..\..\..\eXam.Droid\bin\Release\eXam.Droid.apk")
					.PreferIdeSettings()
					.StartApp();

			if (platform == Platform.iOS)
				return ConfigureApp
					.iOS
					.PreferIdeSettings()
					.StartApp();

			throw new Exception($"AppInitializer: Unsupported platform {platform}");
		}
	}
}
