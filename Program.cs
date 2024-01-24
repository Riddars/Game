using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
namespace ConsoleApp1
{
    // Интерфейс для бойцов
    public interface IWarrior
    {
        string Name { get; set; }
        double Health { get; set; }
        double Attack();
        double Block();
    }

    // Класс Воин, реализующий интерфейс IWarrior
    public class Warrior : IWarrior
    {
        public string Name { get; set; }
        public double Health { get; set; }
        public double AttackMax { get; set; }
        public double BlockMax { get; set; }
        private readonly Random _random;

        public Warrior(string name, double health, double attackMax, double blockMax)
        {
            Name = name;
            Health = health;
            AttackMax = attackMax;
            BlockMax = blockMax;
            _random = new Random();
        }

        public double Attack()
        {
            return _random.Next(1, (int)AttackMax);
        }

        public double Block()
        {
            return _random.Next(1, (int)BlockMax);
        }
    }

    // Класс Бой
    public class Battle
    {
        public static void StartFight(IWarrior warrior1, IWarrior warrior2)
        {
            while (true)
            {
                if (GetAttackResult(warrior1, warrior2) == "Game Over")
                {
                    Console.WriteLine("Game Over");
                    break;
                }

                if (GetAttackResult(warrior2, warrior1) == "Game Over")
                {
                    Console.WriteLine("Game Over");
                    break;
                }
            }
        }

        private static string GetAttackResult(IWarrior warriorA, IWarrior warriorB)
        {
            double warAAttkAmt = warriorA.Attack();
            double warBBlkAmt = warriorB.Block();

            double damageToWarB = warAAttkAmt - warBBlkAmt;

            if (damageToWarB > 0)
            {
                warriorB.Health -= damageToWarB;
                Console.WriteLine("{0} attacks {1} and deals {2} damage", warriorA.Name, warriorB.Name, damageToWarB);
                Console.WriteLine("Blocked Amount: {0}", warBBlkAmt);
                Console.WriteLine("{0} has {1} health\n", warriorB.Name, warriorB.Health);
            }
            else
            {
                Console.WriteLine("{0} unsuccessfully attacks {1}", warriorA.Name, warriorB.Name);
                Console.WriteLine("Damage was blocked");
                Console.WriteLine("{0} has {1} health\n", warriorB.Name, warriorB.Health);
            }

            if (warriorB.Health <= 0)
            {
                Console.WriteLine("{0} was killed. {1} wins\n", warriorB.Name, warriorA.Name);
                return "Game Over";
            }
            else
            {
                return "Fight Again";
            }
        }
    }

    // Класс для вывода сообщения "START GAME"
    public class GameStartMessage
    {
        public static void ShowStartMessage()
        {
            char[] array = { 'S', 'T', 'A', 'R', 'T', ' ', 'G', 'A', 'M', 'E' };
            foreach (var a in array)
            {
                Console.Write(a);
                Thread.Sleep(250);
            }
            Console.WriteLine();
        }
    }

    // Класс Программа для запуска приложения
    class Program
    {
        static void Main(string[] args)
        {
            GameStartMessage.ShowStartMessage();
            IWarrior hero = new Warrior("Геральд", 1000, 100, 50);
            IWarrior monster = new Warrior("Рошан", 700, 130, 70);

            Battle.StartFight(hero, monster);

            Console.ReadLine();
        }
    }
}
