using System;

namespace _25.Apr._2018_Pr01RageExpences
{
    namespace Pr01_RageExpences
    {
        class Pr01_RageExpences
        {
            //DONE - 100/100 
            //Calculates the cost of all broken item from player under the given conditions.
            
            static void Main()
            {
                int lostGames = int.Parse(Console.ReadLine());
                double headsetPrice = double.Parse(Console.ReadLine());
                double mousePrice = double.Parse(Console.ReadLine());
                double keyboardPrice = double.Parse(Console.ReadLine());
                double displayPrice = double.Parse(Console.ReadLine());

                double result = 0;

                int headset = 0;
                int mouse = 0;
                int keyb = 0;
                int display = 0;

                headset = lostGames / 2;
                mouse = lostGames / 3;
                keyb = mouse / 2;
                display = keyb / 2;

                result = headset * headsetPrice + mouse * mousePrice + keyb * keyboardPrice + display * displayPrice;

                Console.WriteLine($"Rage expenses: {result:f2} lv.");

            }
        }
    }
}
