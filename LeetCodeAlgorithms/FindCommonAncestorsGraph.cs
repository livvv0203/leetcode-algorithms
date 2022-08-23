using System;
using System.Collections.Generic;
using System.Linq;
/*
Suppose we have some input data describing a graph of relationships between parents and children over multiple generations. The data is formatted as a list of (parent, child) pairs, where each individual is assigned a unique integer identifier.

For example, in this diagram, 6 and 8 have a common ancestor of 4.

         14  13
         |   |
1   2    4   12
 \ /   / | \ /
  3   5  8  9
   \ / \     \
    6   7     11

pair = [
    (1, 3), (2, 3), (3, 6), (5, 6), (5, 7), (4, 5),
    (4, 8), (4, 9), (9, 11), (14, 4), (13, 12), (12, 9)
]

Write a function that takes the graph, as well as two of the individuals in our dataset, as its inputs and returns true if and only if they share at least one ancestor.

Sample input and output:

hasCommonAncestor(pairs, 3, 8) => false
hasCommonAncestor(pairs, 5, 8) => true
hasCommonAncestor(pairs, 6, 8) => true
hasCommonAncestor(pairs, 6, 9) => true
hasCommonAncestor(pairs, 1, 3) => false
hasCommonAncestor(pairs, 7, 11) => true
hasCommonAncestor(pairs, 6, 5) => true
hasCommonAncestor(pairs, 5, 6) => true
*/
namespace LeetcodeAlgorithms
{
    /// <summary>
    /// Node class
    /// </summary>
    public class Node
    {
        private int data;
        private List<Node> parents = new List<Node>();

        // getters
        public int Data => data;
        public List<Node> Parents => parents;
        // constructor
        public Node(int newData)
        {
            this.data = newData;
        }

        public override string ToString()
        {
            string r = "Node Data: " + data.ToString() + "  ------>  Node Parents: ";

            foreach (var p in parents)
            {
                r += " " + p.data.ToString();
            }
            return r;
        }
    }

    /// <summary>
    /// Solution class
    /// </summary>
    public class FindCommonAncestorsGraph
    {
        // a graph is a list of nodes
        List<Node> graph = new List<Node>(); 

        public void CreateGraph(List<int[]> pairs)
        {
            foreach (var p in pairs)
            {
                Node node = graph.FirstOrDefault<Node>(n => n.Data == p[1]); // int[]{1,3} - parent,child

                if (node == null)
                {
                    node = new Node(p[1]); // Create a new Node
                    graph.Add(node);
                }

                Node parentNode = graph.FirstOrDefault<Node>(n => n.Data == p[0]);

               if (parentNode == null)
                {
                    parentNode = new Node(p[0]);
                    graph.Add(parentNode);
                }

                node.Parents.Add(parentNode);
            }   

            // Output all nodes in graph
            foreach (var item in graph)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("------------------");
        }

        private List<Node> GetAllAncestorsOfNode(int nodeValue)
        {
            // get target node by value 
            var targetNode = graph.FirstOrDefault(n => n.Data == nodeValue);

            List<Node> allAncestorsOfNode = new List<Node>();

            foreach (var p in targetNode.Parents)
            {
                if (allAncestorsOfNode.Contains(p)) continue;
                allAncestorsOfNode.Add(p);
                allAncestorsOfNode.AddRange(GetAllAncestorsOfNode(p.Data));
            }

            return allAncestorsOfNode;        
        }

        public bool HasCommonAncestor(int firstValue, int secondValue)
        {
            var allAncestorsFirstValue = GetAllAncestorsOfNode(firstValue);
            var allAncestorsSecondValue = GetAllAncestorsOfNode(secondValue);

            return allAncestorsFirstValue.Intersect(allAncestorsSecondValue).Count() > 0; 
        }
    }
}





