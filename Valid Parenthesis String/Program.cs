using System;

namespace Valid_Parenthesis_String
{
  class Program
  {
    static void Main(string[] args)
    {
      string s = "(*)";
      Solution sol = new Solution();
      var result = sol.CheckValidString(s);
      Console.WriteLine(result);
    }
  }

  public class Solution
  {
    public bool CheckValidString(string s)
    {
      // When '(' we increment open by +1.
      // When '*' it can be  '(' OR ')', if we choose '(' we increment out left +1, when decrement -1 when choose ')'
      // When ')' we always decrement open by -1.


      // Base case, string can not start with close
      if (s[0] == ')') return false;

      int starConsideredAsOpen = 0;
      int starConsideredAsClose = 0;
      foreach (char c in s)
      {
        if (c == '(')
        {
          // When open , we increment out both variables
          starConsideredAsOpen += 1;
          starConsideredAsClose += 1;
        }
        else if (c == ')')
        {
          // When open , we increment out both variables
          starConsideredAsOpen -= 1;
          starConsideredAsClose -= 1;
        }
        else
        {
          // When * considered as open
          starConsideredAsOpen += 1;
          // When * considered as close
          starConsideredAsClose -= 1;
        }
        // Currently, don't have enough open parentheses to match close parentheses-> Invalid
        // For example: ())(
        if (starConsideredAsOpen < 0) return false;
        if (starConsideredAsClose < 0) starConsideredAsClose = 0;
      }

      return starConsideredAsClose == 0;
    }
  }
}
