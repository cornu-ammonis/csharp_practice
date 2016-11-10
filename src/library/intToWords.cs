using System;
using System.Collections.Generic;

namespace Library {
 
    public class IntToWords {

        public string NumberToWords(int num) {
        
        if(num == 0) {
            return "Zero";
        }
        int digits = numDigits(num);
        
        string s = "";
        if(digits == 10){
            s = s + oneToWord(num/1000000000) + " Billion";
            num = num%1000000000;
            digits = digits - 1;
        }
        //return s + " " + num.ToString();

        if(digits > 6 && digits <= 9) {
            int millions = num/1000000;
            if(millions == 0) {
                num = num%1000000;
                digits = digits - 3;
            }
            else {
                s = s + threeToWords(millions) + " Million";
                num = num%1000000;
                digits = digits - 3;
            }
           
        }
        if(digits > 3 && digits <=6) {
            int thousands = num/1000;
            if(thousands == 0) {
                num = num%1000;
                digits = digits - 3;
            }
            else {
                s = s + threeToWords(thousands) + " Thousand";
                num = num%1000;
                digits = digits - 3;
            }
            
        }
        if(digits == 3) {
            int hundreds = num/100;
            if(hundreds == 0) {
                num = num%100;
                digits = digits - 1;
            }
            else {
                s = s + " " + oneToWord(hundreds) + " Hundred";
                num = num%100;
                digits = digits - 1;
            }
            
        }
        if(digits < 3) {
            s = s + threeToWords(num);
        }
        if(s[0] == ' ') {
            return s.Substring(1);
        }
        return s;
        
     }




        public string threeToWords(int num) {
             int digits = numDigits(num);
             if(digits > 3) {
                 throw new InvalidOperationException("Error: more than three digits");
             }
             string sholder = "";
             int iholder;

             if(digits == 3){
                 sholder = sholder + " " + oneToWord(num/100) + " Hundred";
                 num = num%100;
                 digits = numDigits(num);
             }
             if(digits == 2){
                 iholder = num/10;
                 switch(iholder){
                    case 0:
                        break;
                    case 1:
                        sholder = sholder + tensToWord(num);
                        return sholder;
                    case 2:
                        sholder = sholder + " Twenty";
                        break;
                    case 3:
                        sholder = sholder + " Thirty";
                        break;
                    case 4:
                        sholder = sholder + " Forty";
                        break;
                    case 5:
                        sholder = sholder + " Fifty";
                        break;
                    case 6:
                        sholder = sholder + " Sixty";
                        break;
                    case 7:
                        sholder = sholder + " Seventy";
                        break;
                    case 8:
                        sholder = sholder + " Eighty";
                        break;
                    case 9:
                        sholder = sholder + " Ninety";
                        break;
                    
                     
                 }
                 
                 num = num%10;
                 digits = numDigits(num);
             }
             if (digits == 1) {
                 sholder = sholder + " " + oneToWord(num);
             }

             return sholder;
        }

        public string oneToWord(int num) {
            if(numDigits(num) > 1) {
                throw new InvalidOperationException("Error: more than one digit");
            }
            switch(num) {
                case 0:
                    return "";
                case 1:
                    return "One";
                case 2:
                    return "Two";
                case 3:
                    return "Three";
                case 4:
                    return "Four";
                case 5:
                    return "Five";
                case 6:
                    return "Six";
                case 7:
                    return "Seven";
                case 8:
                    return "Eight";
                case 9:
                    return "Nine";
                

            }
            return "Error";
        }

        public string tensToWord(int num) {
            switch(num) {
                case 10:
                    return " Ten";
                case 11:
                    return " Eleven";
                case 12:
                    return " Twelve";
                case 13:
                    return " Thirteen";
                case 14:
                    return " Fourteen";
                case 15:
                    return " Fifteen";
                case 16:
                    return " Sixteen";
                case 17:
                    return " Seventeen";
                case 18:
                    return " Eighteen";
                case 19:
                    return " Nineteen";
                    
            }
            return "Error";
        }

        public int numDigits(int num) {
            int count = 0;
            while(num > 0) {
                num = num/10;
                count = count + 1;
                
            }
            return count;
        }

    }
}