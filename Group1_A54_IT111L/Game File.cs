using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;

namespace Group1_A54_IT111L
{
    class Game_File
    {
        public void Save(string playerData)
        {

            if (File.Exists("Game.txt"))
            {
                
                if (new FileInfo("Game.txt").Length == 0)
                {
                    StreamWriter gameWriter = new StreamWriter("Game.txt");
                    gameWriter.WriteLine(playerData);
                    gameWriter.Close();
                }
                
                else
                {
                    using (StreamWriter gameWriter = new StreamWriter("Game.txt", append:true))
                    {
                        gameWriter.WriteLine(playerData);
                        gameWriter.Close();
                    }
                }
            }
            
            else
            {
                StreamWriter gameWriter = new StreamWriter("Game.txt");
                gameWriter.WriteLine(playerData);
                gameWriter.Close();
            }
        }

        public void UpdateHealth(string playerName, int health)
        {
            string[] record = File.ReadLines("Game.txt").ToArray();

            int count = File.ReadLines("Game.Txt").Count();

            for (int i=0;i<count;i++)
            {
                string[] recordContent = record[i].Split('/');
                if (recordContent[1]==playerName)
                {
                    recordContent[2] = health.ToString();
                }
                record[i] = string.Join("/", recordContent);
            }

            StreamWriter userWriter = new StreamWriter("Game.txt");
            foreach (string i in record)
            {
                userWriter.WriteLine(i);
            }
            userWriter.Close();
        }

        public void UpdateStrength(string playerName, int strength)
        {
            string[] record = File.ReadLines("Game.txt").ToArray();

            int count = File.ReadLines("Game.Txt").Count();

            for (int i = 0; i < count; i++)
            {
                string[] recordContent = record[i].Split('/');
                if (recordContent[1] == playerName)
                {
                    recordContent[5] = strength.ToString();
                }
                record[i] = string.Join("/", recordContent);
            }

            StreamWriter userWriter = new StreamWriter("Game.txt");
            foreach (string i in record)
            {
                userWriter.WriteLine(i);
            }
            userWriter.Close();
        }

        public void UpdateDefense(string playerName, int defense)
        {
            string[] record = File.ReadLines("Game.txt").ToArray();

            int count = File.ReadLines("Game.Txt").Count();

            for (int i = 0; i < count; i++)
            {
                string[] recordContent = record[i].Split('/');
                if (recordContent[1] == playerName)
                {
                    recordContent[6] = defense.ToString();
                }
                record[i] = string.Join("/", recordContent);
            }

            StreamWriter userWriter = new StreamWriter("Game.txt");
            foreach (string i in record)
            {
                userWriter.WriteLine(i);
            }
            userWriter.Close();

        }

        public void UpdateVials(string playerName, int vials)
        {
            string[] record = File.ReadLines("Game.txt").ToArray();

            for (int i = 0; i < record.Length; i++)
            {
                string[] recordContent = record[i].Split('/');
                if (recordContent[1] == playerName)
                {
                    recordContent[8] = vials.ToString();
                    record[i] = string.Join("/", recordContent);
                    break;
                }
                
            }

            StreamWriter userWriter = new StreamWriter("Game.txt");
            foreach (string i in record)
            {
                userWriter.WriteLine(i);
            }
            userWriter.Close();
        }

        public void UpdateIntelligence(string playerName, int intel)
        {
            string[] record = File.ReadLines("Game.txt").ToArray();

            int count = File.ReadLines("Game.Txt").Count();

            for (int i = 0; i < count; i++)
            {
                string[] recordContent = record[i].Split('/');
                if (recordContent[1] == playerName)
                {
                    recordContent[7] = intel.ToString();
                    record[i] = string.Join("/", recordContent);
                }             
            }

            StreamWriter userWriter = new StreamWriter("Game.txt");
            foreach (string i in record)
            {
                userWriter.WriteLine(i);
            }
            userWriter.Close();
        }

        public void UpdateLevel(string playerName, int level)
        {
            string[] record = File.ReadLines("Game.txt").ToArray();

            int count = File.ReadLines("Game.Txt").Count();

            for (int i = 0; i < count; i++)
            {
                string[] recordContent = record[i].Split('/');
                if (recordContent[1] == playerName)
                {
                    recordContent[0] = level.ToString();
                }
                record[i] = string.Join("/", recordContent);
            }

            StreamWriter userWriter = new StreamWriter("Game.txt");
            foreach (string i in record)
            {
                userWriter.WriteLine(i);
            }
            userWriter.Close();
        }
    }
}
