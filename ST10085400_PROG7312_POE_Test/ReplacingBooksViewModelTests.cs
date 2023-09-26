using Microsoft.VisualStudio.TestTools.UnitTesting;
using ST10085400_PROG7312_POE.MVVM.View_Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ST10085400_PROG7312_POE_Test
{
    [TestClass]
    public class ReplacingBooksViewModelTests
    {
        [TestMethod]
        public void TestGenerateCallNumbersCommand()
        {
            // Arrange
            var viewModel = new ReplacingBooksViewModel();

            // Act
            viewModel.GenerateCallNumbers(null);

            // Assert
            Assert.AreEqual(10, viewModel.UserOrderedCallNumbers.Count);
        }

        //[TestMethod]
        //public void TestSortOrderCommand()
        //{
        //    // Arrange
        //    var viewModel = new ReplacingBooksViewModel();

        //    // Act
        //    viewModel.GenerateCallNumbers(null);
        //    viewModel.SortOrder(null);

        //    // Assert
        //    Assert.IsTrue(viewModel.IsAscendingOrder(viewModel.generatedCallNumbers.ToArray()));
        //}


        [TestMethod]
        public void TestAddToBottomRowCommand()
        {
            // Arrange
            var viewModel = new ReplacingBooksViewModel();
            double numberToAdd = 42.0;

            // Act
            viewModel.AddToBottomRow(numberToAdd);

            // Assert
            Assert.AreEqual(1, viewModel.BottomRowNumbers.Count);
            Assert.IsTrue(viewModel.BottomRowNumbers.Contains(numberToAdd));
        }

        [TestMethod]
        public void TestUndoCommand()
        {
            // Arrange
            var viewModel = new ReplacingBooksViewModel();
            double numberToAdd = 42.0;
            viewModel.AddToBottomRow(numberToAdd);

            // Act
            viewModel.Undo(null);

            // Assert
            Assert.AreEqual(0, viewModel.BottomRowNumbers.Count);
            Assert.IsFalse(viewModel.BottomRowNumbers.Contains(numberToAdd));
        }
    }
}
