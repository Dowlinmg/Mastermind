using System;

namespace Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.Start();
            while (!game.IsOver)
            {
                game.TakeTurn();
            }
            game.End();
        }
    }
}
