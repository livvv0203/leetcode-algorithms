using System;

namespace LeetcodeAlgorithms
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Parent-child Pairs
            var pairs = new List<int[]>
            {
                new int[]{1, 3}, // 1 is parent, 3 is child
                new int[]{2, 3},
                new int[]{3, 6},
                new int[]{5, 6},
                new int[]{5, 7},
                new int[]{4, 5},
                new int[]{4, 8},
                new int[]{4, 9},
                new int[]{9, 11},
                new int[]{14, 4},
                new int[]{13, 12},
                new int[]{12, 9},
            };

            var f = new FindCommonAncestorsGraph();
            f.CreateGraph(pairs);
            bool result = f.HasCommonAncestor(6, 7);
            Console.WriteLine(result);

           
        }
    }
}











