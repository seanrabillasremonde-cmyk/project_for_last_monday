using System;
using System.Collections.Generic;
using System.Text;

namespace average_in_one_project
{
    
    public enum Range
    {
        Min = 50,
        Max = 100,
        Size = 10
    }

    public class GradeManager
    {
        public void InputGrades()
        {
            int[] numbers = new int[(int)Range.Size];
            int sum = 0;

            for (int i = 0; i < numbers.Length; i++)   // Start at 0 (C# arrays start at 0)
            {
                Console.Write($"Enter number for quarter {i + 1}: ");

                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    if (num >= (int)Range.Min && num <= (int)Range.Max)
                    {
                        numbers[i] = num;
                        sum += num;

                        if (num >= 74)
                            Console.WriteLine($"You Passed in quarter {i + 1}");
                        else
                            Console.WriteLine($"You Fail in quarter {i + 1}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid! Enter 50-100 only.");
                        i--; // repeat same index
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input! Enter a number.");
                    i--; // repeat same index
                }
            }

            double average = (double)sum / numbers.Length;
            Console.WriteLine("Average = " + average);
        }
    }
}



    // 










