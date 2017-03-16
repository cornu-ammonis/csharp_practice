// Problem from leetcode -- given a string, determine if it is a valid IPv4 or IPv6 address

//TODO: implement this solution using REGEX
namespace Library {
    using System;
public class IPValidation {

//recursively determines whether the remaining character sequence is 
public string isValidIPv4(string ip) {

        //base case -- if we reach the end of string without finding an invalid characteristic it passes
        if (ip.Length == 0)
            return "IPv4";
        
        //leading zeros are invalid, zero may only appear first if it is alone
        if(ip[0].Equals('0') && (ip.Length > 1 && !ip[1].Equals('.')))
            return "Neither";
        int i = 0;

        //finds index of next group of characters delimited by '.'
        while(i < ip.Length && !ip[i].Equals('.')) 
            i++;
        
       
        string sub = ip.Substring(0, i);
    //  Console.WriteLine(sub); //print statement for debugging
        int num; 
        if (!Int32.TryParse(sub, out num)) // if this returns false its not a valid number
            return "Neither";
        
      
        //valid number range
        if(num >= 0 && num <= 255)
            return isValidIPv4(ip.Substring(i)); //recursive call starting at either the '.' or end of string
        else
            return "Neither";
}
    //recursively determines if valid IPv6 address
    public string isValidIPv6(string ip) {
    if(ip.Length == 0)  //base case - reached end of string without invalidating characteristic
        return "IPv6";

    //determines end index of substring containing hex character deliminted by : or end of string
    int i = 0;
    while(i < ip.Length && !ip[i].Equals(':')) 
        i++;
    
    
    string sub = ip.Substring(0, i);
    Console.WriteLine(sub);
    
    //special cases if hex length isnt 4
    if(sub.Length != 4){
        if (sub.Length == 0 || sub.Length > 4)
            return "Neither";
        if(sub[0] == '0')
            return (i == ip.Length) ? "IPv6" : isValidIPv6(ip.Substring(i+1));
        else{
            long outVar;  

        //determines if the substring is a valid hex character
        //TODO: replace this with a regular expression
        if(!long.TryParse(sub, System.Globalization.NumberStyles.HexNumber, null, out outVar))
            return "Neither";
        return (i == ip.Length) ? "IPv6" : isValidIPv6(ip.Substring(i+1));
        }
    } //end 4 length if
     
    //determines if the substring is a valid hex character
    //TODO: replace this with a regular expression
    long uselessHolder;  
    if(!long.TryParse(sub, System.Globalization.NumberStyles.HexNumber, null, out uselessHolder))
        return "Neither";
    return (i == ip.Length) ? "IPv6" : isValidIPv6(ip.Substring(i+1));
    
    }
    
    
    public string ValidIPAddress(string IP) {
        
        //means it contains a negative number
        if(IP.Contains("-"))
            return "Neither";
        
        
        //these counters and the following loop verify there are the correct number of 
        //periods or colons, and that there is only one or the other
        int periodCount = 0;
        int colonCount = 0;
        for (int i = 0; i < IP.Length; i++){
            
            if(IP[i].Equals('.'))
                periodCount++;
            
            if(IP[i].Equals(':'))
                colonCount++;
        }
        
        //must have one and only one of: 3 periods, 7 colons. if not, return neither.
        if(!(periodCount == 3 ^ colonCount == 7))
            return "Neither";

        //finds whether its IPv4 or IPv6
        //TODO: eliminate redundant loop and implement this with the counters
        for(int i = 0; i < IP.Length; i++) {
            if(IP[i].Equals('.')) {
                if(IP[0].Equals('.') || IP[IP.Length - 1].Equals('.'))
                    return "Neither";
                else  
                    return isValidIPv4(IP);
                
            }
            else if (IP[i].Equals(':')) {
                if(IP[0].Equals(':') || IP[IP.Length - 1].Equals(':'))
                    return "Neither";
                else
                    return isValidIPv6(IP);
                
            }
            
        }

        
        return "Neither";
        
    }
       
    
        
    }

}

