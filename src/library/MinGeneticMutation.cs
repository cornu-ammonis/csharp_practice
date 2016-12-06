using System.Linq;
using System.Text;

using System.Collections.Generic;

namespace Library {



    public class MinGeneticMutation{
        /* from https://leetcode.com/problems/minimum-genetic-mutation/
        
 problem description:
A gene string can be represented by an 8-character long string, with choices from "A", "C", "G", "T".

Suppose we need to investigate about a mutation (mutation from "start" to "end"), where ONE mutation is defined as ONE single character changed in 
the gene string.

For example, "AACCGGTT" -> "AACCGGTA" is 1 mutation.

Also, there is a given gene "bank", which records all the valid gene mutations. A gene must be in the bank to make it a valid gene string.

Now, given 3 things - start, end, bank, your task is to determine what is the minimum number of mutations needed to mutate from "start" to "end". 
If there is no such a mutation, return -1.

Note:

Starting point is assumed to be valid, so it might not be included in the bank.
If multiple mutations are needed, all mutations during in the sequence must be valid.
You may assume start and end string is not the same.

        */
        

       

        public int MinMutation(string start, string end, string[] bank) {

        }


        public List<int> findDifferingIndexes(string goal, string current) {

            List<int> differenceIndexes = new List<int>();

            for(int i = 0; i < 8; i++) {
                if(!goal[i].Equals(current[i])) {
                    differenceIndexes.Add(i);
                }
            }

            return differenceIndexes;
        }

    }

}