using System;
using System.Collections.Generic;
using NUnit.Framework;
using TechTalk.SpecFlow;
using Model;
using TechTalk.SpecFlow.Assist;

namespace Tests.ModelTests
{
    [Binding]
    public class SpecGameSteps
    {
        private Game _game;

        [Given(@"New game starts")]
        public void GivenNewGameStarts()
        {
            _game = new Game();
        }

        [Then(@"player to move is ""(.*)""")]
        public void ThenPlayerToMoveIs(Player playerToMove)
        {
            Assert.AreEqual(playerToMove, _game.ToMove);
        }

        [Then(@"play mode is ""(.*)""")]
        public void ThenPlayModeIs(PlayMode mode)
        {
            Assert.AreEqual(mode, _game.Mode);
        }

        [When(@"Player makes move")]
        public void WhenMakesMove(Table table)
        {
            var move = table.CreateInstance<Move>();
            _game.MakeMove(move);
        }

        [When(@"Players play moves")]
        public void WhenPlayersPlayMoves(Table table)
        {
            var moves = table.CreateSet<Move>();
            foreach (var move in moves)
            {
                _game.MakeMove(move);
            }
        }

    }
}
