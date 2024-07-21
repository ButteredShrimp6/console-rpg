using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;

namespace Group1_A54_IT111L
{
    class Enemy 
    {
        public string Name;
        public int Health;
        public int attackPower;
        public string enemyType;
        public string TextArt;

        public Enemy(string name, string type,  int health, int attackDMG, string textart) 
        {
            Name = name;
            Health = health;
            attackPower = attackDMG;
            enemyType = type;
            TextArt = textart;

        }

        public void DisplayInfo()
        {
            WriteLine($@"
    {Name}
");
            WriteLine($@"
    Type: {enemyType}
");
            WriteLine($@"
    Attack power: {attackPower}
");
            WriteLine($@"
    Health: {Health}
");
            WriteLine($"{TextArt}");
            ReadKey();

        }

        public void Attack(string playerName, int defense)
        {
            int totaldamage = 0;
            if (defense > attackPower)
            {
                totaldamage = 0;
            }
            else
            {
                totaldamage = attackPower - defense;
            }
            WriteLine($"{Name} attacked!");
            WriteLine($"{Name} dealt {totaldamage} damage to {playerName}.");
        }

        public int LoseHealth(int damage)
        {
            Health -= damage;
            WriteLine($@"
    Current Health of {Name}: {Health}

");
            return Health;
        }
    }
}
