using System.Collections.Generic;
using System.Linq;

namespace Library {

public class LFUCache {

    public Dictionary<int, int> values { get; set; }
    public Dictionary<int, int> accessCounts {get; set;}
    public int capacity { get; set; }

    public LFUCache(int capacity) {
        values = new Dictionary<int, int>(capacity);
        accessCounts = new Dictionary<int, int>(capacity);
        this.capacity = capacity;
    }

    public int get(int key) {
        if(values.ContainsKey(key)){
            accessCounts[key] = accessCounts[key] + 1;
            return values[key];
        }
        else {
            return -1;
        }
    }

    public void set(int key, int val) {
        if(values.Count >= capacity) {
            int keyToRemove;

            //this loops over entire collection and returns the key which corresponds to the least
            //accessed value. in the case of a tie, the least recently 
            keyToRemove = accessCounts.Aggregate((k1, k2) => k1.Value > k2.Value ? k2 : k1).Key;
            values.Remove(keyToRemove);
            accessCounts.Remove(keyToRemove);
            values[key] = val;
            accessCounts[key] = 0;
        }
        else {
            values[key] = val;
            accessCounts[key] = 0;
        }

    }

}

}