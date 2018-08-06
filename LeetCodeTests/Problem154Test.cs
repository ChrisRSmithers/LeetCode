using Xunit;
using Xunit.Abstractions;
using LeetCodeSolutions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCodeTests
{
    public class Problem154Test
    {
        [Fact]
        public void Sorted()
        {
            //Arrange
            int[] nums = new int[] {1,2,3,4,5,6,7 };
            int expected = 1;

            //Act
            int actual = Problem154.FindMin(nums);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SortedRepeated()
        {
            //Arrange
            int[] nums = new int[] { 1,1,1,1,1,1,1,1, 2, 3, 4, 5, 6, 7 };
            int expected = 1;

            //Act
            int actual = Problem154.FindMin(nums);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AllRepeated()
        {
            //Arrange
            int[] nums = new int[] {999,999,999,999,999,999,999,999,999,999};
            int expected = 999;

            //Act
            int actual = Problem154.FindMin(nums);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NormalPivot()
        {
            //Arrange
            int[] nums = new int[] { 5,6,7,8,9,10,0,1,2,3,4};
            int expected = 0;

            //Act
            int actual = Problem154.FindMin(nums);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LongTest()
        {
            //Arrange
            int[] nums = new int[100000];
            for (int i = 0; i < 100000; i++)
            {
                nums[i] = (i + 50000) % 100000;
            }

            int expected = 0;

            //Act
            int actual = Problem154.FindMin(nums);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
