using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCodeSolutions
{
    public class Problem391
    {
        private int Area;
        private int[] xRange;
        private int[] yRange;
        private Dictionary<Tuple<int, int>, int> cornerCount;
        private int[,] Rectangles;
        private int numRectangles;

        public Problem391(int[,] RectanglesInit)
        {
            Area = 0;
            xRange = new int[] { RectanglesInit[0, 0], RectanglesInit[0, 2] };
            yRange = new int[] { RectanglesInit[0, 1], RectanglesInit[0, 3] };
            numRectangles = RectanglesInit.GetLength(0);

            Rectangles = new int[numRectangles, 4];
            Array.Copy(RectanglesInit, Rectangles, 4 * numRectangles);

            cornerCount = new Dictionary<Tuple<int, int>, int>();
        }

        public bool Solve()
        {
            ParseRectangles();
            return (CheckArea() && CheckCorners());
        }

        private void ParseRectangle(int x0, int y0, int x1, int y1)
        {
            xRange[0] = Math.Min(xRange[0], x0);
            xRange[1] = Math.Max(xRange[1], x1);
            yRange[0] = Math.Min(yRange[0], y0);
            yRange[1] = Math.Max(yRange[1], y1);
            Area += (x1 - x0) * (y1 - y0);

            IncrementDictionary(new Tuple<int, int>(x0, y0));
            IncrementDictionary(new Tuple<int, int>(x0, y1));
            IncrementDictionary(new Tuple<int, int>(x1, y0));
            IncrementDictionary(new Tuple<int, int>(x1, y1));
        }

        private void ParseRectangles()
        {
            for (int i = 0; i < numRectangles; i++)
            {
                int x0 = Rectangles[i, 0];
                int y0 = Rectangles[i, 1];
                int x1 = Rectangles[i, 2];
                int y1 = Rectangles[i, 3];

                ParseRectangle(x0, y0, x1, y1);
            }
        }

        private void IncrementDictionary(Tuple<int,int> corner)
        {
            if (cornerCount.ContainsKey(corner))
            {
                cornerCount[corner] += 1;
            }
            else
            {
                cornerCount.Add(corner, 1);
            }
        }

        private bool CheckArea()
        {
            return (Area == ((xRange[1] - xRange[0])*(yRange[1] - yRange[0])));
        }

        private bool CheckCorners()
        {
            //Should have the four most extreme corners appeared once, all other corners an even number of times 
            int[] count = new int[4];
            cornerCount.TryGetValue(new Tuple<int, int>(xRange[0], yRange[0]), out count[0]);
            cornerCount.TryGetValue(new Tuple<int, int>(xRange[0], yRange[1]), out count[1]);
            cornerCount.TryGetValue(new Tuple<int, int>(xRange[1], yRange[0]), out count[2]);
            cornerCount.TryGetValue(new Tuple<int, int>(xRange[1], yRange[1]), out count[3]);

            if (count[0] != 1 || count[1] != 1 || count[2] != 1 || count[3] != 1)
            {
                return false;
            }

            int singleCorners = 0;
            foreach (KeyValuePair<Tuple<int,int>, int> kvp in cornerCount){
                if (kvp.Value == 1)
                {
                    singleCorners += 1;
                }
                else if (kvp.Value != 2 && kvp.Value != 4)
                {
                    return false;
                }
            }
            return singleCorners == 4;
            
        }
    }
}
