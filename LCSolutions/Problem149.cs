using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeSolutions
{
    public class Point
    {
        public int x;
        public int y;
        public Point() { x = 0; y = 0; }
        public Point(int a, int b) { x = a; y = b; }

        public override bool Equals(object obj)
        {
            Point k = (Point) obj;
            return (k.x == this.x)&&(k.y == this.y);
        }

        public override int GetHashCode()
        {
            return Tuple.Create(x,y).GetHashCode();
        }
    }


    public static class Problem149
    {
        public static int HCF(int a, int b)
        {
            if (a == 0)
            {
                return b;
            }
            if (b == 0)
            {
                return a;
            }
            if (a > b)
            {
                return HCF(b, a);
            }
            else if (b%a == 0)
            {
                return a;
            }
            else
            {
                return HCF(b % a, a);
            }

        }


        public static int MaxPoints(Point[] points)
        {
            Dictionary<Point, int> repeatPoints = new Dictionary<Point, int> { };
            Dictionary<Tuple<int,int,int>, HashSet<Point>> Lines = new Dictionary<Tuple<int,int,int>, HashSet<Point>> { };
            
            for (int i = 0; i < points.Length; i++)
            {
                Point currentPoint = points[i];
                if (repeatPoints.ContainsKey(currentPoint))
                {
                    repeatPoints[currentPoint]++;
                }
                else
                {
                    repeatPoints.Add(currentPoint, 1);
                }
            }

            if (repeatPoints.Count < 2)
            {
                return points.Length;
                //Either no points, or all points are the same
            }

            foreach(KeyValuePair<Point,int> kvp1 in repeatPoints)
            {
                foreach(KeyValuePair<Point, int> kvp2 in repeatPoints)
                {
                    if (kvp1.Key == kvp2.Key)
                    {
                        continue;
                    }

                    //Look at each pair of points (ignoring duplicates)
                    int numer = kvp1.Key.x - kvp2.Key.x;
                    int denom = kvp2.Key.y - kvp1.Key.y;
                    int hcf = HCF(Math.Abs(numer), Math.Abs(denom));
                    int a = numer / hcf;
                    int b = denom / hcf;
                    int c = ((kvp1.Key.x * kvp2.Key.y) - (kvp1.Key.y * kvp2.Key.x)) / hcf;
                    Tuple<int,int,int> newLine = Tuple.Create(a,b,c);
                    if (!Lines.ContainsKey(newLine))
                    {
                        Lines.Add(newLine, new HashSet<Point> {kvp1.Key, kvp2.Key});
                    }
                    else
                    {
                        Lines[newLine].Add(kvp1.Key);
                        Lines[newLine].Add(kvp2.Key);
                    }
                }
            }

            int result = 0;
            
            foreach(KeyValuePair<Tuple<int,int,int>, HashSet<Point>> kvp in Lines)
            {
                int internalResult = 0;
                foreach(Point pt in kvp.Value)
                {
                    internalResult += repeatPoints[pt];
                }

                result = Math.Max(result, internalResult);
            }
            

            return result;
        }
    }
}
