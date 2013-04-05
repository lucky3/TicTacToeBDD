using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class Game
    {
        public Game()
        {
            ToMove = Player.Circle;
            Mode = PlayMode.Playing;
        }

        #region "Public properties"

        public Player ToMove { get; set; }
        public PlayMode Mode { get; set; }

        #endregion

        #region "Private properties"

        private readonly List<Move> _moveList = new List<Move>();
        #endregion

        #region "Public methods"

        public void MakeMove(Move move)
        {
            if (!IsMoveValid(move)) return;
            _moveList.Add(move);
            CheckForWin();
            if (_moveList.Count == 9)
            {
                Mode = PlayMode.Draw;
                return;
            }
            if (Mode == PlayMode.Playing)
                SwitchPlayerToMove();
        }

        #endregion

        #region "Private methods"

        private void CheckForWin()
        {
            for (int i = 1; i < 3; i++)
            {
                List<Move> columns = CheckForWinInColumns((Columns) i);
                List<Move> lines = CheckForWinInLines((Lines) i);
                if ((columns.Count == 3) | (lines.Count == 3))
                    WhoIsTheWinner();
            }

            List<Move> diagonal = CheckForWinInDiagonal();
            List<Move> contraDiagonal = CheckForWinInContraDiagonal();
            if ((diagonal.Count == 3) | (contraDiagonal.Count == 3))
                WhoIsTheWinner();
        }

        private void WhoIsTheWinner()
        {
            Mode = ToMove == Player.Circle ? PlayMode.CircleWon : PlayMode.CrossWon;
        }

        private List<Move> CheckForWinInColumns(Columns column)
        {
            return (from mov in _moveList
                    where mov.Column == column && mov.Player == ToMove
                    select mov).ToList();
        }

        private List<Move> CheckForWinInLines(Lines line)
        {
            return (from move in _moveList
                    where move.Line == line && move.Player == ToMove
                    select move).ToList();
        }

        private List<Move> CheckForWinInDiagonal()
        {
            var moves = new List<Move>();
            for (int i = 1; i <= 3; i++)
            {
                int i1 = i;
                IEnumerable<Move> found = from move in _moveList
                                          where move.Line == (Lines) i1
                                                && move.Column == (Columns) i1
                                                && move.Player == ToMove
                                          select move;
                moves.AddRange(found);
            }
            return moves;
        }

        private List<Move> CheckForWinInContraDiagonal()
        {
            return (from move in _moveList
                    where ((move.Line == Lines.A && move.Column == Columns.Three)
                           | (move.Line == Lines.B && move.Column == Columns.Two)
                           | (move.Line == Lines.C && move.Column == Columns.One))
                          && move.Player == ToMove
                    select move).ToList();
        }

        private void SwitchPlayerToMove()
        {
            ToMove = ToMove == Player.Circle ? Player.Cross : Player.Circle;
        }

        private bool IsMoveValid(Move move)
        {
            return !_moveList.Contains(move);
        }

        #endregion
    }
}