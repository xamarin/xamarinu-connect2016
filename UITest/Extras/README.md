# Connect(); 2016 Training Materials

## UITest Extras

During the UITest talk there were two applications that were demonstrated that showed some of the other capabilities of UI Test. These were the ability to test HTML5 based apps such as Cordova as well as the ability to record the videos of the tests while the tests are running on Test Cloud

### Cordova Based Example

This demonstrates connecting to an Android App that was built using Cordova. 

The app is from the Microsoft Cordova Samples repository and this app is available at the [Cordova Github Samples](https://github.com/Microsoft/cordova-samples/tree/master/weather-app). 
You would need to build a version of the application using the Cordova tools and and make sure that you sign-up for an appopriate Weather API key from [openweathermap.org](http://openweathermap.org/ and paste the API key into the
[weather.js](https://github.com/Microsoft/cordova-samples/blob/master/weather-app/WeatherApp/www/scripts/weather.js#L2) file

### Recording Test Cloud Videos on Android

Android 4.3 and above devices have the ability to record the videos of the test while they are executing. This is an additional option and requires an additional parameter to be sent to Test Cloud. You would need to start a Test Run through the [Test Cloud portal](https://testcloud.xamarin.com). You would select a new Test Run and go through the steps selecting your devices and test series. Once it has shown the command prompt statement you would need to use to run the test, add the parameter to it and the videos will be recorded. 

mono packages/Xamarin.UITest.[version]/tools/test-cloud.exe submit yourAppFile.apk _key_ --devices _devices_ --series "master" --locale "en_US" --app-name "_AppName_" --user u --assembly-dir _pathToTestDllFolder_ **--test-params screencapture:true**
