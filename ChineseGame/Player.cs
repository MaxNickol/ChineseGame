using System;
using System.Collections.Generic;
using System.Text;

namespace ChineseGame
{
    internal class Player
    {
        public int ID { get; private set; } = 1;

        public int Turn(Game game, int amountSticks)
        {
            game.Sticks -= amountSticks;

            return game.Sticks;
        }
    }
}