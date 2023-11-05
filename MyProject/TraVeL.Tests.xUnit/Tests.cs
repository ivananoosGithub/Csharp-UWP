using System;

using TraVeL.ViewModels;

using Xunit;

namespace TraVeL.Tests.XUnit
{
    // TODO: Add appropriate tests
    public class Tests
    {
        [Fact]
        public void TestMethod1()
        {
        }

        // TODO: Add tests for functionality you add to ContentGridViewModel.
        [Fact]
        public void TestContentGridViewModelCreation()
        {
            // This test is trivial. Add your own tests for the logic you add to the ViewModel.
            var vm = new ContentGridViewModel();
            Assert.NotNull(vm);
        }

        // TODO: Add tests for functionality you add to MainViewModel.
        [Fact]
        public void TestMainViewModelCreation()
        {
            // This test is trivial. Add your own tests for the logic you add to the ViewModel.
            var vm = new MainViewModel();
            Assert.NotNull(vm);
        }
    }
}
