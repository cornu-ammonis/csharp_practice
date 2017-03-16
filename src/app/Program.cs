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
            //Console.WriteLine(s.numDigits(123).ToString());

            //LongestPalindromicSubstring longestPalindrome = new LongestPalindromicSubstring();
            //string s = "aab"; 
            //Console.WriteLine(longestPalindrome.LongestPalindromeOptimizeAttempt1(s));

            string s = "12345678";
            string rev = "";
            
            for( int i = s.Length - 1; i >=0; i--) {
                rev = rev + s[i];
            }
            Console.WriteLine(rev);*/

            IPValidation ip = new IPValidation();
            string testIPv4 = "172.16.254.1";
            
            Console.WriteLine(ip.isValidIPv4(testIPv4));
            string testIPv6 = "2001:0db8:85a3:0000:0000:8a2e:0370:7334";
            Console.WriteLine(ip.isValidIPv6(testIPv6));

            

            
            
        }
    }
}
