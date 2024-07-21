using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;


namespace Group1_A54_IT111L
{
    class Program
    {
        static void Main()
        {
            //Main Program
            SetWindowSize(147, 41);
            Title = "Dungeon, Survive!";
            Game game = new Game();
            game.Opening();
        }
    }
}
