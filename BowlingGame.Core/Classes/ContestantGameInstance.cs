using BowlingGame.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame.Core.Classes
{
    public class ContestantGameInstance : IContestantInstance
    {
        private bool _isInstanceComplete;
        public bool IsInstanceComplete => _isInstanceComplete;

        public string ContestantName { get; set; }

        public int GetScore()
        {
            throw new NotImplementedException();
        }

        public void Roll(int pins)
        {
            throw new NotImplementedException();
        }
    }
}
