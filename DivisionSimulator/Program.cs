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
        // result: 2 -> 4 -> 16 -> 32 => 62
        // count:  1 -> 2 -> 4 -> 8 -> 16 => 31


        //prevCount = 0, prevResult = 0, count = 1, result = 2

        //prevCount = 1, prevResult = 2, count = 2, result = 4

        //prevCount = 2, prevResult = 4, count = 4, result = 8

        //prevCount = 3, prevResult = 16, count = 8, result = 16

        //prevCount = 4, prevResult = 16, count = 16, result = 32

        //prevCount = 16, prevResult = 32, count = 32, result = 64

        //16 + FDS(24, 2)


        //prevCount = 0, prevResult = 0, count = 1, result = 2

        //prevCount = 1, prevResult = 2, count = 2, result = 4

        //prevCount = 2, prevResult = 4, count = 4, result = 8

        //prevCount = 4, prevResult = 8, count = 8, result = 16

        //prevCount = 8, prevResult = 16, count = 16, result = 32

        //8 + FDS(8, 2)

        //prevCount = 0, prevResult = 0, count = 1, result = 2

        //prevCount = 1, prevResult = 2, count = 2, result = 4

        //prevCount = 2, prevResult = 4, count = 4, result = 8

        //=> 4

        //16 + 8 + 4 => 28
        static int FastDivisionSimulator(int numerator, int denominator)
        {
            if (numerator < denominator)
            {
                return 0;
            }

            int result = denominator; 
            int prevResult = 0;
            int prevCount = 0;
            int temp = denominator;

            int count = 1;

            while (result < numerator)
            {
                prevCount = count;
                prevResult = result;

                count += prevCount;

                result = denominator * count;
            }

            if (result == numerator)
            {
                return count;
            }

            return prevCount + FastDivisionSimulator(numerator - prevResult, denominator);
        }
    }
}
