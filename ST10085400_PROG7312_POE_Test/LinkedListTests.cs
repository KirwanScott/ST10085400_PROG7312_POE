using Microsoft.VisualStudio.TestTools.UnitTesting;
using ST10085400_PROG7312_POE.MVVM.Model;

namespace ST10085400_PROG7312_POE.Tests
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void LinkedList_AddToEnd_AddsElementToEnd()
        {
            // Arrange
            var linkedList = new LinkedList();

            // Act
            linkedList.AddToEnd(1);
            linkedList.AddToEnd(2);
            linkedList.AddToEnd(3);

            // Assert
            Assert.AreEqual(3, linkedList.Count, "Count should be 3.");
            CollectionAssert.AreEqual(new double[] { 1, 2, 3 }, linkedList.ToArray(), "Elements should be added to the end.");
        }

        [TestMethod]
        public void LinkedList_Remove_RemovesElement()
        {
            // Arrange
            var linkedList = new LinkedList();
            linkedList.AddToEnd(1);
            linkedList.AddToEnd(2);
            linkedList.AddToEnd(3);

            // Act
            var result1 = linkedList.Remove(2);
            var result2 = linkedList.Remove(4);

            // Assert
            Assert.IsTrue(result1, "Remove should return true for existing element.");
            Assert.IsFalse(result2, "Remove should return false for non-existing element.");
            Assert.AreEqual(2, linkedList.Count, "Count should be 2 after removal.");
            CollectionAssert.AreEqual(new double[] { 1, 3 }, linkedList.ToArray(), "Element should be removed.");
        }

        [TestMethod]
        public void LinkedList_Clear_ClearsList()
        {
            // Arrange
            var linkedList = new LinkedList();
            linkedList.AddToEnd(1);
            linkedList.AddToEnd(2);

            // Act
            linkedList.Clear();

            // Assert
            Assert.AreEqual(0, linkedList.Count, "Count should be 0 after clearing.");
            Assert.IsNull(linkedList.Head, "Head should be null after clearing.");
            Assert.IsNull(linkedList.Tail, "Tail should be null after clearing.");
        }

        [TestMethod]
        public void LinkedList_Contains_ChecksForElement()
        {
            // Arrange
            var linkedList = new LinkedList();
            linkedList.AddToEnd(1);
            linkedList.AddToEnd(2);
            linkedList.AddToEnd(3);

            // Act
            var result1 = linkedList.Contains(2);
            var result2 = linkedList.Contains(4);

            // Assert
            Assert.IsTrue(result1, "Contains should return true for existing element.");
            Assert.IsFalse(result2, "Contains should return false for non-existing element.");
        }
    }
}
