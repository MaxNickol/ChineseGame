using System;
using System.Collections.Generic;
using System.Text;

namespace ChineseGame
{
    internal class AIPLayer
    {
        internal int Move { get; private set; }

        public int Turn(Game game, int parsed)
        {
            Random r = new Random();

            parsed = r.Next(1, 4);

            game.Sticks -= parsed;

            Move = parsed;

            return parsed;
        }
    }
}