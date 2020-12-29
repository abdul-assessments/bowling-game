using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame.Core.Interfaces
{
    public interface ICachedGame
    {
        bool DoesGamingSessionExist { get; }
        bool IsGamingSessionComplete { get; }
    }
}
