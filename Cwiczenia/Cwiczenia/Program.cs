using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwiczenia
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car(1995,"BMW");
            Bicycle bic1 = new Bicycle();
            Skateboard skate1 = new Skateboard();

            car1.Ride();
            bic1.Ride();
            //bic1.PlayMelody();
            skate1.Ride();

            List<Car> cars = new List<Car>();
            cars.Add(new Car(2010, "Ford"));
            cars.Add(new Car(2016, "Fiat"));
            cars.Add(new Car(2012, "Skoda"));
            cars.Add(new Car(2010, "BMW"));
            Console.WriteLine("\n");

            foreach (Car i in cars)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("\n");

            cars.Sort();

            foreach (Car i in cars)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}
