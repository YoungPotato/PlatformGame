using System;
using System.Collections.Generic;
using System.Drawing;

namespace TheEasyGame
{
    public class Map
    {
        public readonly MapCell[,] Level;
        public readonly List<Enemy> Enemyes;
        public readonly List<Point> Bonus; 

        private Map(MapCell[,] map, List<Enemy> enemyes, List<Point> bonus)
        {
            Level = map;
            Enemyes = enemyes;
            Bonus = bonus;
        }

        public static Map CreateMap(string[] textMap)
        {
            var map = new MapCell[textMap[0].Length, textMap.Length];
            var enemyes = new List<Enemy>();
            var bonus = new List<Point>();
            for (var y = 0; y < map.Length; y++)
            {
                for (var x = 0; x < textMap[0].Length; x++)
                {
                    switch (textMap[y][x])
                    {
                        case '#':
                            map[x, y] = MapCell.Stairs;
                            break;
                        case 'H':
                            map[x, y] = MapCell.Hero;
                            break;
                        case '*':
                            map[x, y] = MapCell.Wall;
                            break;
                        case 'E':
                            map[x, y] = MapCell.Enemy;
                            enemyes.Add(new Enemy(x, y));
                            break;
                        case '?':
                            map[x, y] = MapCell.Bonus;
                            bonus.Add(new Point(x, y));
                            break;
                        case ' ':
                            map[x, y] = MapCell.Empty;
                            break;
                    }
                }
            }
            return new Map(map, enemyes, bonus);
        }

        public static Map FromText(string text)
        {
            var map = text.Split(new[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            return CreateMap(map);
        }
    }
}
