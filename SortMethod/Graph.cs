using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortMethod
{
    /// <summary>
    /// 拓扑排序
    /// 
    /// （1）介绍
    /// 拓扑排序（Topological Sorting）是一个有向无环图（DAG, Directed Acyclic Graph）的所有顶点的线性序列。且该序列必须满足下面两个条件：
    /// 
    /// 每个顶点出现且只出现一次。
    /// 若存在一条从顶点 A 到顶点 B 的路径，那么在序列中顶点 A 出现在顶点 B 的前面。
    /// 有向无环图（DAG）才有拓扑排序，非DAG图没有拓扑排序一说。
    /// 
    /// 
    /// （2）实现（如何得出拓扑排序）：
    /// 一、从 DAG 图中选择一个 没有前驱（即入度为0）的顶点并输出。
    /// 二、从图中删除该顶点和所有以它为起点的有向边。
    /// 三、重复 1 和 2 直到当前的 DAG 图为空或当前图中不存在无前驱的顶点为止。后一种情况说明有向图中必然存在环。
    /// 
    /// （3）应用：
    /// 拓扑排序通常被用来“排序”具有依赖关系的任务
    /// </summary>
    public class Graph
    {
        public Graph(int vNum)
        {
            v = vNum;
            adj = new List<List<int>>();
            for (int i = 0; i < vNum; ++i)
                adj.Add(new List<int>());
        }

        /// <summary>
        /// 得到一个拓扑排序序列
        /// </summary>
        public List<int> TopologicalSorting()
        {
            var ret = new List<int>();
            var queue = new Queue<int>();//入度为0的队列
            var indegree = new List<int>();//入度集合
            for (int i = 0; i < v; ++i)
            {
                indegree.Add(0);
            }

            for (int i = 0; i < v; ++i)
            {
                foreach (var p in adj[i])
                {
                    indegree[p]++;
                }
            }

            // 初始化入度为0的集合
            for (int i = 0; i < indegree.Count; ++i)
            {
                if (indegree[i] == 0)
                {
                    queue.Enqueue(i);
                }
            }

            while (queue.Count != 0)
            {
                int curV = queue.Dequeue();
                ret.Add(curV);
                foreach (var p in adj[curV])
                {
                    --indegree[p];
                    if (indegree[p] == 0)
                    {
                        queue.Enqueue(p);
                    }
                }
            }

            if (ret.Count != v)
            {
                return new List<int>();
            }
            else
            {
                return ret;
            }
        }

        /// <summary>
        /// 添加一条从顶点p到q的边
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        public void AddEdge(int p, int q)
        {
            adj[p].Add(q);
        }

        int v;//顶点个数
        List<List<int>> adj;//邻接表
    }
}
