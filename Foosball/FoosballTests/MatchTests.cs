using Foosball;
using Foosball.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FoosballTests
{
    /// <summary>
    /// Summary description for ManagingTests
    /// </summary>
    [TestClass]
    public class MatchTests
    {
        private MatchController _matchControllerA;
        private MatchController _matchControllerB;
        private MatchController _matchControllerNone;

        public MatchTests()
        {
            var matchA = new Match("a", "b");
            matchA.AScore = 11;

            var matchB = new Match("a", "b");
            matchB.BScore = 11;

            var matchNone = new Match("a", "b");
            matchNone.AScore = 5;
            matchNone.BScore = 6;

            _matchControllerA = new MatchController(matchA);
            _matchControllerB = new MatchController(matchB);
            _matchControllerNone = new MatchController(matchNone);
        }

        [TestMethod]
        public void CheckForWinner_TestWinner()
        {
            Assert.IsTrue(_matchControllerA.CheckForWinner());
            Assert.IsTrue(_matchControllerB.CheckForWinner());
            Assert.IsFalse(_matchControllerNone.CheckForWinner());
        }

        [TestMethod]
        public void CheckIfPlayerAWon_TestWinner()
        {
            Assert.IsTrue(_matchControllerA.CheckIfPlayerAWon());
            Assert.IsFalse(_matchControllerB.CheckIfPlayerAWon());
            Assert.IsFalse(_matchControllerNone.CheckIfPlayerAWon());
        }
    }
}
