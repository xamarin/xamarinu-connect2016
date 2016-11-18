using System;
using System.Collections.Generic;
using NUnit.Framework;
using eXam;

namespace eXam.UnitTests
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void GameTests_TestForCorrectInitialization_ShouldBeOk()
        {
            // Arrange (setup test)
            var question = new QuizQuestion()
            {
                Question = "Xamarin.Forms is awesome",
                Answer = true,
                Explanation = "Try it for yourself :)"
            };

            // Act (perform test)
            var game = new Game(new List<QuizQuestion>(new [] { question }));

            // Assert (verify test)
            Assert.AreEqual(1, game.Questions.Count);
        }
    }
}
