using System;
/*
Given an integer x, return true if x is palindrome integer.

An integer is a palindrome when it reads the same backward as forward.

For example, 121 is a palindrome while 123 is not.

To Test: 
var data = new List<int>();
data.Add(121);
data.Add(-121);
data.Add(10);
data.Add(1234554321);
data.Add(1234124321);
 */
namespace LeetcodeAlgorithms
{
    public class Palindrome
    {
        public Palindrome() { }

        /// <summary>
        /// Without Constraints of -2^31 <= x <= 2^31 - 1
        /// Solve it by converting the integer to a string
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public bool CheckPalindrome(int x)
        {

            if (x == 0)
            {
                return true;
            }

            if (x < 0 || x % 10 == 0)
            {
                return false;
            }

            if (x < 10)
            {
                return true;
            }

            string sb = x.ToString();
            int index = 0;

            while (index < sb.Length / 2)
            {
                if (sb[index] != sb[sb.Length - index - 1]) return false;
                index++;
            }

            return true;
        }

        /// <summary>
        /// Without converting integer to string
        /// Constraints of -2^31 <= x <= 2^31 - 1
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public bool isPalindrome(int x)
        {

            if (x == 0)
            {
                return true;
            }

            if (x < 0 || x % 10 == 0)
            {
                return false;
            }

            int reversedInt = 0;
            // 12321
            // 1234321
            while (x > reversedInt)
            {
                int pop = x % 10; // 1
                x = x / 10; // 1232

                reversedInt = reversedInt * 10 + pop; // 1
            }

            if (x == reversedInt || x == reversedInt / 10)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

    }
}











