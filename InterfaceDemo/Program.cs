using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    // An interface is a contract
    // Classes implement interfaces

    class Program
    {
        static void Main(string[] args)
        {

            List<IComputerController> controllers = new List<IComputerController>();

            Keyboard keyboard = new Keyboard();
            GameController gameController = new GameController();
            BatteryPowerGameController battery = new BatteryPowerGameController();
            BatteryPowerKeyboard batterykeyboard = new BatteryPowerKeyboard();

            controllers.Add(keyboard);
            controllers.Add(gameController);

            foreach (IComputerController controller in controllers)
            {
                if (controller is GameController gc)
                {
                    
                }

                if (controller is IBatteryPowered powered)
                {

                }
            }
            //using IDisposable - dispose (power of interfaces) 
            using (GameController gc = new GameController())
            {

            }

            List<IBatteryPowered> powereds = new List<IBatteryPowered>();

            powereds.Add(battery);
            powereds.Add(batterykeyboard);

            Console.ReadLine();
        }
    }

    public interface IComputerController : IDisposable
    {
        void Connect();
        void CurrentKeyPressed();
    }


        public class Keyboard : IComputerController
    {
        public void Connect()
        {

        }

        public void CurrentKeyPressed()
        {

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public string ConnectionType { get; set; }

    }

    public class GameController : IComputerController, IDisposable
    {
        public void Connect()
        {
            throw new NotImplementedException();
        }

        public void CurrentKeyPressed()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //do whatever shutdown tasks needed
        }

        public int BatteryLevel { get; set; }

    }

    public interface IBatteryPowered
    {
        int BatteryLevel { get; set; }
    }

    public class BatteryPowerKeyboard : Keyboard, IBatteryPowered
    {
        public int BatteryLevel { get; set; }
    }

    public class BatteryPowerGameController : GameController, IBatteryPowered
    {
        public int BatteryLevel { get; set; }
    }
}