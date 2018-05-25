using System;
using System.Linq;
using System.Text;

namespace _25.Apr._2018_Pr02_Memory_View
{
    //DONE - 90/100 time compile error in one test
    //input = // "0 32656 19759 32763 0 7 0 83 111 102 116 117 110 105 0 0 0 0 0 0 0 0"
    //output = some name, may be Pesho

    class Pr02_Memory_View
    {
        static void Main()
        {

            StringBuilder sb = new StringBuilder();

            while (true)
            {
                string inputText = Console.ReadLine();;

                if (inputText == "Visual Studio crash")
                {
                    break;
                }

                sb.Append(inputText + ' ');
            }

            string totalText = sb.ToString();

            string beginPattern = "32656 19759 32763";

            while (totalText.Length > 30)
            {

                int index = totalText.IndexOf(beginPattern);
                if (index == -1)
                {
                    return;
                }
                var indexTextLength = totalText.Skip(index + beginPattern.Length + 3).ToArray();

                int textLength = int.Parse(indexTextLength[0].ToString());
                if (totalText.Length >= (index + beginPattern.Length + 7))
                {
                    totalText = totalText.Remove(0, index + beginPattern.Length + 7).ToString();
                }

                int[] nums = totalText
                      .Split(' ')
                      .Take(textLength)
                      .Select(int.Parse)
                      .ToArray();

                StringBuilder sb1 = new StringBuilder();

                foreach (var num in nums)
                {
                    char temp = (char)num;
                    sb1.Append(temp);
                }

                Console.WriteLine(sb1.ToString());
            }
        }
    }
}
