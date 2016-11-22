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

                for(int i = 1; i < s.Length - 1; i++) {
                    if(s[i].Equals(s[i+1])) {
                        temp = TryEvenCenter(s, i);
                        ans = (temp.Length > ans.Length) ? temp : ans;
                    }
                    
                    if(s[i-1].Equals(s[i+1])) {
                        temp = TryOddCenter(s, i);
                        ans = (temp.Length > ans.Length) ? temp : ans;
                    }
                }

                return ans;
              }
              else {
                  return ans;
              }
          }

        public string TryEvenCenter(string s, int i) {
            int x = 1;
            
            // s[i, j] -> s.Substring(i, (j-i)+1))
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

        public string TryOddCenter(string s) {
            return null;
        }

         public string ReverseString (string s) {
             string reversed = "";

             for(int i = s.Length - 1; i >= 0; i--) {
                 reversed += s[i];
             }
             return reversed;
         }
     }
 } 