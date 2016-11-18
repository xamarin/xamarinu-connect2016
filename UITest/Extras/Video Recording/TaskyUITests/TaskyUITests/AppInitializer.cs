using Xamarin.UITest;
using System;

namespace TaskyUITests
{
    public static class AppInitializer
    {
        public static ITaskSystem StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return new AndroidTaskSystem(ConfigureApp
                    .Android
                    // Comment this out to use the project-resources
                    .ApkFile(@"../../../../../Binaries/TaskyPro/Android/com.xamarin.samples.taskyandroid.apk")
                    .StartApp());
            }

            else if (platform == Platform.iOS)
            {
                return new IOSTaskSystem(ConfigureApp
                    .iOS
                    // Comment this out to use the project-resources
                    .AppBundle(@"../../../../../Binaries/TaskyPro/iOS/TaskyiOS.app")
                    .StartApp());
            }

            throw new Exception("AppInitializer: Unsupported platform " + platform);
        }
    }
}

