

namespace Library {
    using System;
public class IPValidation {

public string isValidIPv4(string ip) {
        if (ip.Length == 0)
            return "IPv4";
        if(ip[0].Equals('0') && (ip.Length > 1 && !ip[1].Equals('.')))
            return "Neither";
        int i = 0;
        while(i < ip.Length && !ip[i].Equals('.')) 
            i++;
        
       // i = (i >= ip.Length) ? ip.Length : i;
        string sub = ip.Substring(0, i);
        Console.WriteLine(sub);
        int num; 
        if (!Int32.TryParse(sub, out num))
            return "Neither";
        
      
        
        if(num >= 0 && num <= 255)
            return (i == ip.Length) ? "IPv4" : isValidIPv4(ip.Substring(i+1));
        else
            return "Neither";
}
    
    public string isValidIPv6(string ip) {
    if(ip.Length == 0)
        return "IPv6";

    int i = 0;
    while(i < ip.Length && !ip[i].Equals(':'))
        i++;
    
    
    string sub = ip.Substring(0, i);
    Console.WriteLine(sub);
    
    
    if(sub.Length != 4){
        if (sub.Length == 0 || sub.Length > 4)
            return "Neither";
        if(sub[0] == '0')
            return (i == ip.Length) ? "IPv6" : isValidIPv6(ip.Substring(i+1));
        else{
            long uselessHolder2;  
        if(!long.TryParse(sub, System.Globalization.NumberStyles.HexNumber, null, out uselessHolder2))
            return "Neither";
        return (i == ip.Length) ? "IPv6" : isValidIPv6(ip.Substring(i+1));
        }
            
         
        
    }
     
    long uselessHolder;  
        if(!long.TryParse(sub, System.Globalization.NumberStyles.HexNumber, null, out uselessHolder))
            return "Neither";
        return (i == ip.Length) ? "IPv6" : isValidIPv6(ip.Substring(i+1));
    
    }
    
    
    public string ValidIPAddress(string IP) {
        
        if(IP.Contains("-"))
            return "Neither";
        int periodCount = 0;
        int colonCount = 0;
        
        for (int i = 0; i < IP.Length; i++){
            if(IP[i].Equals('.'))
                periodCount++;
            
            if(IP[i].Equals(':'))
                colonCount++;
        }
        
        if(!(periodCount == 3 ^ colonCount == 7))
            return "Neither";
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

