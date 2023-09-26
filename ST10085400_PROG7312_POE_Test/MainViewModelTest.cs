using Microsoft.VisualStudio.TestTools.UnitTesting;
using ST10085400_PROG7312_POE.MVVM.View_Model;
using System;

namespace ST10085400_PROG7312_POE_Test
{
    [TestClass]
    public class MainViewModelTest
    {
        [TestMethod]
        public void TestHomeViewCommand()
        {
            // Arrange
            MainViewModel viewModel = new MainViewModel();

            // Act
            viewModel.HomeViewCommand.Execute(null);

            // Assert
            Assert.AreEqual(viewModel.CurrentView, viewModel.HomeVM);
        }

        [TestMethod]
        public void TestReplaceBooksCommand()
        {
            // Arrange
            MainViewModel viewModel = new MainViewModel();

            // Act
            viewModel.ReplaceBooksCommand.Execute(null);

            // Assert
            Assert.AreEqual(viewModel.CurrentView, viewModel.ReplacingBooksVM);
        }

        [TestMethod]
        public void TestDefaultCurrentView()
        {
            // Arrange
            MainViewModel viewModel = new MainViewModel();

            // Assert
            Assert.AreEqual(viewModel.CurrentView, viewModel.HomeVM);
        }
        [TestMethod]
        public void TestIdentifyingAreasViewCommand()
        {
            MainViewModel ViewModel = new MainViewModel();

            ViewModel.IdentifyAreasCommand.Execute(null);

            Assert.AreEqual(ViewModel.CurrentView, ViewModel.IdentifyingAreasVM);
        }
        [TestMethod]
        public void TestFindCallNumbersViewCommand()
        {
            MainViewModel ViewModel = new MainViewModel();

            ViewModel.FindCallNumberCommand.Execute(null);

            Assert.AreEqual(ViewModel.CurrentView, ViewModel.FindCallNumbersVM);
        }
    }

}
