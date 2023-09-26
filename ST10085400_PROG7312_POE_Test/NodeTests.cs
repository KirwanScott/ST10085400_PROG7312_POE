using Microsoft.VisualStudio.TestTools.UnitTesting;
using ST10085400_PROG7312_POE.MVVM.Model;

namespace ST10085400_PROG7312_POE.Tests
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void Node_Constructor_SetsValueAndNextToNull()
        {
            // Arrange

            // Act
            var node = new Node(42);

            // Assert
            Assert.AreEqual(42, node.Value, "Value should be set to 42.");
            Assert.IsNull(node.Next, "Next should be null.");
        }
    }
}
