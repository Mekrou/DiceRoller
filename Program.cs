using System;

namespace DiceRoller
{
    class Program
    {
        /// <summary>
        /// Prompts the user to enter how many dice they want to roll
        /// and then adds their rolls to calculate their net roll.
        /// Then it prints each individual roll.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int userInput;
            int sum = 0;
            

            PrintWelcomeMessage();

            userInput = HandleUserInput();
            
            int[] rolls = new int[userInput];

            Random rand = new Random();
            
            for (int i = 0; i < userInput; i++)
            {
                int rolledDiceResult = rand.Next(1, 6);
                rolls[i] = rolledDiceResult;
                sum += rolledDiceResult;
            }
            
            Console.WriteLine($"You rolled a net: {sum}");

            Console.WriteLine("Your rolls were: " + PrintIndividualRolls(rolls));
        
        }



        /// <summary>
        /// User input is encapsulated in this function to achieve a clean error free app.
        /// It loops until a valid user input is achieved.
        /// </summary>
        /// <returns>The amount of die the player wants to roll</returns>
        static int HandleUserInput()
        {
            int userInput;
            
            while (true)
            {
                try
                {
                    userInput = Convert.ToInt32(Console.ReadLine());
                    return userInput;
                } 
                catch (FormatException)
                {
                    PrintInvalidInput();
                }
                catch (System.IO.IOException)
                {
                    PrintInvalidInput();
                }
                catch (OverflowException)
                {
                    PrintInvalidInput();
                }
            }
        }

        static void PrintInvalidInput()
        {
            Console.WriteLine("Invalid Input. Please try again.");
        }

        static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to Dice Roller.");
            Console.WriteLine("How many dice would you like to roll?");
            Console.WriteLine();
        }

        /// <summary>
        /// Prints individual rolls separated with a "|" character.
        /// </summary>
        /// <param name="array">An array of the player's rolls</param>
        /// <returns>The concatenated string of rolls to display nicely in the console.</returns>
        static string PrintIndividualRolls(int[] array)
        {
            string printedArray = "|";

            foreach (int element in array)
            {
                printedArray += (element + "|");
            }

            return printedArray;
        }
    }
}
