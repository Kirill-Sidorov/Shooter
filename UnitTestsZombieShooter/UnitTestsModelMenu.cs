using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestsZombieShooter
{
    [TestClass]
    public class UnitTestsModelMenu
    {
        [TestMethod]
        public void TestFocusNext()
        {
            ModelMenu modelMenu = new ModelMenu();
            
            modelMenu.FocusNext();
            Status actualStatus = modelMenu.Items[1].CurrentStatus;
            Status expectedStatus = Status.FOCUSED;

            Assert.AreEqual(expectedStatus, actualStatus);
        }

        [TestMethod]
        public void TestFocusPrevious()
        {
            ModelMenu modelMenu = new ModelMenu();

            modelMenu.FocusPrevious();
            Status actualStatus = modelMenu.Items[3].CurrentStatus;
            Status expectedStatus = Status.FOCUSED;

            Assert.AreEqual(expectedStatus, actualStatus);
        }

        [TestMethod]
        public void TestSelectFocusedItem()
        {
            bool isSelected = false;

            ModelMenu modelMenu = new ModelMenu();

            modelMenu.Items[0].Selected += () => isSelected = true;
            modelMenu.SelectFocusedItem();

            Assert.IsTrue(isSelected);
        }
    }
}
