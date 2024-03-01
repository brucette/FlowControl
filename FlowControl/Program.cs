namespace FlowControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("You have arrived at the main menu.\nPlease make a selection by entering a number.");

            while (true)
            {
                switch (GetUserInput("\n0 - Exit the program\n1 - Get movie tickets\n2 - Calculate ticket costs for a group"))
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
                    default:
                        Console.WriteLine("That was an invalid input.");
                        break;
                }
            }
        }

        private static string GetUserInput(string prompt)
        {
            Console.WriteLine(prompt ?? "");
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
