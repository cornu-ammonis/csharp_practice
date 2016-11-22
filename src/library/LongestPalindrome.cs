 namespace Library {

     public class LongestPalindromicSubstring {

         public string LongestPalindrome(string s) {

             return ReverseString(s);
        
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