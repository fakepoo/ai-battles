using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AIBattles.TicTacToe.Game;
using AIBattles.TicTacToe.PlayerProxies;
using System.Collections.Generic;
using System.Diagnostics;
using AIBattles.Core.PlayerProxies;
using AIBattles.Core.Game;

namespace AIBattles.Tests
{
    [TestClass]
    public class TicTacToeTests
    {
        [TestMethod]
        public void PlayAiGame()
        {
            List<TicTacToeAutomatedPlayerProxy> playerProxies = new List<TicTacToeAutomatedPlayerProxy>();
            playerProxies.Add(new TicTacToeAutomatedPlayerProxy("X"));
            playerProxies.Add(new TicTacToeAutomatedPlayerProxy("O"));

            TicTacToeGame game = new TicTacToeGame(playerProxies);

            while(true)
            {
                IGameStatus status = game.ProcessGameStep();
                Debug.WriteLine(game.ToString());
                Debug.WriteLine("");

                if(status is GameOverStatus)
                {
                    string winner = ((GameOverStatus)status).NameOfWinner;
                    if(string.IsNullOrEmpty(winner))
                    {
                        Debug.WriteLine("The game has ended in a tie.");
                    }
                    else
                    {
                        Debug.WriteLine(winner + " has won the game.");
                    }
                    break;
                }
                else if(status is GameInProgressStatus)
                {
                    // Nothing to do
                }
                else
                {
                    throw new Exception("IGameStatus case not handled.");
                }
            }
        }

        [TestMethod]
        public void PlayNetworkGame()
        {
            List<PlayerProxy> playerProxies = new List<PlayerProxy>();
            playerProxies.Add(new TicTacToeAutomatedPlayerProxy("X"));
            playerProxies.Add(new NetworkPlayerProxy("O", new Uri("http://localhost:53554/TicTacToePlayer")));

            TicTacToeGame game = new TicTacToeGame(playerProxies);

            while (true)
            {
                IGameStatus status = game.ProcessGameStep();
                Debug.WriteLine(game.ToString());
                Debug.WriteLine("");

                if (status is GameOverStatus)
                {
                    string winner = ((GameOverStatus)status).NameOfWinner;
                    if (string.IsNullOrEmpty(winner))
                    {
                        Debug.WriteLine("The game has ended in a tie.");
                    }
                    else
                    {
                        Debug.WriteLine(winner + " has won the game.");
                    }
                    break;
                }
                else if (status is GameInProgressStatus)
                {
                    // Nothing to do
                }
                else
                {
                    throw new Exception("IGameStatus case not handled.");
                }
            }
        }
    }
}
