using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            TestTopologicalSorting();
            Console.ReadLine();
        }

        static void TestTopologicalSorting()
        {
            var graph = new Graph(6);
            graph.AddEdge(5, 2);
            graph.AddEdge(5, 0);
            graph.AddEdge(4, 0);
            graph.AddEdge(4, 1);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 1);

            var ret = graph.TopologicalSorting();
            foreach (var num in ret)
            {
                Console.Write(num + " ");
            }
        }
    }
}
