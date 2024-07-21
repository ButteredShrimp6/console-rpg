using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;

namespace Group1_A54_IT111L
{
    class Game
    {

        private Player CurrentPlayer;

        public void Opening()
        {
            string text = @"
           
                                     (                                        (                              ____ 
                                     )\ )                                     )\ )                          |   / 
                                    (()/(    (        (  (    (              (()/(  (  (    )  (   )     (  |  /  
                                     /(_))  ))\  (    )\))(  ))\ (   (        /(_))))\ )(  /(( )\ /((   ))\ | /   
                                    (_))_  /((_) )\ )((_))\ /((_))\  )\ )    (_)) /((_|()\(_))((_|_))\ /((_)|/    
                                      |   \(_))( _(_/( (()(_|_)) ((_)_(_/( )  / __(_))( ((_))((_|_))((_|_)) (      
                                      | |) | || | ' \)) _` |/ -_) _ \ ' \))(  \__ \ || | '_\ V /| \ V // -_))\     
                                      |___/ \_,_|_||_|\__, |\___\___/_||_(_)) |___/\_,_|_|  \_/ |_|\_/ \___((_)    
                                                       |___/                                                        
                           
   ";
            string[] Options = { "New Game", "Load", "Leaderboard", "About", "Credits", "Exit" };
            Menu startUp = new Menu(Options, text);
            int indexOption = startUp.RunOptions();

            switch (indexOption)
            {
                case 0:
                    Clear();
                    NewGame(); 
                    ReadKey();
                    break;
                case 1:
                    Clear();
                    LoadGame(); 
                    ReadKey();
                    
                    break;
                case 2:
                    Clear();
                    LeaderBoard();
                    ReadKey();
                    Opening();
                    break;
                case 3:
                    Clear();
                    About();
                    ReadKey();
                    Opening();
                    break;
                case 4:
                    Clear();

                    WriteLine(@"

                                .-=~=-.                                                                 .-=~=-.
                                (__  _)-._.-=-._.-=-._.-=-._.-=-._.-=-._.-=-._.-=-._.-=-._.-=-._.-=-._.-(__  _)
                                ( _ __)                                                                 ( _ __)
                                (__  _)                                                                 (__  _)
                                (_ ___)                                                                 (_ ___)
                                (__  _)                           [CREDITS]                             (__  _)
                                ( _ __)                                                                 ( _ __)
                                (__  _)                                                                 (__  _)
                                (_ ___)                         Dungeon,Survive!                        (_ ___)
                                (__  _)                                                                 (__  _)
                                ( _ __)                                                                 ( _ __)
                                (__  _)                    Clavillas, Jake Russel D.                    (__  _)
                                (_ ___)                      Haber, Nikka May A.                        (_ ___)
                                (__  _)                      Maala, Andrea Mei T.                       (__  _)
                                ( _ __)                     Moral, Aaliyah Zafira H.                    ( _ __)
                                (__  _)                    Ticzon, Guadalupe Anne P.                    (__  _)
                                (_ ___)                                                                 (_ ___)
                                (__  _)                                                                 (__  _)
                                ( _ __)                                                                 ( _ __)
                                (__  _)                                                                 (__  _)
                                ( _ __)                                                                 ( _ __)
                                (__  _)                                                                 (__  _)
                                (_ ___)-._.-=-._.-=-._.-=-._.-=-._.-=-._.-=-._.-=-._.-=-._.-=-._.-=-._.-(_ ___)
                                `-._.-'                                                                 `-._.-'


");
                    ReadKey();
                    Clear();
                    Opening();
                    break;
                case 5:
                    Clear();
                    WriteLine(@"

				    
                                             ('-. .-.               (`\ .-') /` _ .-') _               
                                            ( OO )  /                `.( OO ),'( (  OO) )              
                                            ,--. ,--. .-'),-----. ,--./  .--.   \     .'_   ,--.   ,--.
                                            |  | |  |( OO'  .-.  '|      |  |   ,`'--..._)   \  `.'  / 
                                            |   .|  |/   |  | |  ||  |   |  |,  |  |  \  ' .-')     /  
                                            |       |\_) |  |\|  ||  |.'.|  |_) |  |   ' |(OO  \   /   
                                            |  .-.  |  \ |  | |  ||         |   |  |   / : |   /  /\_  
                                            |  | |  |   `'  '-'  '|   ,'.   |   |  '--'  / `-./  /.__) 
                                            `--' `--'     `-----' '--'   '--'   `-------'    `--'      

                                                         _____________________________   
                                                        /        _____________        \  
                                                        | == .  |             |     o |  
                                                        |   _   |             |    B  |  
                                                        |  / \  |             | A   O |  
                                                        | | O | | EXITING...  |  O    |  
                                                        |  \_/  |             |       |  
                                                        |       |             | . . . |  
                                                        |  :::  |             | . . . |  
                                                        |  :::  |_____________| . . . |  
                                                        |           S N K             |  
                                                        \_____________________________/



");
                    ReadKey(true);
                    Environment.Exit(0);
                    break;
            }
           
        }

        private void NewGame()
        {
            string userName;
            do
            {
                Write(@"
    Enter your Name: ");
                userName = ReadLine();
            } while (userName == "");

            string[] characters = { "Archaeologist", "Adventurer", "Barbarian" };
            string text1 = @"
    Choose your Character:
";
            Menu characterSelection = new Menu(characters, text1);
            int selectedCharacter = characterSelection.RunOptions();
            
            string text2 = @"
    Choose a Weapon:
";
            string[] weapons = { "Sword", "Lance", "Axe" };
            Menu weaponSelection = new Menu(weapons, text2);
            int weaponSelected = weaponSelection.RunOptions();

            int level = 0;
 
            if (selectedCharacter == 0)
                CurrentPlayer = new Player(level, userName, weapons[weaponSelected], characters[selectedCharacter], 100, 4, 4, 7, 0);
            else if(selectedCharacter == 1)
                CurrentPlayer = new Player(level, userName, weapons[weaponSelected], characters[selectedCharacter], 100, 5, 5, 5, 0);
            else if (selectedCharacter == 2)
                CurrentPlayer = new Player(level, userName, weapons[weaponSelected], characters[selectedCharacter], 100, 7, 5, 3, 0);

            Clear();
            CurrentPlayer.DisplayInfo();
            CurrentPlayer.Save();
            ReadKey();
            Clear();
            Run(level, CurrentPlayer);
        }

        private void LoadGame()
        {
            try
            {
                if (File.Exists("Game.Txt"))
                {
                    FileStream player = new FileStream("Game.Txt", FileMode.Open);
                    StreamReader playerReader = new StreamReader(player);
                    string record = playerReader.ReadLine();
                    string[] recordContent;

                    List<string> playerList = new List<string>();
                    List<int> levelList = new List<int>();

                    while (record != null)
                    {
                        recordContent = record.Split('/');
                        levelList.Add(int.Parse(recordContent[0]));
                        playerList.Add(recordContent[1]);
                        record = playerReader.ReadLine();
                    }
                    playerList.Add("Back to Main Menu");
                    playerReader.Close();
                    player.Close();

                    string[] playerNames = playerList.ToArray();
                    int[] playerLevel = levelList.ToArray();
                    

                    string text3 = (@"


                                           __  ______    ____ _________   ____ __    ___ _  _ ________ 
                                          (( \||   ||   ||   //  | || |   || \\||   // \\\\//||   || \\
                                           \\ ||== ||   ||==((     ||     ||_//||   ||=|| )/ ||== ||_//
                                          \_))||___||__|||___\\__  ||     ||   ||__||| ||//  ||___|| \\
                                                              

");

                    Menu playerSelection = new Menu(playerNames, text3);
                    int selectedPlayer = playerSelection.RunOptions();

                    string[] chosenPlayer = File.ReadLines("Game.txt").ToArray();
                    if (selectedPlayer == playerNames.Length)
                    {
                        Opening();
                    }
                    else
                    {
                        for (int i = 0; i < chosenPlayer.Length; i++)
                        {

                            string[] playerData = chosenPlayer[i].Split('/');
                            if (playerNames[selectedPlayer] == playerData[1])
                            {
                                CurrentPlayer = new Player(int.Parse(playerData[0]), playerData[1], playerData[4], playerData[3], int.Parse(playerData[2]), int.Parse(playerData[5]), int.Parse(playerData[6]), int.Parse(playerData[7]), int.Parse(playerData[8]));
                                break;
                            }
                        }
                    }
                    Clear();

                    Run(playerLevel[selectedPlayer], CurrentPlayer);
                }
                else
                {
                    WriteLine(@"
                              
                                            ╔╗╔╔═╗  ╔╦╗╔═╗╔╦╗╔═╗  ╔═╗╦  ╦╔═╗╦╦  ╔═╗╔╗ ╦  ╔═╗┬
                                            ║║║║ ║   ║║╠═╣ ║ ╠═╣  ╠═╣╚╗╔╝╠═╣║║  ╠═╣╠╩╗║  ║╣ │
                                            ╝╚╝╚═╝  ═╩╝╩ ╩ ╩ ╩ ╩  ╩ ╩ ╚╝ ╩ ╩╩╩═╝╩ ╩╚═╝╩═╝╚═╝o
");
                    ReadKey();
                    Opening();
                }
            }
            catch (IndexOutOfRangeException)
            {
                Opening();
            }
            catch (FormatException)
            {
                WriteLine(@"
                              
                                            ╔╗╔╔═╗  ╔╦╗╔═╗╔╦╗╔═╗  ╔═╗╦  ╦╔═╗╦╦  ╔═╗╔╗ ╦  ╔═╗┬
                                            ║║║║ ║   ║║╠═╣ ║ ╠═╣  ╠═╣╚╗╔╝╠═╣║║  ╠═╣╠╩╗║  ║╣ │
                                            ╝╚╝╚═╝  ═╩╝╩ ╩ ╩ ╩ ╩  ╩ ╩ ╚╝ ╩ ╩╩╩═╝╩ ╩╚═╝╩═╝╚═╝o
");
                ReadKey();
                Opening();
            }

        }

        private void LeaderBoard()
        {
            if (File.Exists("Game.Txt"))
            {
                int count = File.ReadLines("Game.Txt").Count();

                FileStream player = new FileStream("Game.Txt", FileMode.Open);
                StreamReader playerReader = new StreamReader(player);
                string record = playerReader.ReadLine();
                string[] recordContent = record.Split('/');

                List<KeyValuePair<int, string>> playerRank = new List<KeyValuePair<int, string>>();

                while (record != null)
                {
                    recordContent = record.Split('/');
                    record = playerReader.ReadLine();
                    for (int i = 0; i < count; i++)
                    {
                        playerRank.Insert(i, new KeyValuePair<int, string>(int.Parse(recordContent[0]), recordContent[1]));
                        break;
                    }
                    
                }
                
                int rank = 1;

                WriteLine(@"
         

                                         .-.-.  .-.-.  .-.-.  .-.-.  .-.-.  .-.-.  .-.-.  .-.-.  .-.-.
                                        =`. .'==`. .'==`. .'==`. .'==`. .'==`. .'==`. .'==`. .'==`. .'=
                                          ""      ""      ""      ""      ""      ""      ""      ""      ""
           
                                                             Player Ranking


                                                 RANK                            PLAYER
");
    
                foreach (var players in playerRank.OrderByDescending(key => key.Key))
                {
                    WriteLine("\t\t\t\t\t           {0}\t\t\t         {1}", rank, players.Value);
                    rank++;
                }
                WriteLine(@"

                                         +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
");
                playerReader.Close();
                player.Close();
            }
            else
            {
                WriteLine();
                WriteLine(@"
                              
                                            ╔╗╔╔═╗  ╔╦╗╔═╗╔╦╗╔═╗  ╔═╗╦  ╦╔═╗╦╦  ╔═╗╔╗ ╦  ╔═╗┬
                                            ║║║║ ║   ║║╠═╣ ║ ╠═╣  ╠═╣╚╗╔╝╠═╣║║  ╠═╣╠╩╗║  ║╣ │
                                            ╝╚╝╚═╝  ═╩╝╩ ╩ ╩ ╩ ╩  ╩ ╩ ╚╝ ╩ ╩╩╩═╝╩ ╩╚═╝╩═╝╚═╝o

");

                ReadKey();
                Opening();
            }
        }

        private void About()
        {
            WriteLine(@"

                                 __________________________________________________________________________
                                    /\                                                                     \
                                (O)===)><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><)==(O)
                                    \/'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''/
                                    (                                                                      (
                                     )    Dungeon, Survive! is a game made by Group 1 of A54 for IT111L     )
                                    (                                                                      (
                                     )                                                                      )

                                    (                                                                      (
                                     )                                                                      )
                                    (                                                                      (
                                     )                                                                      )

                                    (                                                                      (
                                     )                                                                      )
                                    (                                                                      (
                                     )                                                                      )

                                    (                                                                      (
                                     )                                                                      )
                                    (                                                                      (
                                    /\'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''\    
                                (O)===)><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><)==(O)
                                    \/____________________________________________________________________/
                            .
");
        }

        public void Run(int level, Player chosenPlayer)
        {
            string introduction= $@"




                                                           On the 30th of April in 1945 

                                                     {CurrentPlayer.Name},a researcher of Teyvat Industries, 
                                  found out about the 3 Archaic Stones which hold the power of Wind, Water, and Fire 
                                            that lies within the 3 dungeons of the island of Carcino; 
            

                                                           Focalor, Vinea, and Astaroth.


                These stones are said to be holding an immense power when gathered and inserted together to the staff of Great Sage Athos, 
                                               which is in the possession of the industries itself.

                                         You start your expedition on the island in search of the 3 stones.
            

        Press any key to continue....
";
            Game_File gameFile = new Game_File();
            switch (level)
            {
                
                case 0:
                    WriteLine(introduction);
                    ReadKey();
                    Clear();
                    gameFile.UpdateLevel(chosenPlayer.Name, 1);
                    Focalor DungeonFocalor = new Focalor(chosenPlayer);
                    DungeonFocalor.Narration();
                    
                    break;
                case 1:
                    DungeonFocalor = new Focalor(chosenPlayer);
                    DungeonFocalor.Narration();
                    break;
                case 2:
                    Vinea DungeonVinea = new Vinea(chosenPlayer);
                    DungeonVinea.Narration();

                    break;
                case 3:
                    Astaroth DungeonAstaloth = new Astaroth(chosenPlayer);
                    DungeonAstaloth.Narration();

                    break;
            }
        }
    }
}
