using Microsoft.VisualStudio.TestTools.UnitTesting;
using ST10085400_PROG7312_POE.Core;
using System.ComponentModel;

namespace ST10085400_PROG7312_POE.Tests
{
    [TestClass]
    public class ObservableObjectTests
    {
        [TestMethod]
        public void ObservableObject_OnPropertyChanged_RaisesPropertyChangedEvent()
        {
            // Arrange
            var observableObject = new TestObservableObject();
            bool eventRaised = false;

            observableObject.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == "TestProperty")
                {
                    eventRaised = true;
                }
            };

            // Act
            observableObject.TestProperty = "NewValue";

            // Assert
            Assert.IsTrue(eventRaised, "PropertyChanged event should be raised.");
        }
    }

    // A test class derived from ObservableObject for testing purposes
    public class TestObservableObject : ObservableObject
    {
        private string testProperty;

        public string TestProperty
        {
            get { return testProperty; }
            set
            {
                testProperty = value;
                OnPropertyChanged();
            }
        }
    }
}
