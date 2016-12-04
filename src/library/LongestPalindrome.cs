 using System.Linq;
 namespace Library {

     public class LongestPalindromicSubstring {

         public string LongestPalindromeBruteForce(string s) {

             string ans = s[0].ToString(), temp;
             for(int i = 0; i < s.Length - 1; i++) {
                 for (int j = i + 1; j < s.Length; j++) {
                     temp = s.Substring(i, j - i + 1);
                     if(ReverseString(temp).Equals(temp)) {
                         ans = (temp.Length > ans.Length) ? temp : ans;
                     }
                 }
             }
             
             return ans;

          }

         
          public string LongestPalindromeOptimizeAttempt1(string s) {
              string ans = s[0].ToString(), temp;
              if(s.Length > 1) {
                  if (ans[0].Equals(s[1])) {
                      ans = ans + s[1].ToString();
                  }

                  if(s.All(c => c.Equals(s[0]))) {
                      return s;
                  }

                for(int i = 1; i < s.Length - 1; i++) {
                    if(ans.Length > ((s.Length - i)*2)) {
                        return ans;
                    }
                    
                    //if all remaining characters in the array are the same 
                    if(s.Substring(i).All(c => c.Equals(s[i])) && i > 2) {
                        return ((s.Length - i) > ans.Length) ? s.Substring(i) : ans;
                    }

                    if(s[i].Equals(s[i+1])) {
                        temp = TryEvenCenter(s, i);
                        ans = (temp.Length > ans.Length) ? temp : ans;
                    }
                    
                    if(s[i-1].Equals(s[i+1])) {
                        temp = TryOddCenter(s, i);
                        ans = (temp.Length > ans.Length) ? temp : ans;
                    }

                    if (ans.Length == s.Length) {
                        return ans;
                    }
                }

                return ans;
              }
              else {
                  return ans;
              }
          }

        
        
        public string TryEvenCenter(string s, int i) {
            
            //algebra note: essentially specify start and end indexes, i and j, of substring to retrieve from s, do
            // s[i, j] = s.Substring(i, (j-i)+1))
            //
            // functionally s[i, i + 1]
            //or s.Substring(i, (i + 1) - i + 1)
            string ans = s.Substring(i, 2);

            int j = 1;
            while((i - j) >= 0 && i + (j + 1) < s.Length) {
                
                //where center is i and i+1, if s[center-1] = s[center+1], its palindromic
                if(s[i-j].Equals(s[i + j + 1])) {
                    ans = s.Substring(i-j,((i+j+1)- (i-j)) + 1);
                    j++;
                }
                else {
                    return ans;
                }

            }
            return ans;
        }

        public string TryOddCenter(string s, int i) {
            int x = 1;
            
            //algebra note: to do s[i-x, i+x], do
            //s.Substring(i-x, 2*x +1)
            
            string ans = s.Substring(i - x, 2 * x + 1);
            x++;

            //while [i-x, i+x] will both be in bounds of string
            while((i - x) >= 0 && i + x < s.Length) {

                //shoud make this so it doesnt call substring function until it determines end of palindrome  ****
                if(s[i-x].Equals(s[i+x])) {
                    ans = s.Substring(i - x, 2 * x + 1);
                    x++;
                }
                else {
                    return ans;
                }
            }
            return ans;
        }

         public string ReverseString (string s) {
             string reversed = "";

             for(int i = s.Length - 1; i >= 0; i--) {
                 reversed += s[i];
             }
             return reversed;
         }
     }

     public class LongestPalindromicSubstringOptimized {

         public string LongestPalindromeOptimizeAttempt2(string s) {

             if(s.Length > 1) {
                 
                 int start = 0, length = 1, distanceFromCenter;
                 if(s[0].Equals(s[1])) {
                     start = 0;
                     length = 2;
                 }

                 for(int i = 1; i < (s.Length - 1); i++ ) {

                     //this checks for an odd palindromic center, e.g. a[bcb]a
                     if(s[i-1].Equals(s[i+1])) {
                         distanceFromCenter = tryOddCenter(s, i);
                         
                         if(((2*distanceFromCenter) + 1)> length) {
                             start = i - distanceFromCenter;
                             length = (2*distanceFromCenter) + 1;
                         }
                         
                     }
                     
                     //checks for an even palindromic center, e.g. ab[cc]ba
                     if(s[i].Equals(s[i+1])){
                         distanceFromCenter = tryEvenCenter(s, i);

                         if(((distanceFromCenter * 2 ) + 2) > length) {
                             start = i - distanceFromCenter;
                             length = (2 * distanceFromCenter) + 2;
                         }
                     }

                 }
                 //added so that it compiles: REMOVE THIS 
                 return s.Substring(start, length);
             }
             else {
                 return s;
             }

         }

         public int tryOddCenter(string s, int i) {
              //algebra note: to do s[i-x, i+x], do
            //s.Substring(i-x, 2*x +1)

            int x = 1;
            

            while((i - x) >= 0 && (i+x) < s.Length ) {

                if(s[i-x].Equals(s[i+x])) {
                    x++;
                }
                else {
                    return x -1;
                }
            }

            return x-1;


         }

         public int tryEvenCenter(string s, int i) {
         
             int x = 1;

             while((i - x) >= 0 && (i + x + 1) < s.Length) {
                 
                 
                 //if one index to left of [two at center] == one index to riht of [two at center]
                 if(s[i-x].Equals(s[i+x+1])) {
                    x++;
                 }
                 else {
                     return x-1;
                 }
             }
             return x-1;
         }


     }
 } 