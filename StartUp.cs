using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carData[0];
                int engineSpeed = int.Parse(carData[1]);
                int enginePower = int.Parse(carData[2]);
                int cargoWeight = int.Parse(carData[3]);
                string cargoType = carData[4];
                double tirePr1 = double.Parse(carData[5]);
                int tireAge1 = int.Parse(carData[6]);
                double tirePr2 = double.Parse(carData[7]);
                int tireAge2 = int.Parse(carData[8]);
                double tirePr3 = double.Parse(carData[9]);
                int tireAge3 = int.Parse(carData[10]);
                double tirePr4 = double.Parse(carData[11]);
                int tireAge4 = int.Parse(carData[12]);

                //Engine, Tire., Cargo

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Tire[] tires = new Tire[]
                {
                    new Tire(tirePr1, tireAge1),
                    new Tire(tirePr2, tireAge2),
                    new Tire(tirePr3, tireAge3),
                    new Tire(tirePr4, tireAge4)
                };

                Car car = new Car(model, engine, cargo, tires); //created object Car ! 
                cars.Add(car);
            }

            string command = Console.ReadLine();

            foreach (var car in cars)
            {
                if (command == "fragile")
                {
                    if (car.Cargo.CargoType == "fragile" && car.Tires.Any(t => t.TirePressure < 1))
                    {
                        Console.WriteLine($"{car.Model}");
                    }
                }               
                else if (command == "flamable")
                {
                    if (car.Cargo.CargoType == "flamable" && car.Engine.EnginePower > 250)
                    {
                        Console.WriteLine($"{car.Model}");
                    }
                }
            }
        }
    }
}
