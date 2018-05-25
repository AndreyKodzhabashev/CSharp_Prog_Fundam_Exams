using System;
using System.Collections.Generic;
using System.Linq;

namespace _25.Apr._2018_Pr03_Tseam_Account
{
    class Pr03_Tseam_Account
    {
        //DONE - 100/100
        //Input:
        //CS WoW Diablo
        //Install LoL
        //Uninstall WoW
        //Update Diablo
        //Expansion CS-Go
        //Play!

        static void Main()
        {

            string listOfGames = Console.ReadLine();
            List<string> listGames = listOfGames
                .Split(' ')
                .ToList();

            while (true)
            {
                string inputText = Console.ReadLine();
                if (inputText == "Play!")
                {
                    break;
                }

                string[] tempComandPlusGame = inputText
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (tempComandPlusGame[0] == "Install")
                {
                    if (listOfGames.Contains(tempComandPlusGame[1]) == false)
                    {
                        listGames.Add(tempComandPlusGame[1]);
                    }
                }
                else if (tempComandPlusGame[0] == "Uninstall")
                {
                    if (listOfGames.Contains(tempComandPlusGame[1]))
                    {
                        listGames.Remove(tempComandPlusGame[1]);
                    }
                }
                else if (tempComandPlusGame[0] == "Update")
                {
                    if (listOfGames.Contains(tempComandPlusGame[1]))
                    {
                        listGames.Remove(tempComandPlusGame[1]);

                        listGames.Add(tempComandPlusGame[1]);
                    }
                }
                else if (tempComandPlusGame[0] == "Expansion")
                {
                    string[] temp = tempComandPlusGame[1]
                        .Split('-')
                        .ToArray();
                    if (listGames.Contains(temp[0]))
                    {
                        int locationGame = listGames.IndexOf(temp[0]);
                        listGames.Insert(locationGame + 1, (temp[0] + ":" + temp[1]));
                    }

                }
            }

            Console.WriteLine(string.Join(" ", listGames));
        }
    }
}
