using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;

namespace Group1_A54_IT111L
{
    class Vinea
    {
        private readonly Enemy Rhoedia;
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

        public string enemyName = "Rhoedeia";
        public int enemyHealth = 45;
        public int attackPower = 12;
        public string enemyType = "Sea Dragon";
        public string TextArt = ImageCharacters.Dragon;

        public bool choice = false;

        public Vinea(Player player)
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
            Rhoedia = new Enemy(enemyName, enemyType, enemyHealth, attackPower,TextArt);
            Player = new Player(Level, Name, Weapon, Character, Health, Strength, Defense, Intelligence, Vials);
        }

        public void Narration()
        {
            int[] order = {0, 1, 2, 3, 4, 5, 6, 7, 8 };
            Game(order);
        }

        public void Selection(int order)
        {


            string[] optionListFile = File.ReadLines("VineaSelection.txt").ToArray();
            if (order == 1)
            {
                do
                {
                    try
                    {

                        string question = $@"



            You continued walking and found 2 diverged paths.

                                                               Which path will you choose?
";

                        string[] option = optionListFile[0].Split('/');

                        Menu questionMenu = new Menu(option, question);
                        int selectedChoice = questionMenu.RunOptions();

                        if (selectedChoice == 1)
                        {
                            choice = true;
                            break;
                        }
                        else
                        {
                            choice = false;
                            OtherChoice0(selectedChoice);
                            ReadKey();
                        }
                    }
                    catch (Selection0)
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

                                         How many vials do you wish to use to get from the Vinea fountain?
    

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

            else if (order == 4)
            {
                do
                {
                    try
                    {
                        string question = $@"

                    Proceeding downward after getting some vials has led you to a path that is submerged underwater. 

            Coincidentally, you see unused swimming gear placed just before the steps proceeding underwater.


                                                                    What will you do?
";
                        string[] option = optionListFile[1].Split('/');

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
                            OtherChoice2(selectedChoice);
                            ReadKey();
                        }
                    }
                    catch (Selection1)
                    {
                        choice = true;
                        OtherResult2();
                    }
                    catch (Selection2)
                    {
                        choice = true;
                        OtherResult3();
                    }
                } while (choice);
                CorrectResult1();
            }

            else if (order == 5)
            {
                do
                {
                    try
                    {
                        string question = $@"



                    You have put on the swimming gear and proceeded swimming underwater. 

            However, you notice a vortex that could possibly pull you in and drown you. 

            Not too far, you see a group of fishes swimming against the vortex.


                                                                    What will you do?
";

                        string[] option = optionListFile[2].Split('/');

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
                            OtherChoice2(selectedChoice);
                            ReadKey();
                        }
                    }
                    catch (Selection1)
                    {
                        choice = true;
                        OtherResult4();
                    }
                    catch (Selection2)
                    {
                        choice = true;
                        OtherResult5();
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



                    You have passed through the vortex and arrived at a sea palace.

            To enter the sea palace, there’s a riddle that you must solve. 


                                    “I’m as hard as a rock, but I immediately melt in hot water. What am I?” the riddle says.


                                                           What do you think is the correct Answer?                            
";

                        string[] option = optionListFile[3].Split('/');

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
                        OtherResult6();
                    }

                } while (choice);
                CorrectResult1();
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
        public void OtherResult1()
        {
            int damage = 5;

            WriteLine($@"


            A strong wind came by and flew you down to the diverged paths.

");
            Health = Player.NormalSelectionLoseHealth(Name, damage);
            if (Health <= damage)
                Restart();
            else
                WriteLine($@"

                    {Name}’s health: - {damage}");

            WriteLine($@"
    Current Health of {Name}: {Health}

");
            ReadKey();
        }

        public void OtherResult2()
        {
            int damage = 5;

            WriteLine($@"


            You proceeded to swim underwater without using the gear. Later on, you ran short of oxygen and came back on the surface.

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
            int damage = 5;

            WriteLine($@"


            Waiting for another person doesn’t help obtaining the stone.

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
            int damage = 10;

            WriteLine($@"


            {Name} yeeted and charged towards the vortex and got damaged. Health has decreased by 10.

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
            int damage = 5;
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

        public void OtherResult6()
        {
            int damage = 5;

            WriteLine($@"

    
            Wrong Answer. Please Try again.
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
            {
                Intelligence = Player.GainIntelligence(Name, upgrade);
            } 
        }


        public void Restart()
        {
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
            Rhoedia.DisplayInfo();

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
                    enemyHealth = Rhoedia.LoseHealth(Strength);
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
                                Vials = Player.ThrowVial(Rhoedia.Name, Player.Name, 15);
                                enemyHealth = Rhoedia.LoseHealth(15);

                            }
                            else if (Intelligence > 4 && Intelligence <= 7)
                            {
                                Vials = Player.ThrowVial(Rhoedia.Name, Player.Name, 10);
                                enemyHealth = Rhoedia.LoseHealth(10);

                            }
                            else if (Intelligence < 4)
                            {
                                Vials = Player.ThrowVial(Rhoedia.Name, Player.Name, 5);
                                enemyHealth = Rhoedia.LoseHealth(5);

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
                            if (Intelligence >= 8)
                            {
                                Health = Player.DrinkVial(Name, 15);
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
                    Rhoedia.Attack(Name, Defense);
                    ReadKey();
                    Health = Player.LoseHealth(Name, attackPower, Defense);
                }
                if (Health <= 0)
                    Restart();

            } while (Health != 0 || Health > 0);

        }

        public void Game(int[] order)
        {
            foreach (int i in order)
            {
                if (i == 1 || i == 3 || i == 4 || i == 5 || i == 6)//choices
                {
                    Selection(i);
                    Clear();

                }
                else if (i == 7)//fight scene
                {
                    WriteLine($@"



                                   Upon entering the sea palace, you find another chest along with the 2nd Archaic Stone. 

                              To obtain these, however, you must first defeat the Sea Dragon guarding the chest and the stone. 
    
                                        The Sea Dragon looks at you with eyes that are full of intent to defeat you.
");
                    ReadKey();
                    Clear();
                    Fight();
                    Clear();

                }
                else if (i == 8)//ending
                {
                    string finalNarration = ($@"



                                                                Congratulations! 

             With this, you have defeated the Sea Dragon, cleared the second dungeon, and obtained both the chest and 2nd Archaic Stone. 
                                                        
                                                             Do you wish to Continue?


");
                    string[] exitOptions = { "1 = Exit and Save", "2 = Continue to the next Dungeon" };
                    Game_File gameFile = new Game_File();
                    gameFile.UpdateLevel(Name, 3);
                    Menu exitandSave = new Menu(exitOptions, finalNarration);
                    int answer = exitandSave.RunOptions();
                    if (answer == 0)
                    {
                        WriteLine("Game progress saved! Press any key to return to Main Menu...");
                        ReadKey();
                        Clear();
                        Game game = new Game();
                        game.Opening();
                    }
                    else
                    {
                        WriteLine(@"
            Press any key to proceed to the next dungeon: The Astaroth Dungeon");
                        ReadKey();
                        Clear();

                        Astaroth astaroth = new Astaroth(Player);
                        astaroth.Narration();
                    }
                }
                else//normal narrations
                {
                    if (i == 0)
                    {
                        WriteLine($@"



                                                   You found the entrance to the Vinea Dungeon. 

                                    Upon entering the dungeon, you begin your search for the 2nd Archaic Stone.


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
                    {
                        WriteLine($@"



            After going through the path leading downward, you see a fountain that resembles the one you first saw at the Focalor Dungeon.

");
                    }

                    ReadKey();
                    Clear();

                }
            }
        }
    }
}
