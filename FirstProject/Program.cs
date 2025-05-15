using System;
using System.Buffers.Text;
using System.Collections.Generic;
using static System.Formats.Asn1.AsnWriter;

namespace StudentMarksCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                Console.WriteLine("############################################################################");
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1 - Student Marks Calculator");
                Console.WriteLine("2 - Simple Text-Based Quiz Game");
                Console.WriteLine("3 - Basic Budget Tracker");
                Console.WriteLine("4 - Temperature Converter");
                Console.WriteLine("5 - Number Puzzle Game");
                Console.WriteLine("6 - Exit the program.");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": Student_Marks_Calculator(); break;
                    case "2": Simple_Text_Based_Quiz_Game(); break;
                    case "3": Basic_Budget_Tracker(); break;
                    case "4": Temperature_Converter(); break;
                    case "5": NumberPuzzleGame(); break;
                    case "6": return;
                    default: Console.WriteLine("Invalid choice. Please select a number between 1 and 5."); break;
                }
            }
        }
        static void Student_Marks_Calculator()
        {
            Console.WriteLine("=== Student Marks Calculator ===");
            Console.Write("Enter the number of students: ");
            int numberOfStudents = int.Parse(Console.ReadLine());

            String[] studentName = new String[numberOfStudents];
            int[] studentMarks = new int[numberOfStudents];

            for (int i = 0; i < numberOfStudents; i++)
            {
                Console.WriteLine($"Enter name of Student NO#{i + 1} :");
                studentName[i] = Console.ReadLine();
                Console.WriteLine($"Enter grade of Student NO#{i + 1} :");
                studentMarks[i] = int.Parse(Console.ReadLine());

            }
            double average = studentMarks.Average();
            Console.WriteLine($"=== Average = {average} ===");
            int maximum = studentMarks.Max();
            Console.WriteLine($"=== Maximum  = {maximum} ===");
            int minimum = studentMarks.Min();
            Console.WriteLine($"=== Minimum = {minimum} ===");


        }
        static void Simple_Text_Based_Quiz_Game()
        {
            String[] questions =
            {
                "What is the capital of Egypt?",
                "How many legs does a dog have?",
                "How many days are there in a week?",
                " 2 + 2 = ?",
            };
            String[] TrueAnswers =
            {
                "cairo",
                "4",
                "7",
                "4",
            };
            String[] UserAnswers = new String[questions.Length];
            int score = 0;
            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine($"{questions[i]}");
                Console.Write("Your answer: ");
                UserAnswers[i] = Console.ReadLine().ToLower();
                if (UserAnswers[i] == TrueAnswers[i])
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine($"Wrong! The correct answer is {TrueAnswers[i]}");
                }

            }
            Console.WriteLine($"The Final Score is {score}/{questions.Length}");


        }
        static void Basic_Budget_Tracker()
        {

            Double totalIncome = 0;
            Double totalExpenses = 0;

            Console.Write("Enter the number of incomes: ");
            int numberOfIncomes = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfIncomes; i++)
            {
                Console.Write($"Enter income #{i + 1}: ");
                totalIncome += double.Parse(Console.ReadLine());
            }
            Console.Write("Enter the number of expenses: ");
            int numberOfExpenses = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfExpenses; i++)
            {
                Console.Write($"Enter expense #{i + 1}: ");
                totalExpenses += double.Parse(Console.ReadLine());
            }
            Console.WriteLine($"Total Income: {totalIncome}");
            Console.WriteLine($"Total Expenses: {totalExpenses}");
            Console.WriteLine($"Net Income: {totalIncome - totalExpenses}");

        }
        static void Temperature_Converter()
        {
            Console.WriteLine("Which Temperature you want to Convert");
            Console.WriteLine("Fahrenheit (F) or Celsius (C) or Kelvin (K)");
            String Input = Console.ReadLine().ToLower();
            Console.WriteLine("");

            if (Input == "f" || Input == "c" || Input == "k")
            {

                Console.WriteLine("Enter Temperature");

                Double temperature = 0;
                temperature = double.Parse(Console.ReadLine());

                switch (Input)
                {
                    case "f":
                        //Console.WriteLine($"From Fahrenheit to Celsius Equal :{(temperature - 32) * (5   / 9)}");
                        Console.WriteLine($"From Fahrenheit to Celsius Equal :{(temperature - 32) * (5.0 / 9)}");
                        Console.WriteLine($"From Fahrenheit to Kelvin Equal :{(temperature - 32) * (5.0 / 9) + 273.15}");
                        break;

                    case "c":
                        Console.WriteLine($"From Celsius to Fahrenheit Equal :{(temperature * (9.0 / 5) + 32)}");
                        Console.WriteLine($"From Celsius to Kelvin Equal :{(temperature + 273.15)}");
                        break;

                    case "k":
                        Console.WriteLine($"From Kelvin to Celsius Equal :{(temperature - 273.15)}");
                        Console.WriteLine($"From Kelvin to Fahrenheit Equal :{(temperature - 273.15) * (9.0 / 5) + 32}");
                        break;
                }

            }
            else
            {
                Console.WriteLine("Invalid Input");
            }


        }

        const int SIZE = 4;
        static int[,] board = new int[SIZE, SIZE];
        static Random rand = new Random();
        static void NumberPuzzleGame()
        {
            InitializeBoard();
            ShuffleBoard();
            PrintBoard();

            while (!IsSolved())
            {
                Console.Write(" To Move Press (W/A/S/D): ");
                ConsoleKey key = Console.ReadKey(true).Key;
                bool moved = false;

                switch (key)
                {
                    case (ConsoleKey.UpArrow or ConsoleKey.W): moved = Move("up"); break;
                    case (ConsoleKey.DownArrow or ConsoleKey.S): moved = Move("down"); break;
                    case (ConsoleKey.LeftArrow or ConsoleKey.A): moved = Move("left"); break;
                    case (ConsoleKey.RightArrow or ConsoleKey.D): moved = Move("right"); break;
                    case ConsoleKey.Escape: return;
                }

                if (moved)
                {
                    PrintBoard();
                    if (IsSolved())
                    {
                        Console.WriteLine("🎉 Congratulations! You solved the puzzle!");
                        break;
                    }
                }
            }
        }

        static void InitializeBoard()
        {
            int num = 1;
            for (int i = 0; i < SIZE; i++)
                for (int j = 0; j < SIZE; j++)
                    board[i, j] = num++;
            board[SIZE - 1, SIZE - 1] = 0; // empty space
        }

        static void ShuffleBoard()
        {
            // Perform 1000 valid random moves to shuffle
            for (int i = 0; i < 1000; i++)
            {
                string[] directions = { "up", "down", "left", "right" };
                Move(directions[rand.Next(4)]);
            }
        }

        static void PrintBoard()
        {
            Console.Clear();
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    if (board[i, j] == 0)
                        Console.Write("   . ");
                    else
                        Console.Write($"{board[i, j],4} ");
                }
                Console.WriteLine("\n");
            }
        }

        static bool Move(string direction)
        {
            int x = 0, y = 0;

            // Find the empty tile (0)
            for (int i = 0; i < SIZE; i++)
                for (int j = 0; j < SIZE; j++)
                    if (board[i, j] == 0)
                    {
                        x = i; y = j;
                        break;
                    }

            int newX = x, newY = y;

            switch (direction)
            {
                case "up": newX = x - 1; break;
                case "down": newX = x + 1; break;
                case "left": newY = y - 1; break;
                case "right": newY = y + 1; break;
            }

            if (newX >= 0 && newX < SIZE && newY >= 0 && newY < SIZE)
            {
                (board[x, y], board[newX, newY]) = (board[newX, newY], board[x, y]);
                return true;
            }

            return false;
        }

        static bool IsSolved()
        {
            int expected = 1;
            for (int i = 0; i < SIZE; i++)
                for (int j = 0; j < SIZE; j++)
                {
                    if (i == SIZE - 1 && j == SIZE - 1)
                        return board[i, j] == 0;
                    if (board[i, j] != expected++)
                        return false;
                }

            return true;
        }
    }


}
