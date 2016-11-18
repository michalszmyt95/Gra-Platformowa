using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwiczenia
{
    class Car :IRideable, IComparable<Car>
    {
        int year;
        string brand;

        public Car(int newYear, string newBrand)
        {
            this.year = newYear;
            this.brand = newBrand;
        }

        public void Ride()
        {
            Console.WriteLine("Jadę samochodem.");
        }

        public int CompareTo(Car other)
        {
            // Jesli rok jest taki sam, sortuj po nazwie. [A do Z (bez uzycia minusa)]
            if (this.year == other.year)
            {
                return this.brand.CompareTo(other.brand);
            }
            // Domyslne sortowanie po dacie. [nizszy numer do wyzszego: uzycie minusa]
            return -other.year.CompareTo(this.year);
        }

        public override string ToString()
        {
            return this.year.ToString() + ", " + this.brand;
        }
    }
}
