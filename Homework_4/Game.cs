using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4
{
    public delegate void EndGameEventHandler(object sender, EndGameEventArgs e);
    public class Game
    {
        public static int Finish { get; } = 1000;
        private static List<Car> _cars;
        public static List<Car> Cars => _cars;
        public static bool GameIsOn { get; private set; } = true;
        public static event EndGameEventHandler GameEnded;

        public Game()
        {
            _cars=new List<Car>();
            Random rnd = new Random(DateTime.Now.Millisecond);
            int numberOfCars = rnd.Next(2, 10);
            Console.WriteLine($"{numberOfCars} cars take part in race!");
            Console.WriteLine("The participants are:");
            for (int i = 1; i <= numberOfCars; i++)
            {
                Car car;
                int carType = rnd.Next(4);
                switch (carType)
                {
                    case 0:
                        car=new CasualCar($"CasualCar_{IdHelper.GetNextId()}");
                        break;
                    case 1:
                        car = new RacingCar($"RacingCar_{IdHelper.GetNextId()}");
                        break;
                    case 2:
                        car = new Truck($"Truck_{IdHelper.GetNextId()}");
                        break;
                    default:
                        car = new Bus($"Bus_{IdHelper.GetNextId()}");
                        break;
                }

                Console.WriteLine($"{car.Name}");
                _cars.Add(car);
            }

            GameEnded += EndGame;
        }

        public static void CallEvent(object sender, EndGameEventArgs e)
        {
            GameEnded?.Invoke(sender, e);
        }
        private static void EndGame(object sender, EndGameEventArgs e)
        {
            GameIsOn = false;
            Console.WriteLine($"Car {e.Winner} has won the race!!!");
        }
    }
}
