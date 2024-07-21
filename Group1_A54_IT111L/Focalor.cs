using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;

namespace Group1_A54_IT111L
{
    class Focalor
    {

        private readonly Enemy Andrius;
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

        public string enemyName = "Andrius";
        public int enemyHealth = 30;
        public int attackPower = 10;
        public string enemyType = "Storm Wolf";
        public string TextArt = ImageCharacters.Wolf;

        public bool choice = false;

        public Focalor(Player player)
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
            Player = new Player(Level, Name, Weapon, Character, Health, Strength, Defense, Intelligence, Vials);
            gameFile = new Game_File();
            Andrius = new Enemy(enemyName, enemyType, enemyHealth, attackPower,TextArt);
        }

        public void Narration()
        {
            int[] order = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Game(order);
        }

        public void Selection(int order)
        {

            string[] optionListFile = File.ReadLines("FocalorSelection.txt").ToArray();
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

            else if (order == 2)
            {
                string question = $@"
            

                
            After going through the Windward path, you see a fountain that resembles the one you saw during your previous research. 
        
                    It was said that a fountain exists in each dungeon which gives you vials that could heal yourself, 
            as well as inflict damage to the enemies of the dungeon.

                                       How many vials do you wish to use to get from the Focalor fountain?
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

            else if (order == 3)
            {
                do
                {
                    try
                    {
                        string question = $@"



            Upon continuing walking, you stumbled upon 2 doors: a red and a brown door. 


                                                               Which door will you choose?

                Hint: It is the weakness of the wind.
";

                        string[] option = optionListFile[1].Split('/');
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
                        OtherResult2();
                    }
                } while (choice);
                CorrectResult1();
            }

            else if (order == 4)
            {
                do
                {
                    try
                    {
                        string question = $@"



                You entered the red door and walked downward only to find your path blocked by a strong hurricane.

            You notice that this is due to the Eye of the Storm that is spinning, manipulating the control of the wind of your path.


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
                            ReadKey();
                        }
                    }
                    catch (Selection1)
                    {
                        choice = true;
                        OtherResult3();
                    }
                } while (choice);
                CorrectResult1();
            }

            else if (order == 8)
            {
                do
                {
                    try
                    {

                        string question = $@"



                Upon entering the door, you found a chest in the center of the room along with the 1st Archaic Stone. 
        
            To obtain the following, you must answer the following question first.

                                                    Which of the following was not obtained inside this dungeon?
";

                        string[] option = optionListFile[3].Split('/');
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
                            ReadKey();
                        }
                    }
                    catch (Selection0)
                    {
                        choice = true;
                        OtherResult4();
                    }
                    catch (Selection1)
                    {
                        choice = true;
                        OtherResult4();
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


            You found that there are wolves. The wolves noticed you and attacked. Health has decreased by 5.

");

            Health = Player.NormalSelectionLoseHealth(Name, damage);
            if (Health <= damage)
                Restart();

            else
                WriteLine($@"

                    {Name}’s health: - {damage}");

            WriteLine($@"


                   Current Health of {Name}: {Health}

                Hint: You can’t see me but sometimes you hear me and in a hurricane, some people fear me. "
    );
            ReadKey();

        }

        public void OtherResult2()
        {
            int damage = 5;

            WriteLine($@"


            After entering the door, you got hit by small rocks. Health has decreased by 5.
        
");

            Health = Player.NormalSelectionLoseHealth(Name, damage);
            if (Health <= damage)
                Restart();
            else
                WriteLine($@"

                    {Name}’s health: - {damage}");

            WriteLine($@"

                   Current Health of {Name}: {Health}
                
                Hint: Wind is strong against earth, weak to fire and electricity.
");
            ReadKey();
        }

        public void OtherResult3()
        {
            int damage = 10;

            WriteLine($@"


            {Name} yeeted and charged towards the storm and got damaged. Health has decreased by 10.

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
        public void OtherResult4()
        {
            int damage = 5;

            WriteLine($@"
        

            Wrong answer. 
");
           
            Health = Player.NormalSelectionLoseHealth(Name, damage);
            if (Health <= damage)
                Restart();
            else
                WriteLine($@"

                    {Name}’s health: - {damage}");

            WriteLine($@"

    
            Please try again.
    
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

        public void Fight()
        {
            Andrius.DisplayInfo();
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
                    enemyHealth = Andrius.LoseHealth(Strength);
                }
                else if (selectedChoice == 1)
                {

                    string[] vialoptions = { "1 = Throw Vial", "2 = Drink Vial" };
                    Menu vialMenu = new Menu(vialoptions, "What will you do with the Vial?");
                    int vialAction = vialMenu.RunOptions();
                    if (vialAction == 0)
                    {
                        if (Vials > 0)
                        {
                            if (Intelligence >= 8)
                            {
                                Vials = Player.ThrowVial(Andrius.Name, Player.Name, 15);
                                enemyHealth = Andrius.LoseHealth(15);

                            }
                            else if (Intelligence > 4 && Intelligence <= 7)
                            {
                                Vials = Player.ThrowVial(Andrius.Name, Player.Name, 10);
                                enemyHealth = Andrius.LoseHealth(10);

                            }
                            else if (Intelligence < 4)
                            {
                                Vials = Player.ThrowVial(Andrius.Name, Player.Name, 5);
                                enemyHealth = Andrius.LoseHealth(5);

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
                    Andrius.Attack(Name, Defense);
                    ReadKey();
                    Health = Player.LoseHealth(Name, attackPower, Defense);
                }
                if (Health <= 0)
                    Restart();

            } while (Health != 0 || Health > 0);

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

        public void Game(int[] order)
        {
            foreach (int i in order)
            {
                if (i == 1 || i == 2 || i == 3 || i == 4 || i == 8)//choices
                {
                    Selection(i);
                    Clear();
                }
                else if (i == 6)//fight scene
                {
                    WriteLine($@"



                                        Your path ends in an abandoned arena that is surrounded by a cold mist. 

                                          You stare at your surroundings for a while and noticed a huge door.  

                                   To your surprise, a wolf emerges from this door and positions himself for combat.

");
                    ReadKey();
                    Clear();
                    Fight();
                    Clear();
                }
                else if (i == 9)//ending
                {
                    string finalNarration = $@"



                                                                Congratulations! 

                            With this, you have cleared the first dungeon and obtained both the chest and 1st Archaic Stone. 
                                                        
                                                             Do you wish to Continue?


";

                    string[] exitOptions = { "1 = Exit and Save", "2 = Continue to the next Dungeon" };
                    Game_File gameFile = new Game_File();
                    gameFile.UpdateLevel(Name, 2);
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



            Press any key to proceed to the next dungeon: The Vinea Dungeon"
);
                        ReadKey();
                        Clear();
                        Vinea vinea = new Vinea(Player);
                        vinea.Narration();
                    }

                }
                else//normal narrations
                {
                    if (i == order[0])
                    {
                        WriteLine($@"



                                                  You found the entrance to the Focalor Dungeon. 

                                     Upon entering the dungeon, you begin your search for the 1st Archaic Stone.


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
                    else if (i == 5)
                    {
                        WriteLine($@"



                    The Eye of the Storm stops spinning, drops to the ground, and dissipates. 
            
            The mana of the wind seems to have died down. 

            With the strong hurricane gone, you’re now able to proceed on walking through your path.


");

                    }
                    else if (i == 7)
                    {
                        WriteLine($@"



                                                               Congratulations!

                                                          The wolf has been defeated! 

                       As a reward, you have obtained The Locket of the Wolf. Use this locket to proceed towards the door.

");
                    }
                    ReadKey();
                    Clear();
                }
            }
        }
    }

    public class Selection0 : Exception { }
    public class Selection1 : Exception { }
    public class Selection2 : Exception { }
    public class Selection3 : Exception { }
}

