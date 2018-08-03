using Xunit;
using Xunit.Abstractions;
using LeetCodeSolutions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCodeTests
{

    public class Problem135Test
    {
        [Fact]
        [Trait("Category", "Monotonic")]
        public void OnlyIncreasing1()
        {
            //Arrange
            int[] ratings = new int[] {1,2,3,4,5,6,7,8,9,10};
            int expected = 55;

            //Act
            int actual = Problem135.Candy(ratings);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        [Trait("Category", "Monotonic")]
        public void OnlyIncreasing2()
        {
            //Arrange
            int[] ratings = new int[] {1,2,3,3,3,3,4,5};
            int expected = 14;

            //Act
            int actual = Problem135.Candy(ratings);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        [Trait("Category", "Monotonic")]
        public void OnlyDecreasing1()
        {
            //Arrange
            int[] ratings = new int[] {10,9,8,7,6,5,4,3,2,1};
            int expected = 55;

            //Act
            int actual = Problem135.Candy(ratings);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        [Trait("Category", "Monotonic")]
        public void OnlyDecreasing2()
        {
            //Arrange
            int[] ratings = new int[] { 5,4,3,3,3,3,2,1};
            int expected = 14;

            //Act
            int actual = Problem135.Candy(ratings);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        [Trait("Category", "Alternating")]
        public void Alternating()
        {
            //Arrange
            int[] ratings = new int[] {1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1};
            int expected = 25;

            //Act
            int actual = Problem135.Candy(ratings);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        [Trait("Category", "Large Numbers")]
        public void LargeNumbers()
        {
            //Arrange
            int[] ratings = new int[] { 100000000, 200000000, 300000000, 400000000, 500000000, 600000000, 700000000, 800000000, 900000000, 1000000000 };
            int expected = 55;

            //Act
            int actual = Problem135.Candy(ratings);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        [Trait("Category", "All Equal")]
        public void AllEqual()
        {
            //Arrange
            int[] ratings = new int[] {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
            int expected = 30;

            //Act
            int actual = Problem135.Candy(ratings);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        [Trait("Category", "Alternating")]
        public void LongList()
        {
            //Arrange
            int[] ratings = new int[1000000];
            for (int i = 0; i < 1000000; i++)
            {
                ratings[i] = (i % 2 == 0) ? 1 : 2;
            }
            int expected = (1+2)*(1000000/2);

            //Act
            int actual = Problem135.Candy(ratings);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        [Trait("Category", "Monotonic")]
        public void LongIncreasing()
        {
            //Arrange
            int[] ratings = new int[32768];//2^15
            for (int i = 0; i < 32768; i++)
            {
                ratings[i] = i;
            }
            int expected = (32769 * 16384);

            //Act
            int actual = Problem135.Candy(ratings);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        [Trait("Category", "Bitonic")]
        public void DecreaseThenIncrease()
        {
            //Arrange
            int[] ratings = new int[] {5,4,3,2,1,2,3,4,5};
            int expected = 29;

            //Act
            int actual = Problem135.Candy(ratings);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        [Trait("Category", "Bitonic")]
        public void IncreaseThenDecrease()
        {
            //Arrange
            int[] ratings = new int[] { 5, 4, 3, 2, 1, 2, 3, 4, 5 };
            int expected = 29;

            //Act
            int actual = Problem135.Candy(ratings);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
