using System;

namespace Yahtzee
{
    class Program
    {
        static Random r = new Random();

        static void Main(string[] args)
        {
            //Roll 5 dice, ask user which they want to keep
            //roll dice again, ask user which they want to keep
            //then roll remaining dice
            //add up number of dice that was rolled the most (ex: 5,4,3,4,4 would be 3 as 3 4's were rolled)
            //computer rolls 5 dice 3 times, and takes the highest number of dice rolled
            //compare computer rolls to user rolls and print the winner with the tie going to user.
            
            //string dieOne;
            //string dieTwo;
            //string dieThree;
            //string dieFour;
            //string dieFive;
            

            int[] diceRolls = new int[5];
            diceRolls = RollTheDice(5);
            Random r = new Random();

            Console.WriteLine("***Yahtzee!!***");
            Console.WriteLine("Here is your first roll:");

            for (int i = 0; i < diceRolls.Length; i++)
            {
                Console.Write(i + 1 + ": ");
                
                Console.WriteLine(diceRolls[i]);
            }
            Console.WriteLine("Which of the 5 dice do you want to keep? (separate by comma) ");
            string keptDiceUserInput = Console.ReadLine();
            string[] keptDiceString = keptDiceUserInput.Split(',');
            int[] keptDiceInt = new int[keptDiceString.Length];

            for (int i = 0; i < keptDiceString.Length; i++)
            {
                int keptDice1 = int.Parse(keptDiceString[i]) -1;
                
                keptDiceInt[i] = diceRolls[keptDice1];
                
            }
            int remainingDice1 = 5 - keptDiceInt.Length;
            int[] diceRolls2 = RollTheDice(remainingDice1);

            diceRolls2.CopyTo(diceRolls, 0);
            keptDiceInt.CopyTo(diceRolls, diceRolls2.Length);

            Console.WriteLine("Here is your second roll: ");
            for (int i = 0; i < diceRolls.Length; i++)
            {

                Console.Write(i + 1 + ": ");

                Console.WriteLine(diceRolls[i]);
            }

            Console.WriteLine("Which of these dice do you want to keep? (separate by comma) ");
            string keptDiceUserInput2 = Console.ReadLine();
            string[] keptDiceString2 = keptDiceUserInput2.Split(',');
            int[] keptDiceInt2 = new int[keptDiceString2.Length];

            for (int i = 0; i < keptDiceString2.Length; i++)
            {
                int keptDice1 = int.Parse(keptDiceString2[i]) - 1;

                keptDiceInt2[i] = diceRolls[keptDice1];

            }
            int remainingDice2 = 5 - keptDiceInt2.Length;
            int[] diceRolls3 = RollTheDice(remainingDice2);

            diceRolls3.CopyTo(diceRolls, 0);
            keptDiceInt2.CopyTo(diceRolls, diceRolls3.Length);

            Console.WriteLine("Here is your 3rd and final roll: ");
            for (int i = 0; i < diceRolls.Length; i++)
            {
                Console.Write(i + 1 + ": ");

                Console.WriteLine(diceRolls[i]);
            }

            int playerScore = DuplicateCount(diceRolls);

            int[] computerRoll1 = RollTheDice(5);
            int[] computerRoll2 = RollTheDice(5);
            int[] computerRoll3 = RollTheDice(5);
            int[] results = new int[3];
                results[0] = DuplicateCount(computerRoll1);
            results[1] = DuplicateCount(computerRoll2);
            results[2] = DuplicateCount(computerRoll3);

            int computerHighestScore = 0;
            for (int i = 0; i < 3; i++)
            {
                
                if (results[i] > computerHighestScore)
                {
                    computerHighestScore = results[i];

                }
            }
            if (playerScore >= computerHighestScore)
            {
                Console.WriteLine("You win!");
            }
            else
            {
                Console.Write("Computer Wins!");
            }

            Console.ReadLine();
        
        
        }
        public static int DuplicateCount(int[] rolledDice)
        {
            int[] score = new int[6];

            for (int i = 0; i < 5; i++)
            {
                
                for (int q = 0; q < 6; q++)
                {
                    if (rolledDice[i] == q+1)
                    {
                        score[q]++;
                    }
                }
            }

            int maxValue = 0;
            for (int i = 0; i < 6; i++)
            {
                if (score[i] > maxValue)
                {
                    maxValue = score[i];
                }
            }
            return maxValue;
        }

        public static int Dice()
        {
            int randomNum = new Random().Next(1, 6);
            int dice = randomNum;
            return dice;
        }
        public static int[] RollTheDice(int numberOfRolls)
        {
            int[] rollDice = new int[numberOfRolls];

            for (int i = 0; i < numberOfRolls; i++)
            {

                rollDice[i] = r.Next(1, 6);

            }
            return rollDice;
        }
    }
}
