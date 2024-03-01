namespace FlowControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("You have arrived at the main menu.\nPlease make a selection by entering a number.");

            while (true)
            {
                switch (GetUserInput(
                    "\n0 - Exit the program" +
                    "\n1 - Get price for movie ticket" +
                    "\n2 - Calculate total ticket costs" +
                    "\n3 - Repeat a phrase 10 times" +
                    "\n4 - Get the third word" +
                    "\n"))  
                {
                    case "0":
                        Environment.Exit(0);
                        break;
                    case "1":
                        CheckAge();
                        break;
                    case "2":
                        CheckAge();
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

        private static void CheckAge()
        {
            string input = GetUserInput("Please enter age: ");
            if (int.TryParse(input, out var age))
            {
                if (age < 20)
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
            else
            {
                Console.WriteLine("Invalid age entered.");
            }
        }
    }
}
