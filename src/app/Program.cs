using System;
using Library;


namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*Console.WriteLine("Hello World!");
            IntToWords s = new IntToWords();
            //int[] nums1 = new int[0] {};
            //int[] nums2 = new int[2] {2,3};
           //Console.WriteLine(s.FindMedianSortedArraysOptimized(nums1, nums2).ToString());
            Console.WriteLine(s.NumberToWords(123456789));
            //Console.WriteLine(s.numDigits(123).ToString());*/

            LongestPalindromicSubstring longestPalindrome = new LongestPalindromicSubstring();
            Console.WriteLine(longestPalindrome.LongestPalindrome("test with long string"));
        }
    }
}
