using BowlingGame.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingGame.Web.Models
{
    public class FrameData
    {
        public int Frame { get; set; }
        public int PinsKnocked { get; set; }
    }
}
