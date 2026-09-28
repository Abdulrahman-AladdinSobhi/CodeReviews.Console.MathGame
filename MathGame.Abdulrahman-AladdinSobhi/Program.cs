using System.Threading.Tasks.Sources;

namespace Math_Game
{
    internal class Program
    {
        public int score = 0;
        static bool running = true;
        static Random random = new Random();
        static List<string> GameHistory = new List<string>();
        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.Clear();

                Console.WriteLine("""
                                  /\  /\     /\   ----- |   |
                                 /  \/  \   /--\    |   |---|
                                /        \ /    \   |   |   |
        """);

                Console.WriteLine("1. Addition");
                Console.WriteLine("2. Subtraction");
                Console.WriteLine("3. Multiplication");
                Console.WriteLine("4. Division");
                Console.WriteLine("5. Random Game");
                Console.WriteLine("6. Game History");
                Console.WriteLine("7. Exit");

                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        PlayGame("Addition");
                        break;

                    case "2":
                        PlayGame("Subtraction");
                        break;

                    case "3":
                        PlayGame("Multiplication");
                        break;

                    case "4":
                        PlayGame("Division");
                        break;

                    case "5":
                        PlayRandomGame();
                        break;

                    case "6":
                        ShowHistory();
                        break;

                    case "7":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        Console.WriteLine("Press any key to return to MainMenu");
                        Console.ReadKey();
                        break;
                }
            }

            Console.WriteLine("Thanks for playing!");
        }

            static void PlayGame(string operation)
        {
            int score = 0;
            int numberOfQuestions = 5;

            Console.Clear();
            Console.WriteLine($"=== {operation} Game ===");
            Console.WriteLine();

            for (int i = 1; i <= numberOfQuestions; i++)
            {
                int number1;
                int number2;
                int correctAnswer;

                if (operation == "Division")
                {
                    // Generate a division that always has an integer answer.
                    number2 = random.Next(1, 11);
                    correctAnswer = random.Next(0, 11);
                    number1 = number2 * correctAnswer;

                    // number1 is always between 0 and 100
                }
                else
                {
                    number1 = random.Next(0, 101);
                    number2 = random.Next(0, 101);

                    if (operation == "Addition")
                    {
                        correctAnswer = number1 + number2;
                    }
                    else if (operation == "Subtraction")
                    {
                        correctAnswer = number1 - number2;
                    }
                    else
                    {
                        correctAnswer = number1 * number2;
                    }
                }

                Console.Write($"Question {i}: ");

                if (operation == "Addition")
                {
                    Console.Write($"{number1} + {number2} = ");
                }
                else if (operation == "Subtraction")
                {
                    Console.Write($"{number1} - {number2} = ");
                }
                else if (operation == "Multiplication")
                {
                    Console.Write($"{number1} x {number2} = ");
                }
                else
                {
                    Console.Write($"{number1} / {number2} = ");
                }

                int playerAnswer;

                while (!int.TryParse(Console.ReadLine(), out playerAnswer))
                {
                    Console.Write("Please enter a valid number: ");
                }

                if (playerAnswer == correctAnswer)
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine($"Wrong! The correct answer was {correctAnswer}.");
                }

                Console.WriteLine();
            }

            Console.WriteLine($"Game finished!");
            Console.WriteLine($"Your score: {score}/{numberOfQuestions}");

            GameHistory.Add($"{operation} - Score: {score}/{numberOfQuestions}");

            Console.WriteLine();
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        static void PlayRandomGame()
        {
            string[] operations =
            {
            "Addition",
            "Subtraction",
            "Multiplication",
            "Division"
        };

            string randomOperation =
                operations[random.Next(operations.Length)];

            PlayGame(randomOperation);
        }

        static void ShowHistory()
        {
            Console.Clear();

            Console.WriteLine("=== Game History ===");
            Console.WriteLine();

            if (GameHistory.Count == 0)
            {
                Console.WriteLine("No games have been played yet.");
            }
            else
            {
                for (int i = 0; i < GameHistory.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {GameHistory[i]}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }
    }
}
