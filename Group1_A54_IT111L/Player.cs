using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;

namespace Group1_A54_IT111L
{
    class Player
    {
        public int Level;
        public string Name;
        public string Character;
        public string Weapon;
        public int Health;
        public int Strength;
        public int Defense;
        public int Intelligence;
        public int WaterVials;

        private readonly Game_File File;

        public Player(int level, string name, string weapon, string characterSelected, int health, int strength, int defense, int intelligence, int waterVials)
        {
            Level = level;
            Name = name;
            Health = health;
            Character = characterSelected;
            Weapon = weapon;
            Strength = strength;
            Defense = defense;
            Intelligence = intelligence;
            WaterVials = waterVials;
            File = new Game_File();
        }

        public void DisplayInfo()
        {
            WriteLine($@"
            _____  _      ____ __  __ ____ _____     _  __  _  ____  ____ 
            | ()_)| |__  / () \\ \/ /| ===|| () )   | ||  \| || ===|/ () \
            |_|   |____|/__/\__\|__| |____||_|\_\   |_||_|\__||__|  \____/
                
                Character: 
                                {GetImageCharacter()}   
            Name: {Name}        Health: {Health}          
            Occupation: {Character}
            Weapon: {Weapon}
            Vials: {WaterVials}

            ==== Basic Stats ====
            Strength: {Strength}
            Defense: {Defense}
            Intelligence: {Intelligence}
            ");


        }

        public string GetImageCharacter()
        {
            if (Weapon == "Sword")

                return ImageCharacters.Sword;
            else if (Weapon == "Lance")
                return ImageCharacters.Lance;
            else if (Weapon == "Axe")
                return ImageCharacters.Axe;
            return "";
        }

        public void Save()
        {
            string gameData;

            gameData = Level + "/" + Name + "/" + Health + "/" + Character + "/" + Weapon + "/" + Strength + "/" + Defense + "/" + Intelligence + "/" + WaterVials;

            File.Save(gameData);
        }

        public int NormalSelectionLoseHealth(string playerName, int damage)
        {
            Health -= damage;

            File.UpdateHealth(playerName, Health);
            return Health;
        }

        public int LoseHealth(string playerName, int damage, int defense)
        {
            int totaldamage;

            if (defense > damage)
            {
                totaldamage = 0;
            }
            else
            {
                totaldamage = damage-defense;
               
            }

            Health -= totaldamage;
        
        
            File.UpdateHealth(playerName, Health);

            if (Health > 0)
            {
                WriteLine($@"
    Current Health of {Name}: {Health}

");
            }
            else
            {
                WriteLine($@"
    Current Health of {Name}: 0

");
            }

            ReadKey();
            return Health;
        }

        public int GainIntelligence(string playerName, int upgrade)
        {
            Intelligence += upgrade;

            File.UpdateIntelligence(playerName, Intelligence);

            WriteLine($@"
    Current Intelligence: {Intelligence}

");
            ReadKey();
            return Intelligence;
        }

        public int GainStrength(string playerName, int upgrade)
        {
            Strength += upgrade;

            File.UpdateStrength(playerName, Strength);

            WriteLine($@"
    Current strength: {Strength}

");
            ReadKey();
            return Strength;
        }

        public int GainDefense(string playerName, int upgrade)
        {
            Defense += upgrade;

            File.UpdateDefense(playerName, Defense);

            WriteLine($@"
    Current defense: {Defense}

");
            ReadKey();
            return Defense;
        }

        public int ThrowVial(string enemyName, string playerName, int vialDamage)
        {
            
            WriteLine($"{Name} threw a Vial!");
            WriteLine($"{Name} dealt {vialDamage} damage to {enemyName}.");
            
            WaterVials -= 1;
            File.UpdateVials(playerName, WaterVials);

            ReadKey();

            return WaterVials;
        }

        public int StoreVials(string playerName, int numofVials)
        {
            WaterVials += numofVials;
            File.UpdateVials(playerName, WaterVials);
            return WaterVials;
        }

        public int DrinkVial(string playerName, int vialRegen)
        {
            if (Health + vialRegen > 100)
            {
                Health = 100;
                File.UpdateHealth(playerName, Health);
                File.UpdateVials(playerName, WaterVials);
                WriteLine($@"
    {Name}’s health: + {vialRegen}

");
                WriteLine($@"
    Current Health of {Name}: {Health}

"); 
            }
            else
            {
                Health += vialRegen;
                WaterVials -= 1;
                File.UpdateHealth(playerName, Health);
                File.UpdateVials(playerName, WaterVials);
                WriteLine($@"
    {Name}’s health: + {vialRegen}

");
                WriteLine($@"
    Current Health of {Name}: {Health}

");
            }

            ReadKey();

            return Health;
        }

        public void Attack(string enemyName, int damage)
        {
            WriteLine($"{Name} attacked!");
            WriteLine($"{Name} dealt {damage} damage to {enemyName}.");
        }
    }
}
