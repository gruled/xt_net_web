using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Program
    {
        private static Map _map;

        static void Main(string[] args)
        {
            Init();
            Start();
        }

        private static void Init()
        {
            _map = new Map(10.0f, 10.0f);
            _map.DinamicList= new List<DinamicGameObject>();
            _map.BonusList= new List<Bonus>();
            _map.ObstacleList = new List<Obstacle>();
            for (int i = 0; i < 10; i++)
            {
                _map.DinamicList.Add(new Enemy(new Vector2(1.0, 1.5), "Bear", 1));
                _map.DinamicList.Add(new Enemy(new Vector2(2.0, 3.5), "Wolf", 2));
                _map.DinamicList.Add(new Player(new Vector2(2.5, 3.4), "Hero", 3));
                _map.BonusList.Add(new Bonus(new Vector2(1.3, 2.5), "Apple", 1));
                _map.BonusList.Add(new Bonus(new Vector2(2.9, 5.4), "Cherry", 1));
                _map.ObstacleList.Add(new Obstacle(new Vector2(3.3, 4.4), "Tree"));
            }
        }

        private static void Start()
        {
            while (true)
            {
                foreach (var variable in _map.DinamicList)
                {
                    variable.Move();
                }
            }
        }
    }
}
