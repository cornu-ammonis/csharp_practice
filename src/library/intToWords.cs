using System;
using System.Collections.Generic;

namespace Library {
 
    public class IntToWords {

        public string threeToWords(int num) {
             int digits = numDigits(num);
             if(digits > 3) {
                 throw new InvalidOperationException("Error: more than three digits");
             }
             string sholder = "";
             int iholder;

             if(digits == 3){
                 sholder = sholder + oneToWord(num/100) + " Hundred";
                 num = num%100;
                 digits = numDigits(num);
             }
             if(digits == 2){
                 iholder = num/10;
                 switch(iholder){
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        sholder = sholder + " Twenty";
                        break;
                    case 3:
                        sholder = sholder + " Thirty";
                        break;
                    case 4:
                        sholder = sholder + " Fourty";
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