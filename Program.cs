using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
namespace ConsoleApp1
{
    class Warrior
    {
        // Определение свойсств воина
        public string Name { get; set; } = "Воин";
        public double Health { get; set; } = 0;
        public double AttkMax { get; set; } = 0;
        public double BlockMax { get; set; } = 0;

        Random rnd = new Random();

        // Конструктор инициализирует воина
        public Warrior(string name = "Воин", double health = 0, double attkMax = 0, double blockMax = 0)
        {
            Name = name;
            Health = health;
            AttkMax = attkMax;
            BlockMax = blockMax;
        }

        public double Attack()
        {
            return rnd.Next(1, (int)AttkMax); // рандомное число от 1 до AttkMax
        }

        // Генерировать случайное значение блока из
        // 1 к воинам максимальный блок
        public double Block()
        {
            return rnd.Next(1, (int)BlockMax); // рандомное число от 1 до AttkMax
        }
    }

    class Battle
    {
        // Это служебный класс, поэтому это имеет смысл
        // иметь только статические методы

        // Получить оба объекта Warrior
        public static void StartFight(Warrior warrior1, Warrior warrior2)
        {
            // процесс атаки
            while (true)
            {
                if (GetAttackResult(warrior1, warrior2) == "Игра окончена")
                {
                    Console.WriteLine("Игра окончена");
                    break;
                }

                if (GetAttackResult(warrior2, warrior1) == "Игра окончена")
                {
                    Console.WriteLine("Игра окончена");
                    break;
                }
            }
        }

        // Принять 2 Воина
        public static string GetAttackResult(Warrior warriorA, Warrior warriorB)
        {
            // Рассчитайте, что один воин атакует, а остальные блокируют

            double warAAttkAmt = warriorA.Attack();
            double warBBlkAmt = warriorB.Block();

            // Вычитание блока из атаки
            double dmg2WarB = warAAttkAmt - warBBlkAmt;

            // Если был нанесен ущерб, вычтите его из здоровья
            if (dmg2WarB > 0)
            {
                warriorB.Health = warriorB.Health - dmg2WarB;
                Console.WriteLine("{0} атакует {1} и наносит {2} из {3} урона", warriorA.Name, warriorB.Name, dmg2WarB, warAAttkAmt);
                Console.WriteLine("Урона было заблокировано: {0}", warBBlkAmt);
                Console.WriteLine("{0} имеет {1} здоровья\n", warriorB.Name, warriorB.Health);
                if (warriorA.Name == "Геральд")
                {
                    Move.choise(warriorA);
                }
                    
            }
            else
            {
                dmg2WarB = 0;
                Console.WriteLine("{0} безуспешно атаковал {1}", warriorA.Name, warriorB.Name);
                Console.WriteLine("Урон был заблокирован");
                Console.WriteLine("{0} имеет {1} здоровья\n", warriorB.Name, warriorB.Health);
            }

            if (warriorB.Health <= 0)
            {
                Console.WriteLine("{0} был убил. {1} - победитель\n", warriorB.Name, warriorA.Name);

                return "Игра окончена";
            }
            else return "Сражайся снова";
        }

    }


    class Move
    {
        public static void choise(Warrior warriorA)
        {
            Console.WriteLine("1 - Продолжать атаковать");
            Console.WriteLine("2 - Исцеление (+50)");
            Console.WriteLine("3 - Сдаться");
            string a = Console.ReadLine();
            if (a == "1")
            {
                Console.WriteLine();
            }
            if (a == "2" & warriorA.Name == "Геральд")
            {
                warriorA.Health = warriorA.Health + 50;
            }
            if (a == "3" & warriorA.Name == "Геральд")
            {
                warriorA.Health = warriorA.Health - warriorA.Health;
            }
        }
    }

   
    class Program
    {
        public static void StartGame()
        {
            char[] array = {'S', 'T', 'A', 'R', 'T', ' ', 'G', 'A', 'M', 'E' };
            foreach (var a in array)
            {
                Console.Write(a);
                System.Threading.Thread.Sleep(250);
            }
            Console.WriteLine();
        }   // УРОВЕНЬ 
        static void Main(string[] args)
        {
            StartGame();
            Warrior Hero = new Warrior("Геральд", 1000, 100, 50);
            Warrior Monster = new Warrior("Рошан", 700, 130, 70);

            Battle.StartFight(Hero, Monster);

            Console.ReadLine();

        }

    }


}
