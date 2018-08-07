using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeSolutions
{
    public static class Problem154
    {
        static public int FindMin(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] > nums[i + 1])
                {
                    return nums[i + 1];
                }
            }
            return nums[0];
        }
    }
}
