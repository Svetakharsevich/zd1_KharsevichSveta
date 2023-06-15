using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_1_cat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cat murzik = new Cat("Мурзик");
            Cat barsik = new Cat("Барсик");
            murzik.Meow();
            murzik.Weight = "12,5";
            murzik.Fat();
            barsik.Meow();
            barsik.Name = "Барсик";
            barsik.Meow();
            barsik.Weight="10.4";
            barsik.Fat();
            barsik.Weight = "10,4";
            barsik.Fat();
            barsik.Name = "1234";
            barsik.Meow();
            murzik.Meow();
            murzik.Weight = "-9,7";
            murzik.Fat();
            Console.ReadKey();
        }
    }
}
