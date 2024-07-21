using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;

namespace Group1_A54_IT111L
{
    class Astaroth
    {
        private readonly Enemy Ren;
        public Player Player;
        public Game_File gameFile;

        public int Level;
        private readonly string Name;
        private readonly string Character;
        public string Weapon;
        private int Health;
        private int Strength;
        private int Defense;
        private int Intelligence;
        private int Vials;
        


        public string enemyName = "Ren";
        public int enemyHealth = 60;
        public int attackPower = 15;
        public string enemyType = "Hellfang";
        public string TextArt = ImageCharacters.Snake;

        public bool choice = false;

        public Astaroth(Player player)
        {
            Level = player.Level;
            Name = player.Name;
            Health = player.Health;
            Character = player.Character;
            Weapon = player.Weapon;
            Strength = player.Strength;
            Defense = player.Defense;
            Intelligence = player.Intelligence;
            Vials = player.WaterVials;
            gameFile = new Game_File();
            Ren = new Enemy(enemyName, enemyType, enemyHealth, attackPower, TextArt);
            Player = new Player(Level, Name, Weapon, Character, Health, Strength, Defense, Intelligence, Vials);
           
        }

        public void Narration()
        {
            int[] order = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
            Game(order);
        }

        public void Selection(int order)
        {

            string[] optionListFile = File.ReadLines("AstarothSelection.txt").ToArray();
            if (order == 1)
            {
                do
                {
                    try
                    {
                        string question = $@"



            You continued walking and found 2 diverged paths.

                Hint: The left path is always right.


                                                               Which path will you choose?
";


                        string[] option = optionListFile[0].Split('/');

                        Menu questionMenu = new Menu(option, question);
                        int selectedChoice = questionMenu.RunOptions();

                        if (selectedChoice == 0)
                        {
                            choice = true;
                            break;
                        }
                        else
                        {
                            choice = false;
                            OtherChoice1(selectedChoice);
                            ReadKey();
                        }
                    }
                    catch (Selection1)
                    {
                        choice = true;
                        OtherResult1();
                    }
                } while (choice);

                CorrectResult1();

            }

            else if (order == 3)
            {
                string question = $@"



                It was said that a fountain exists in each dungeon which gives you vials that could heal yourself, 
            as well as inflict damage to the enemies of the dungeon.

                                         How many vials do you wish to use to get from the Astaroth fountain?
    

";

                string[] option = { "1", "2", "3" };

                Menu questionMenu = new Menu(option, question);
                int selectedChoice = questionMenu.RunOptions();
                if (selectedChoice == 0)
                {
                    WriteLine($@"
    You have obtained {selectedChoice + 1} water vial.
 
");
                    Vials = Player.StoreVials(Name, selectedChoice + 1);
                    ReadKey();
                }
                else
                {
                    WriteLine($@"
    You have obtained {selectedChoice + 1} water vials.

");
                    Vials = Player.StoreVials(Name, selectedChoice + 1);
                    ReadKey();
                }
            }

            else if (order == 5)
            {
                do
                {
                    try
                    {
                        string question = $@"
        


                                                             5 | 7 | 11 | 13 | 17 | ?


                                                        Which number completes the puzzle?

";
                        string[] option = optionListFile[1].Split('/');

                        Menu questionMenu = new Menu(option, question);
                        int selectedChoice = questionMenu.RunOptions();

                        if (selectedChoice == 2)
                        {
                            choice = true;
                            break;
                        }
                        else
                        {
                            choice = false;
                            OtherChoice0(selectedChoice);
                            OtherChoice1(selectedChoice);
                            OtherChoice3(selectedChoice);
                            ReadKey();
                        }
                    }
                    catch(Selection0)
                    {
                        choice = true;
                        OtherResult2();
                    }
                    catch(Selection1)
                    {
                        choice = true;
                        OtherResult2();
                    }
                    catch(Selection3)
                    {
                        choice = true;
                        OtherResult2();
                    }
                } while (choice);
                CorrectResult1();
            }

            else if (order == 6)
            {
                do
                {
                    try
                    {
                        string question = $@"



                                                                 3 | 5 | 8 | 13 | 22 | ?


                                                         Which number replaces the question mark?
    
";

                        string[] option = optionListFile[2].Split('/');

                        Menu questionMenu = new Menu(option, question);
                        int selectedChoice = questionMenu.RunOptions();

                        if (selectedChoice == 2)
                        {
                            choice = true;
                            break;
                        }
                        else
                        {
                            choice = false;
                            OtherChoice0(selectedChoice);
                            OtherChoice1(selectedChoice);
                            OtherChoice3(selectedChoice);
                            ReadKey();
                        }
                    }
                    catch (Selection0)
                    {
                        choice = true;
                        OtherResult3();
                    }
                    catch (Selection1)
                    {
                        choice = true;
                        OtherResult3();
                    }
                    catch (Selection3)
                    {
                        choice = true;
                        OtherResult3();
                    }
                } while (choice);
                CorrectResult1();
            }

            else if (order == 7)
            {
                do
                {
                    try
                    {
                        string question = $@"



                                                                26 | 28 | 31 | 35 | ?


                                                      Which number is missing from the sequence?

";

                        string[] option = optionListFile[3].Split('/');

                        Menu questionMenu = new Menu(option, question);
                        int selectedChoice = questionMenu.RunOptions();

                        if (selectedChoice == 1)
                        {
                            choice = true;
                            break;
                        }
                        else
                        {

                            OtherChoice0(selectedChoice);
                            OtherChoice2(selectedChoice);
                            OtherChoice3(selectedChoice);
                            ReadKey();
                        }
                    }
                    catch (Selection0)
                    {
                        choice = true;
                        OtherResult4();
                    }
                    catch (Selection2)
                    {
                        choice = true;
                        OtherResult4();
                    }
                    catch (Selection3)
                    {
                        choice = true;
                        OtherResult4();
                    }
                } while (choice);
                CorrectResult1();
            }
            else if (order == 11)
            {
                do
                {
                    try
                    {
                        string question = $@"
                


                                                                   1  |   5 | 13
                                                                      |  29 |
                                                                   61 | 125 |  ?

                                                      Which number replaces the question mark?
        
";

                        string[] option = optionListFile[4].Split('/');

                        Menu questionMenu = new Menu(option, question);
                        int selectedChoice = questionMenu.RunOptions();

                        if (selectedChoice == 2)
                        {
                            choice = true;
                            break;
                        }
                        else
                        {
                            choice = false;
                            OtherChoice0(selectedChoice);
                            OtherChoice1(selectedChoice);
                            OtherChoice3(selectedChoice);
                            ReadKey();
                        }
                    }
                    catch (Selection0)
                    {
                        choice = true;
                        OtherResult5();
                    }
                    catch (Selection1)
                    {
                        choice = true;
                        OtherResult5();
                    }
                    catch (Selection3)
                    {
                        choice = true;
                        OtherResult5();
                    }
                } while (choice);
            }

        }

        public void OtherChoice0(int selection)//depends on the order of choice
        {
            if (selection == 0)
            {
                throw new Selection0();
            }
        }
        public void OtherChoice1(int selection)
        {
            if (selection == 1)
            {
                throw new Selection1();
            }
        }
        public void OtherChoice2(int selection)
        {
            if (selection == 2)
            {
                throw new Selection2();
            }
        }

        public void OtherChoice3(int selection)
        {
            if (selection == 3)
            {
                throw new Selection3();
            }
        }

        public void OtherResult1()
        {
            int damage = 10;

            WriteLine($@"



                    As you stray down the left path, you accidentally stepped on something that caused the path to having fire.

            You ran back to the diverged paths. Health has decreased by 10.

");
            Health = Player.NormalSelectionLoseHealth(Name, damage);

            if (Health <= damage)
                Restart();
            else
                WriteLine($@"

                    {Name}’s health: - {damage}
");
            WriteLine($@"
    Current Health of {Name}: {Health}

");
            ReadKey();

        }

        public void OtherResult2()
        {
            int damage = 5;

            WriteLine($@"


                    Wrong answer. Please try again.

");
            Health = Player.NormalSelectionLoseHealth(Name, damage);
            if (Health <= damage)
                Restart();
            else
                WriteLine($@"

                    {Name}’s health: - {damage}
");
            WriteLine($@"
    Current Health of {Name}: {Health}

");
            ReadKey();
        }

        private void OtherResult3()
        {
            int damage = 7;

            WriteLine($@"


                    Wrong answer. Please try again.

");
            Health = Player.NormalSelectionLoseHealth(Name, damage);
            if (Health <= damage)
                Restart();
            else
                WriteLine($@"

                    {Name}’s health: - {damage}
");
            WriteLine($@"
    Current Health of {Name}: {Health}

");
            ReadKey();
        }

        public void OtherResult4()
        {
            int damage = 9;

            WriteLine($@"


                    Wrong answer. Please try again.


");
            Health = Player.NormalSelectionLoseHealth(Name, damage);
            if (Health <= damage)
                Restart();
            else
                WriteLine($@"

                    {Name}’s health: - {damage}
");
            WriteLine($@"
    Current Health of {Name}: {Health}

");
            ReadKey();
        }

        public void OtherResult5()
        {
            int damage = 10;
            WriteLine($@"


                    Wrong answer. Please try again.


");
            Health = Player.NormalSelectionLoseHealth(Name, damage);
            if (Health <= damage)
                Restart();
            else
                WriteLine($@"

                    {Name}’s health: - {damage}
");
            WriteLine($@"
    Current Health of {Name}: {Health}

");
            ReadKey();
        }


        public void CorrectResult1()
        {
            string upgradeSelect = @"



                                                               [UPGRADE SELECTION]

                                                         Which one do you wish to upgrade?

";

            string[] upgradeChoice = { "Strength", "Defense", "Intelligence" };

            Menu upgradeOption = new Menu(upgradeChoice, upgradeSelect);
            int selectedUpgrade = upgradeOption.RunOptions();

            int upgrade = 1;

            if (selectedUpgrade == 0)
            {
                Strength = Player.GainStrength(Name, upgrade);
            }
            else if (selectedUpgrade == 1)
            {
                Defense = Player.GainDefense(Name, upgrade);
            }
            else
                Intelligence = Player.GainIntelligence(Name, upgrade);
        }


        public void Restart()
        {
            Clear();
            WriteLine($@"



                {Name}’s health: 0

                {Player.Name} has been defeated. Returning to the Entrance of Focalor Dungeon.


            Press any key to continue...");
            ReadKey();
            Clear();
            Level = 1;
            string[] characters = { "Archaeologist", "Adventurer", "Barbarian" };
            if (Character == characters[0])
            {
                gameFile.UpdateDefense(Name, 4);
                gameFile.UpdateHealth(Name, 100);
                gameFile.UpdateIntelligence(Name, 7);
                gameFile.UpdateStrength(Name, 4);
                gameFile.UpdateLevel(Name, 1);
                gameFile.UpdateVials(Name, 0);
                Player = new Player(Level, Name, Weapon, Character, 100, 4, 4, 7, 0);
                Focalor focalor = new Focalor(Player);
                focalor.Narration();
            }
            else if (Player.Character == characters[1])
            {
                gameFile.UpdateDefense(Name, 5);
                gameFile.UpdateHealth(Name, 100);
                gameFile.UpdateIntelligence(Name, 5);
                gameFile.UpdateStrength(Name, 5);
                gameFile.UpdateLevel(Name, 1);
                gameFile.UpdateVials(Name, 0);
                Player = new Player(Level, Name, Weapon, Character, 100, 5, 5, 5, 0);
                Focalor focalor = new Focalor(Player);
                focalor.Narration();
            }
            else if (Player.Character == characters[2])
            {
                gameFile.UpdateDefense(Name, 5);
                gameFile.UpdateHealth(Name, 100);
                gameFile.UpdateIntelligence(Name, 3);
                gameFile.UpdateStrength(Name, 7);
                gameFile.UpdateLevel(Name, 1);
                gameFile.UpdateVials(Name, 0);
                Player = new Player(Level, Name, Weapon, Character, 100, 7, 5, 3, 0);
                Focalor focalor = new Focalor(Player);
                focalor.Narration();
            }
        }

        public void Fight()
        {
            Ren.DisplayInfo();
            

            do
            {
                
                string question = $@"

                

                                                                What will you do?
";

                string[] option = { "1 = Attack", "2 = Vial", "3 = Flee" };

                Menu questionMenu = new Menu(option, question);
                int selectedChoice = questionMenu.RunOptions();

                if (selectedChoice == 0)
                {
                    Player.Attack(enemyName, Strength);
                    enemyHealth = Ren.LoseHealth(Strength);
                }
                else if (selectedChoice == 1)
                {

                    string[] vialoptions = { "1 = Throw Vial", "2 = Drink Vial" };
                    Menu vialMenu = new Menu(vialoptions, "What will you do with the Vial?");
                    int vialaction = vialMenu.RunOptions();
                    if (vialaction == 0)
                    {
                        if (Vials > 0)
                        {
                            if (Intelligence >= 8)
                            {
                                Vials = Player.ThrowVial(Ren.Name, Player.Name, 15);
                                enemyHealth = Ren.LoseHealth(15);

                            }
                            else if (Intelligence > 4 && Intelligence <= 7)
                            {
                                Vials = Player.ThrowVial(Ren.Name, Player.Name, 10);
                                enemyHealth = Ren.LoseHealth(10);

                            }
                            else if (Intelligence < 4)
                            {
                                Vials = Player.ThrowVial(Ren.Name, Player.Name, 5);
                                enemyHealth = Ren.LoseHealth(5);

                            }
                        }
                        else
                        {
                            WriteLine(@"
                You no longer have Vials to use.

");
                        }
                        ReadKey();
                    }
                    else
                    {
                        if (Vials > 0)
                        {
                            if (Intelligence >= 9)
                            {
                                Health = Player.DrinkVial(Name, 20);
                                Vials -= 1;
                            }

                            else if (Intelligence > 4 && Intelligence <= 7)
                            {
                                Health = Player.DrinkVial(Name, 10);
                                Vials -= 1;
                            }

                            else if (Intelligence < 4)
                            {
                                Health = Player.DrinkVial(Name, 5);
                                Vials -= 1;
                            }
                        }
                        else
                        {
                            WriteLine(@"
                Oh no! You're out of Vials! 

");
                        }
                        ReadKey();
                    }


                }

                else
                {
                    WriteLine($@"


            {enemyName} won't let you flee!
");

                    int damage = 5;

                    Health = Player.LoseHealth(Name, damage, Defense);
                }
                if (enemyHealth <= 0) 
                {
                    break;
                }
                else
                {
                    ReadKey();
                    Ren.Attack(Name, Defense);
                    ReadKey();
                    Health = Player.LoseHealth(Name, attackPower, Defense);
                }
                if (Health <= 0)
                    Restart();

            } while (Health != 0 || Health < 0);
        }

        public void Game(int[] order)
        {
            foreach (int i in order)
            {
                if (i == 1 || i == 3 || i == 5 || i == 6 || i == 7 || i == 11)//choices
                {
                    Selection(i);
                    Clear();
                }

                else if (i == 9)//fight scene
                {
                    WriteLine($@"
                    


                                                      At the end of your path lies a huge door. 

                             As you open the door, you see a huge snake protecting the last chest and the 3rd Archaic Stone.


");
                    ReadKey();
                    Clear();
                    Fight();
                    Clear();
                }
                else if (i == 12)//ending
                {
                    WriteLine($@"



                    The Snake was pleased with your wits, thus assisting you with your return to your HQ. 

            With all the Archaic Stones in your possession, you come back to the Teyvat Industries to input the stones upon the Great Staff.



                                      Congratulations! You have collected every stone from the island of Carcino.
    
                        You witnessed the great power that lies within the Staff, marking the end of your journey from the dungeon 
                                              since you have completed your goal by obtaining the stones.

                                                           Congratulations! You win the game!

                                            

                                             You may check your rank from the LeaderBoard at the Main Menu.

");
                    ReadKey();
                    Clear();
                    Game game = new Game();
                    game.Opening();

                }
                else//normal narrations
                {
                    if (i == 0)
                    {
                        WriteLine($@"



                                  You have arrived at the last dungeon and found the entrance to the Astaroth Dungeon. 

                               Upon entering the dungeon, you begin your search for the last stone, the 3rd Archaic Stone.


                                    ;ttt@%X%S%%%XX%S%S%S%X%%X%S%S%S%X%S%%%XX%S%S%S%S%S%X%S%S%%X%%%XX%%XX%%XX%S%%%ttt
                                      8S@X888@888@8@8@888888@888888@8@8@8888@8@888@8@8@@88@88888888@@@88888888888@XS 
                                    @8X@88@88X@X t%8%tX888@@888@8888@88@8@X@888@88@@88888@88X%X XX@8%SX8888@@888@@8@
                                    @8S88888@@:%X t. S . X88@888@8@88888888@@@@8888@8@88@88@ :tX %:.S: XX88888X8S@8S
                                    @8S@X88S8SX8X8@X88 X::8888888888888@8888888@8@88@8S8@X88t@@@X@S88 8. 8X88@8@@ 8S
                                    @8S8@@t%S:S%%8X.XXtS8 8@@888@@88@888888@8@8888888888@X%S.StSX%;@8:%X.S@88@8@X@@X
                                    @8S888@:XtS 8@;%;SS SSt%;8888@888%88888@8@88888888@8S8 8tS:88.XXtX.8%%%%88888X@S
                                    @8X8888XX88@X88X@88S8;:;%888888X8X@S8.@  8tSS88S8@8888SX888 S88S8@88%t 8888@X@@S
                                    @8 8888@88@88@88888888@88888@S..St;:@8::.;X@: S8% @88888@X88888888@8888@88888@@S
                                    @8X@888888@8888@88S8@@ 88888S%tt88::88;St:8@.S .S;88@S.88888@888888888@@88@88X8X
                                    @8 88888888888888@@888t%88888@%%@t%888888.;8X %;%@@X88SS8888@@888S8888@@X8888X@S
                                    @8X8X88888@888@@8888@%.8@88X;:;888;8.8 @S8.8 88t.X88;@ 88@888@8@8888X888@8888@8 
                                    @8X88@8888888S@S@@88@St@8@8Xt:tSX@8%8X.S.X:88 @%:X8SX8888X@8SS88@X888S@8@8X@8 @@
                                    @8 X88X;XX8S@S;SX@8@X8%88@8XStt: :88@;S.@S88;8X;:88@@8XX88888SX@88Xt%X8@@@@8@8@ 
                                    @8 8888XX8@8@8@@888X8XS888@88%t;t88;.t8t8@888 S%;@8X8S8@888@@X888888@@8888888 @@
                                    @8 @88@;888@@8X888888@@88@88S%%S;:X888 %X8@ 88;t;@88@88888@88X8@888888@8;8888 @ 
                                    @8 8@@8X888888X8@888@88X8888@St%;8;S:@88%@ 8888%;X8888@8@8@88S88@@8@S8@88@@88 @X
                                    @8 88@8X888@88@88888@888X88@8ttt888t@:88@8;t@88@ 88888@888888@888888t888@8888 @ 
                                    SX;SX@8X8888@@SX888888@8@8888S;;8 8X8t88888;8;8Xt@888888@X@88X8@888@@8@@@888X 8X
                                      @8;X888888888X8@888888X@8888@tt88:8:8t8t8 8.88; 8X888X8888@@@@88888X8@@8S88;8S 
                                    @@8S@888@8@88@8888@88@888@8@@8tt:88S8t8 8 8 X 8@S%888@88@8X8@X8@888@@88@@8@8.8@X
                                    .;t88@@88@8888X8@88888888@8; %S:S888@8888888888. .@t88888SXS8X8X8X8@S8@8@8888%:;
                                    888@@8%XXX8@@88888888888@8@@ @SS@@8tX:88%8 8@; %X8S88@88888@8@S888@8@8888@8@8@88
                                    @@8S@888@8@88@8888@88@888@8@@8tt:88S8t8 8 8 X 8@S%888@88@8X8@X8@888@@88@@8@8.8@X
                                    .;t88@@88@8888X8@88888888@8; %S:S888@8888888888. .@t88888SXS8X8X8X8@S8@8@8888%:;
                                    888@@8%XXX8@@88888888888@8@@ @SS@@8tX:88%8 8@; %X8S88@88888@8@S888@8@8888@8@8@88
                                    @@8X 8SS XX @   SX888@88@XS ;t:::.88%8X8888%@88 ;t.Xt88X@XX888X8@@88@888@88X8@@8
                                    XSS 8 X 8 X S    @@@8S 8X :  t;tX%8%8X888.88 .8%t;t%8X 8@S@XX@ %@88@X  S88S @ @ 
                               
                              

");
                    }
                    else if (i == 2)
                        WriteLine($@"



                                                    After going through the path leading downward, 
                                you see a fountain that resembles the one you first saw at the Focalor and Vinea Dungeon.

");
                    else if (i == 4)
                        WriteLine($@"



                                Not too far from the fountain, you encounter a puzzle embedded on the side of the wall. 

                        To unlock your path that is being blocked by a fire, you must first solve three puzzles to cease the fire.


");
                    else if (i == 8)
                        WriteLine($@"



                                     The fire has ceased and you’re able to proceed walking towards the path. 

                                 To your surprise, Astaroth Dungeon isn’t as dangerous as the first two dungeons. 

                                      This is proven to be true when you finally reach the end of your path.                                

                        


");
                    else if (i == 10)
                        WriteLine($@" 



                                                      After the battle with the Great snake Ren, 
              you noticed that it revived itself and decided to give you the chance to obtain the 3rd Archaic Stone by solving this puzzle.

");

                    ReadKey();
                    Clear();
                }
            }

        }
    }
}
