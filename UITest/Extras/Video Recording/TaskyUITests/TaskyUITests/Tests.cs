using NUnit.Framework;
using Xamarin.UITest;

namespace TaskyUITests
{
    [TestFixture (Platform.Android)]
    // [TestFixture (Platform.iOS)]
    public class Tests
    {
        ITaskSystem tasks;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest ()
        {
            tasks = AppInitializer.StartApp (platform);
        }

        [Test]
        public void TaskyPro_CreatingATask_ShouldBeSuccessful ()
        {
            tasks.Add ()
                .SetName ("Get Milk")
                .SetNotes ("Pickup Milk")
                .Save ();

            Assert.IsTrue (tasks.HasItem ("Get Milk"));
        }

        [Test]
        public void TaskyPro_DeletingATask_ShouldBeSuccessful ()
        {
            tasks.Add()
                .SetName("Test Delete")
                .SetNotes("This item should be deleted")
                .Save();

            tasks.Delete("Test Delete");

            Assert.IsFalse(tasks.HasItem("Test Delete"));
        }
    }
}

