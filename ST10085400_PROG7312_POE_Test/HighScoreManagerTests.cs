using Microsoft.VisualStudio.TestTools.UnitTesting;
using ST10085400_PROG7312_POE.MVVM.Model;

namespace ST10085400_PROG7312_POE_Test
{
    [TestClass]
    public class HighScoreManagerTests
    {
        [TestMethod]
        public void HighScoreManager_Instance_ReturnsSingletonInstance()
        {
            // Arrange

            // Act
            var instance1 = HighScoreManager.Instance;
            var instance2 = HighScoreManager.Instance;

            // Assert
            Assert.AreSame(instance1, instance2, "Instances should be the same (singleton).");
        }

        [TestMethod]
        public void HighScoreManager_HighScore_DefaultValueIsZero()
        {
            // Arrange

            // Act
            var highScore = HighScoreManager.Instance.HighScore;

            // Assert
            Assert.AreEqual(0, highScore, "Default high score should be zero.");
        }

        [TestMethod]
        public void HighScoreManager_HighScore_SetNewHighScore()
        {
            // Arrange
            var manager = HighScoreManager.Instance;

            // Act
            manager.HighScore = 100;

            // Assert
            Assert.AreEqual(100, manager.HighScore, "High score should be set to 100.");
        }
    }
}
