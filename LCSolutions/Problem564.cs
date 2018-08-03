using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCodeSolutions
{
    public static class Problem564
    {
        public static string NearestPalindromic(string n)
        {

            //From Definition: <= 18 digits, > 0

            if (n.Length == 1)
            {
                //n = 1,2,...9
                // Return n-1

                return (long.Parse(n) - 1).ToString();
            }
            else if(n.Sum(c => c - '0') == 1)
            {
                // n = 100000....000
                // Return 999...999
                return (long.Parse(n) - 1).ToString();
            }
            else if ((long.Parse(n) + 1).ToString().Sum(c => c - '0') == 1)
            {
                // n = 999.999
                // Return 100...001
                return (long.Parse(n) + 2).ToString();
            }
            else if ((long.Parse(n) - 1).ToString().Sum(c => c - '0') == 1)
            {
                // n = 999.999
                // Return 100...001
                return (long.Parse(n) - 2).ToString();
            }
            else
            {
                int numDigits = n.Length;
                string candidate1 = n;
                string candidate2 = n;
                string candidate3 = n;

                string toWrite1 = n.Substring(0, (numDigits + 1) / 2);
                string toWrite2 = (long.Parse(toWrite1) - 1).ToString();
                string toWrite3 = (long.Parse(toWrite1) + 1).ToString();

                for (int ii = 0; ii < (numDigits + 1)/2; ii++)
                {
                    char[] tmp1 = candidate1.ToCharArray();
                    tmp1[numDigits - 1 - ii] = toWrite1[ii];
                    tmp1[ii] = toWrite1[ii];
                    candidate1 = new string(tmp1);

                    char[] tmp2 = candidate2.ToCharArray();
                    tmp2[numDigits - 1 - ii] = toWrite2[ii];
                    tmp2[ii] = toWrite2[ii];
                    candidate2 = new string(tmp2);

                    char[] tmp3 = candidate3.ToCharArray();
                    tmp3[numDigits - 1 - ii] = toWrite3[ii];
                    tmp3[ii] = toWrite3[ii];
                    candidate3 = new string(tmp3);
                }

                long dist1 = Math.Abs(long.Parse(n) - long.Parse(candidate1));
                long dist2 = Math.Abs(long.Parse(n) - long.Parse(candidate2));
                long dist3 = Math.Abs(long.Parse(n) - long.Parse(candidate3));

                if (dist1 == 0)
                {
                    return (dist3 < dist2) ? candidate3 : candidate2;
                }
                else if (dist2 <= dist1 && dist2 <= dist3)
                {
                    return candidate2;
                }
                else if (dist1 <= dist3)
                {
                    return candidate1;
                }
                else
                {
                    return candidate3;
                }
            }
            
        }
    }
}
