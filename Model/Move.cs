using System;

namespace Model
{
    public class Move : IEquatable<Move>
    {
        public Move()
        {}

        public Move(Player player, Lines line, Columns column)
        {
            Line = line;
            Column = column;
            Player = player;
        }

        public Columns Column { get; set; }

        public Lines Line { get; set; }

        public Player Player { get; set; }

        #region IEquatable<Move> Members

        public bool Equals(Move other)
        {
            return Player == other.Player && Line == other.Line && Column == other.Column;
        }

        #endregion
    }
}