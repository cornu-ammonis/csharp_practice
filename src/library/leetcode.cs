using System;
using System.Collections.Generic;

namespace Library
{
    public class Thing
    {
        public void PrintC()
        {    
            Console.WriteLine("things are working");
            Console.WriteLine("and updating");
        }

        public int lengthOfLongestSubstring(string s) {
            int n = s.Length;
            
            HashSet<char> set = new HashSet<char>();
            int ans = 0, i = 0, j = 0;
            
            while(i < n && j < n) {
                if(set.Add(s[j])) {
                    j++;
                    ans = Math.Max(ans, j - i);
                }
                else {
                    set.Remove(s[i++]);
                }
            }
            return ans;
        }

        public int lengthOfLongestSubstringOptimized(string s) {
            int n = s.Length;
            int ans = 0;
            Dictionary<char, int> map = new Dictionary<char, int>();

            for(int j = 0, i = 0; j < n; j++) {
                if(map.ContainsKey(s[j])) {
                    i = Math.Max(map[s[j]], i);
                    
                }
                map[s[j]] = j + 1;
                ans = Math.Max(ans, j - i + 1);
            }
            return ans;
        }

        public void printTest(string s) {
            int ans = this.lengthOfLongestSubstringOptimized(s);
            string toprint = ans.ToString();
            Console.WriteLine("input: " + s + " answer: " + toprint);
        }


        public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        
        
        int i = 0,  j = 0, length = nums1.Length + nums2.Length;
        
        int[] aggregate = new int[length];

        while(i < nums1.Length || j < nums2.Length) {
            if(i < nums1.Length && j< nums2.Length) {
                if(nums1[i] < nums2[j]) 
                {
                    aggregate[i + j] = nums1[i];
                    i++;
                }

                else
                {
                    aggregate[i + j] = nums2[j];
                    j++;
                }

            }

            else if (i < nums1.Length) {
                aggregate[i + j] = nums1[i];
                i++;
            }
            else {
                 aggregate[i + j] = nums2[j];
                 j++;
            }
            
            
            
        }
        
        // if odd, find middle element
        if(length % 2 == 1) {
            return aggregate[length/2];
            
        }
        else {
            return (double)(aggregate[length/2 - 1] + aggregate[length/2])/(double)2;
        }

    }


    public double FindMedianSortedArraysOptimized(int[] nums1, int[] nums2) {
        
       int i = 0, j = 0, length = nums1.Length + nums2.Length;
       bool odd;
       if (length % 2 == 1) {
           odd = true;
       }
       else {
           odd = false;
       }

       if(nums1.Length == 0) {
           if(nums2.Length == 1) {
               return nums2[0];
           }
           if(odd) {
               return nums2[length/2];
           }
           else {
               return (double)(nums2[(length/2)-1] + nums2[length/2])/2;
           }
       }
       if (nums2.Length == 0) {
           if(nums1.Length == 1) {
               return nums1[0];
           }
           if(odd) {
               return nums1[length/2];
           }
           else {
               return (double)(nums1[(length/2) - 1] + nums1[length/2])/2;
           }
       }
      
       while(i < nums1.Length && j < nums2.Length && (i + j) < length/2) {

           if(nums1[i] < nums2[j]) {
               i++;
           }
           else if (nums2[j] < nums1[i]) {
               j++;
           }
           //if more remaining indexes in num1, increment i; else j -- when values are equal
           else if ((nums1.Length - i) > (nums2.Length - j)) {
               i++;
           }
          else {
              j++;
          }
           
       }

       while(i < nums1.Length && !(j < nums2.Length) && (i+j) < length/2) {
           i++;
       }

       while(j < nums2.Length && !(i < nums1.Length) && (i+j) < length/2) {
           j++;
       }
        
    
       if(odd) {
           if(!(i < nums1.Length) && !(j < nums2.Length)) {
               return -69;
           }
           else if(!(i < nums1.Length) && j < nums2.Length) {
               return nums2[j];
           }
           else if(!(j < nums2.Length) && i < nums1.Length) {
               return nums1[i];
           }
           else{
               return Math.Min(nums1[i], nums2[j]);
           }

       }
       else {
           if(!(i < nums1.Length) && !(j < nums2.Length)) {
               return -68;
           }
           else if(!(i < nums1.Length)) {
               if (j == 0) {
                   return (double)(nums1[i-1] + nums2[j])/2;
               }
               if(nums1[i-1] >= nums2[j-1]) {
                   return (double)(nums1[i-1] + nums2[j])/2;
               }
               return (double)(nums2[j-1] + nums2[j])/2;
           }
           else if (!(j < nums2.Length)) {
               if(i == 0) {
                   return (double)(nums2[j-1] + nums1[i])/2;
               }
               if(nums2[j-1] >= nums1[i-1]) {
                   return (double)(nums2[j-1] + nums1[i])/2;
               }
               return (double)(nums1[i - 1] + nums1[i])/2;
           }
           else {
               int x, y;

               if(i == 0) {
                  
                   x = nums2[j-1];
                   if(nums1[i] <= nums2[j]) {
                       y = nums1[i];
                   }
                   else {
                       y = nums2[j];
                   }
                   return (double)(x + y)/2;
               }
               else if (j == 0) {
                   x = nums1[i - 1];
                   if(nums1[i] <= nums2[j]) {
                       y = nums1[i];
                   }
                   else {
                       y = nums2[j];
                   }
                   return (double)(x+y)/2;
               }

               if(nums1[i-1] >= nums2[j-1]) {
                   x = nums1[i-1];
                   
                   if( i < nums1.Length) {
                       if(nums1[i] <= nums2[j]) {
                           y = nums1[i];
                           i++;
                       }
                       else {
                           y = nums2[j];
                           j++;
                       }
                   }
                   else {
                       y = nums2[j];
                       j++;
                   }
               }
               else {
                   x = nums2[j-1];
                   
                   if(j < nums2.Length) {
                       if(nums1[i] <= nums2[j]) {
                           y = nums1[i];
                           i++;
                       }
                       else {
                           y = nums2[j];
                           j++;
                       }
                   }
                   else {
                       y = nums1[i];
                       i++;
                   }
               }

               return (double) (x + y)/2;
           }
       }
       

    }
    }
}
