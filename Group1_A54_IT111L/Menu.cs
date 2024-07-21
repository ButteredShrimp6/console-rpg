using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;

namespace Group1_A54_IT111L
{
   class Menu
    {
        private int Index;
        public string[] Options;
        private readonly string Text;

        public Menu(string[] options, string text)
        {
            Options = options;
            Text = text;
            Index = 0;
        }

        public void MainMenu()
        {
            //Title
            WriteLine(Text);
            
            for (int i = 0; i < Options.Length; i++)
            {
                if (i == Index)
                {
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                }
                WriteLine($"\n\t\t\t\t\t\t\t\t   << {Options[i]} >>");
                ResetColor();
            }
                    
        }

        public int RunOptions()
        {
            ConsoleKey keyPressed;

            do
            {

                Clear();
                MainMenu();

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    Index--;

                    if (Index == -1)
                    {
                        Index = Options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    Index++;

                    if (Index == Options.Length)
                    {
                        Index = 0;
                    }
                }

            } while (keyPressed != ConsoleKey.Enter);
            return Index;
        }

    }

        
}
