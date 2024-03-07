using System;
using System.Collections.Generic;

class TwoSum
{
    static void Main()
    {
        var nums = new List<int>();

        Console.WriteLine("Welcome to Two Sum Finder");
        Dictionary<int, Action> menuOptions = new Dictionary<int, Action>
        {
            { 1, AddNumber },
            { 2, FindPair },
            { 3, Exit }
        };

        while (true)
        {
            Console.WriteLine("\nCommands:\n1. Add sum\n2. Target\n3. Exit");
            Console.Write("\nEnter your choice: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            if (menuOptions.TryGetValue(choice, out Action action))
            {
                action.Invoke();
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }

        void AddNumber()
        {
            Console.Write("Enter the number to add to the list: ");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int num))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return;
            }
            nums.Add(num);
            Console.WriteLine("Updated List: " + string.Join(", ", nums));
        }

        void FindPair()
        {
            Console.Write("Enter the target sum: ");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int targetSum))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return;
            }
            bool pairFound = false;
            for (int i = 0; i < nums.Count; i++)
            {
                for (int j = i + 1; j < nums.Count; j++)
                {
                    if (nums[i] + nums[j] == targetSum)
                    {
                        Console.WriteLine($"Indices of the two numbers that add up to {targetSum}: {i}, {j}");
                        pairFound = true;
                        break;
                    }
                }
                if (pairFound) break;
            }
            if (!pairFound)
            {
                Console.WriteLine("No such pair found.");
            }
        }

        void Exit()
        {
            Console.WriteLine("Exiting...");
            Environment.Exit(0);
        }
    }
}
