using System;
using System.Collections.Generic;

namespace TheEasyGame
{
    public class Hero                                //Непонятно: как сделать его статическим(потому что герой всегда один) и при этом не потерять поля
    {
        public int Health { get; private set; } = 100;
        public int Score { get; private set; } = 0;

        public int X { get; private set; }
        public int Y { get; private set; }

        public Hero(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Move(Map map)
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.LeftArrow:
                    map.MainMap[X, Y] = Map.Empty;
                    map.MainMap[X - 1, Y] = Map.Hero;
                    break;
                case ConsoleKey.RightArrow:
                    map.MainMap[X, Y] = Map.Empty;
                    map.MainMap[X + 1, Y] = Map.Hero;
                    break;
            }
        }
    }

    public class Enemy
    {
        public int Health { get; private set; } = 100;

        public int X { get; private set; }
        public int Y { get; private set; }

        public Enemy(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    class Program
    {
        public static void Main()
        {
            var hero = new Hero(5, 5);
            var map = new Map();
            while (true)
            {
                hero.Move(map);
                map.Update();
            }
         
        }
    }

    public class Map
    {
        private readonly string[] map = new string[] { "********************",
                                                       "*                  *",
                                                       "*                  *",
                                                       "*                  *",
                                                       "*                  *",
                                                       "*                  *",
                                                       "*                  *",
                                                       "*                  *",
                                                       "*                  *",
                                                       "*                  *",
                                                       "*                  *",
                                                       "*                  *",
                                                       "*                  *",
                                                       "********************"};
        public string[, ] MainMap { get; set; }
        public Map()
        {
            for (var y = 0; y < map.Length; y++)
            {
                for (var x = 0; x < map[0].Length; x++)
                {
                    switch (map[y][x])
                    {
                        case '#':
                            MainMap[x, y] = Map.Stairs;
                            break;
                        case 'H':
                            MainMap[x, y] = Map.Hero;
                            break;
                        case '*':
                            MainMap[x, y] = Map.Wall;
                            break;
                        case 'E':
                            MainMap[x, y] = Map.Enemy;
                            break;
                        case '?':
                            MainMap[x, y] = Map.Bonus;
                            break;
                        case ' ':
                            MainMap[x, y] = Map.Empty;
                            break;
                    }
                }
            }
        }

        public const string Hero = "H";
        public const string Wall = "*";
        public const string Empty = " ";
        public const string Bonus = "?";
        public const string Enemy = "E";
        public const string Stairs = "#";

        public void Update()
        {
            foreach (var e in MainMap)
                Console.WriteLine(e);
        }
    }
}
