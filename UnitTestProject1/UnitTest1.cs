using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp1;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
           WpfApp1.MainWindow.calcObject a = new WpfApp1.MainWindow.calcObject();
            a.bandAColor = "Yellow";
            a.bandBColor = "Violet";
            a.bandCColor = "Red";
            a.bandDColor = "Gold";
            Assert.IsTrue(a.CalculateOhmValue == 4700);
        }
    }
}
