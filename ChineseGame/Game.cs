using System;
using System.Collections.Generic;
using System.Text;

namespace ChineseGame
{
    public class Game
    {
        public delegate int MoveDelegate(Game game, int parsed);

        internal static MoveDelegate _del { get; private set; }

        private int sticks;

        internal int Sticks
        {
            get
            {
                return sticks;
            }
            set
            {
                if (value < 0) sticks = 0;
                else sticks = value;
            }
        }

        internal GameStatus GameStatus { get; set; } = GameStatus.NotStarted;

        internal MoveDelegate RegisterOnMoveDelegate(MoveDelegate del)
        {
            _del = del;

            return _del;
        }
    }
}