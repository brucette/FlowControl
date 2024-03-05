namespace FlowControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                "Below you'll find the main menu." +
                "\nPlease make a selection by entering a number.");

            while (true)
            {
                switch (GetUserInput(
                    "\n 0 - Exit the program" +
                    "\n 1 - Get movie ticket price per age" +
                    "\n 2 - Calculate ticket costs for agroup" +
                    "\n 3 - Repeat a phrase 10 times" +
                    "\n 4 - Get the third word of a phrase" +
                    "\n\n"))  
                {
                    case "0":
                        Environment.Exit(0);
                        break;
                    case "1":
                        DisplayTicketPrice();
                        break;
                    case "2":
                        CalculateGroupCosts();
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

        private static string GetUserInput(string prompt)
        {
            Console.Write($"{prompt}");
            return Console.ReadLine();
        }

        private struct Number
        {
            public uint givenNumber;
            public bool isANumber;
        }

        private static Number GetNumber(string prompt)
        {
            // Using a struct to store and return both the number entered by user and whether it is a valid number
            Number result;

            string input = GetUserInput(prompt);

            // 0 is automatically stored in givenNumber if it is something other than a uint
            result.isANumber = uint.TryParse(input, out result.givenNumber);

            return result;
        }

        private static uint GetPriceForAge(uint age)
        {
            uint price;

            switch (age)
            {
                case < 5:
                case > 100:
                    price = 0;
                    break;
                case < 20:
                    price = 80;
                    break;
                case > 64:
                    price = 90;
                    break;
                default:
                    price = 120;
                    break;
            }
            return price;
        }

        private static void DisplayTicketPrice()
        {
            Number input = GetNumber("Please enter age: ");

            if (input.isANumber)
            {
                uint age = input.givenNumber;

                if (age < 5 || age > 100)
                {
                    Console.WriteLine("\nFree entry for this age");
                }
                else if (age < 20)
                {
                    Console.WriteLine($"\nJunior ticket fee {GetPriceForAge(age)}kr");
                }
                else if (age > 64)
                {
                    Console.WriteLine($"\nPensioner ticket fee {GetPriceForAge(age)}kr");
                }
                else
                {
                    Console.WriteLine($"\nStandard ticket fee {GetPriceForAge(age)}kr");
                }
            }
            else
            {
                Console.WriteLine("\nThat was not a valid age.");
            }
        }

        private static void CalculateGroupCosts()
        {
            uint totalCost = 0;
            uint numberOfpeople;
            bool isNumber;

            do
            {
                Number enteredNumber = GetNumber("Enter number of people: ");
                isNumber = enteredNumber.isANumber;
                numberOfpeople = enteredNumber.givenNumber;
            }
            while (!isNumber);


            for (int i = 1; i <= numberOfpeople; i++)
            {
                uint age;
                bool ageIsNumber;

                do
                {
                    Number enteredAge = GetNumber($"Enter age for person {i}: ");
                    ageIsNumber = enteredAge.isANumber;
                    age = enteredAge.givenNumber;
                }
                while (!ageIsNumber);

                totalCost += GetPriceForAge(age);
            }
            Console.WriteLine(
                $"\nNumber of people: {numberOfpeople}" +
                $"\nTotal ticket costs: {totalCost}");
        }

        private static void RepeatTenTimes()
        {
            string input = GetUserInput("Enter phrase: ");

            for (int i = 1; i < 10; i++)
            {
                Console.Write($"{i}.{input}, ");
            }
            // To get rid of a comma at the end of the last printout, print it separately outside the loop
            Console.Write($"10.{input}\n");
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
            Console.WriteLine($"Thir word: {splitSentence[2]}");
        }
    }
}
