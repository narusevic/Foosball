using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Foosball;
using Foosball.Models;

namespace FoosballTests
{
    [TestClass]
    public class TournamentBracketContollerTest
    {
        [TestMethod]
        public void TournamentBracketContollerAmountFinderTest1()
        {
            var tournament = new Tournament();
            var view = new TournamentBracket(tournament);
            var controller = new Foosball.Controllers.TournamentBracketController(tournament, view);

            Assert.AreEqual(4, controller.AmountFinder());
        }

        [TestMethod]
        public void TournamentBracketContollerAmountFinderTest2()
        {
            var tournament = new Tournament();
            for (int i = 0; i < 5; i++)
            {
                tournament.Teams.Add(new Team("lol" + i));
            }
            var view = new TournamentBracket(tournament);
            var controller = new Foosball.Controllers.TournamentBracketController(tournament, view);

            Assert.AreEqual(8, controller.AmountFinder());
        }

        [TestMethod]
        public void TournamentBracketContollerAmountFinderTest3()
        {
            var tournament = new Tournament();
            for (int i = 0; i < 15; i++)
            {
                tournament.Teams.Add(new Team("lol" + i));
            }
            var view = new TournamentBracket(tournament);
            var controller = new Foosball.Controllers.TournamentBracketController(tournament, view);

            Assert.AreEqual(16, controller.AmountFinder());
        }
    }
}
