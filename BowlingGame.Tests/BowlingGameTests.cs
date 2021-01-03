using BowlingGame.Core.Interfaces;
using BowlingGame.Web.Extensions;
using NUnit.Framework;

namespace BowlingGame.Tests
{
    [TestFixture]
    public class BowlingGameTests
    {
        private IContestant _contestant;
        [SetUp]
        public void Setup()
        {
            _contestant = new BowlingGame.Web.Models.BowlingContestant();
        }

        private void rollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                _contestant.Roll(pins);
            }
        }

        private void rollSequence(int[] rolls)
        {
            for (int i = 0; i < rolls.Length; i++)
            {
                _contestant.Roll(rolls[i]);
            }
        }

        private void rollSpare()
        {
            _contestant.Roll(6);
            _contestant.Roll(4);
        }

        [Test]
        public void TestGutterGame()
        {
            rollMany(20, 0);
            Assert.AreEqual(0, _contestant.GetScore());
        }

        [Test]
        public void TestAllOnes()
        {
            rollMany(20, 1);
            Assert.AreEqual(20, _contestant.GetScore());
        }

        [Test]
        public void TestOneSpare()
        {
            rollSpare();
            _contestant.Roll(4);
            rollMany(17, 0);
            Assert.AreEqual(18, _contestant.GetScore());
        }

        [Test]
        public void TestOneStrike()
        {
            _contestant.Roll(10);
            _contestant.Roll(4);
            _contestant.Roll(5);
            rollMany(17, 0);
            Assert.AreEqual(28, _contestant.GetScore());
        }

        [Test]
        public void TestPerfectGame()
        {
            rollMany(12, 10);
            Assert.AreEqual(300, _contestant.GetScore());
        }

        [Test]
        public void TestRandomGameNoExtraRoll()
        {
            rollSequence(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 0 });
            Assert.AreEqual(131, _contestant.GetScore());
        }

        [Test]
        public void TestRandomGameWithSpareThenStrikeAtEnd()
        {
            rollSequence(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 1, 10 });
            Assert.AreEqual(143, _contestant.GetScore());
        }

        [Test]
        public void TestRandomGameWithThreeStrikesAtEnd()
        {
            rollSequence(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 10, 10, 10 });
            Assert.AreEqual(163, _contestant.GetScore());
        }
    }
}