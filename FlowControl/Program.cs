﻿namespace FlowControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                "Below you find the main menu." +
                "\nPlease make a selection by entering a number.");

            while (true)
            {
                switch (GetUserInput(
                    "\n0 - Exit the program" +
                    "\n1 - Get movie ticket price per age" +
                    "\n2 - Calculate ticket costs for agroup" +
                    "\n3 - Repeat a phrase 10 times" +
                    "\n4 - Get the third word of a phrase" +
                    "\n"))  
                {
                    case "0":
                        Environment.Exit(0);
                        break;
                    case "1":
                        CheckAge();
                        break;
                    case "2":
                        CalculateCosts();
                        break; 
                    case "3":
                        RepeatTenTimes();
                        break;
                    case "4":
                        GetThirdWord();
                        break;
                    default:
                        Console.WriteLine("That was an invalid selection.");
                        break;
                }
            }
        }
        private static void GetThirdWord()
        {
            string input = GetUserInput("Enter phrase with a minimum of 3 words: ");
            var splitSentence = input.Trim().Split(' ');
          
            if (splitSentence.Length < 3 ) 
            {
                Console.WriteLine("Invalid entry");
                return;
            }
            Console.WriteLine(splitSentence[2]);
        }
        private static void RepeatTenTimes()
        {
            string input = GetUserInput("Enter phrase: ");

            for (int i = 1; i < 10; i++) 
            {
                Console.Write($"{i}.{input}, ");
            }
            Console.Write($"10.{input}");
        }
        private static string GetUserInput(string prompt)
        {
            Console.WriteLine($"{prompt}");
            return Console.ReadLine();
        }
        private static uint GetNumber(string prompt)
        {
            uint result;
            bool isANumber;

            do
            {
                string input = GetUserInput(prompt);
                isANumber = uint.TryParse(input, out result);
            }
            while (!isANumber);

            return result;
        }
        private static void CalculateCosts()
        {
            uint numberOfpeople = GetNumber("Enter number of people: ");
            uint totalCost = 0;
            //List<uint> movieGoers = new List<uint>(); 
            //movieGoers.Add(age);
            for (int i = 1; i <= numberOfpeople; i++)
            { 
                uint age = GetNumber($"Enter age for person {i}: ");
                totalCost += GetPriceForAge(age);
            }
            Console.WriteLine(
                $"Number of people: {numberOfpeople}" +
                $"\nTotal ticket costs: {totalCost}");
        }
        private static uint GetPriceForAge(uint age)
        {
            uint price;

            if (age < 5 || age > 100)
            {
                price = 0;
            }
            else if (age < 20)
            {
                price = 80;
            }
            else if (age > 64)
            {
                price = 90;
            }
            else
            {
                price = 120;
            }
            return price;   
        }
        private static void CheckAge()
        {
            uint age = GetNumber("Please enter age: ");

                if (age < 5 || age > 100)
                {
                    Console.WriteLine("Free entry for this age");
                } 
                else if (age < 20)
                {
                    Console.WriteLine("Junior ticket fee 80kr");
                }
                else if (age > 64)
                {
                    Console.WriteLine("Pensioner ticket fee 90kr");
                }
                else
                {
                    Console.WriteLine("Standard ticket fee 120kr");
                }
        }
    }
}
