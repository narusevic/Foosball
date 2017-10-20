using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Foosball;
using Foosball.Models;

namespace FoosballTests
{
    [TestClass]
    public class InputPLayerNamesTest
    {
        [TestMethod]
        public void InputPlayerNamesNameValidationTest()
        {
            string name1 = "Good name";
            string name2 = "VERRR";

            var match = new Match();
            var view = new InputPlayerNames(match);

            Assert.AreEqual(true, view.NameValidation(name1, name2));
        }
    }
}
