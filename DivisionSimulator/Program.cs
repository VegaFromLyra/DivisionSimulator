using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Simulate integer division. The /, % and log operators are not available
// You can assume that numerator is non negative and denominator
// is non negative and not zero

namespace DivisionSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numerator = 789;
            int denominator = 3;

            Console.WriteLine("Test case 1: {0} / {1} is {2}", numerator, denominator, DivisionSimulator(numerator, denominator));

            Console.WriteLine("Test case 2: {0} / {1} is {2}", numerator, denominator, FastDivisionSimulator(numerator, denominator));
        }

        // Time complexity is O(difference in value of numerator and denominator)
        static int DivisionSimulator(int numerator, int denominator)
        {
            int count = 0;

            int result = denominator;

            while (result <= numerator)
            {
                result += denominator;
                count++;
            }

            return count;
        }

        // This is a faster version since it increases denominator
        // by a larger value each time so it is much 
        // faster than linear

        // For a value like num - 56, den  - 2
        // result: 2 -> 4 -> 8 -> 16 -> 32 => 62
        // count:  1 -> 2 -> 4 -> 8 -> 16 => 31

        // Since 62 > 56, take last result
        // NewNumerator = currentNumerator - 30 ( 2 + 4 + 8 + 16) => 26
        // Recusrse for count + result of Divide(26, 2)
        static int FastDivisionSimulator(int numerator, int denominator)
        {
           int result = denominator; 
           int prevResult = 0;
           int prevCount = 0;
           int temp = denominator;

           int count = 1;

           while (result < numerator)
           {
               prevCount = count;
               prevResult = result;

               count += temp;

               temp *= denominator;

               result += temp;
           }

           if ((numerator < denominator) || (result == numerator))
           {
               return count;
           }

           return prevCount + FastDivisionSimulator(numerator - prevResult, denominator);
        }
    }
}
