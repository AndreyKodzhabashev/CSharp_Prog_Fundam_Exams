using System;
using System.Collections.Generic;
using System.Linq;

namespace _25.Apr._2018_Pr04_MOBO_Chalenger
{
    class Pr04_MOBO_Chalenger
    {
        //DONE 100/100
        static void Main()
        {
            Dictionary<string, Dictionary<string, int>> dictPlayersTier = new Dictionary<string, Dictionary<string, int>>();
            
            while (true)
            {
                string inputCommand = Console.ReadLine(); //"Pesho -> Adc -> 400"; // "Faker vs Bush"; //"Season end"

                string spliter = " vs ";

                bool isFight = inputCommand.Contains(spliter);

                if (inputCommand == "Season end")
                {
                    break;
                }

                if (isFight == false)
                {
                    string splitter2 = " -> ";

                    inputCommand = inputCommand.Replace(splitter2, " ");

                    string[] arrPlayerProps = inputCommand
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    string plName = arrPlayerProps[0];
                    string plPosition = arrPlayerProps[1];
                    int plSkills = int.Parse(arrPlayerProps[2]);

                    if (dictPlayersTier.ContainsKey(plName) == false)
                    {
                        var tempDict = new Dictionary<string, int>();
                        tempDict[plPosition] = plSkills;

                        dictPlayersTier.Add(plName, tempDict);
                    }
                    else
                    {
                        var temp = dictPlayersTier[plName];

                        if (temp.ContainsKey(plPosition) == false)
                        {
                            temp.Add(plPosition, plSkills);

                            dictPlayersTier[plName] = temp;
                        }
                    }

                }

                //If it will be a fight - we know it and we have the players
                if (isFight)
                {
                    inputCommand = inputCommand.Replace(spliter, " ");

                    string[] arrPlayers = inputCommand
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    string firstPlayer = arrPlayers[0];
                    string secondPlayer = arrPlayers[1];

                    if (dictPlayersTier.ContainsKey(firstPlayer) && dictPlayersTier.ContainsKey(secondPlayer))
                    {
                        var firstPlayerSkillSet = dictPlayersTier[firstPlayer];
                        var secondPlayerSkillSet = dictPlayersTier[secondPlayer];

                        foreach (var position in firstPlayerSkillSet.Keys)
                        {
                            if (secondPlayerSkillSet.ContainsKey(position))
                            {
                                var firstPower = firstPlayerSkillSet.Values.Sum();
                                var secondPower = secondPlayerSkillSet.Values.Sum();

                                if (firstPower > secondPower)
                                {
                                    dictPlayersTier.Remove(secondPlayer);
                                }
                                else if (secondPower > firstPower)
                                {
                                    dictPlayersTier.Remove(firstPlayer);
                                }
                                else
                                {
                                    continue;
                                }

                            }
                        }
                    }
                }
            }
            foreach (var player in dictPlayersTier.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{player.Key}: {player.Value.Values.Sum()} skill");
                foreach (var skillSet in player.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"- {skillSet.Key} <::> {skillSet.Value}");
                }
            }
        }
    }
}
