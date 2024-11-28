using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Task1();
        Task2();
    }

    // 1. создать List на 64 элемента, скачать из интернета 32 пары картинок (любых).
    static void Task1()
    {
        List<string> images = new List<string>();
        string imagesWay = @"C:\Desktop\фото\"; 
        for (int i = 0; i < 32; i++) 
        {
            string imagePath = Path.Combine(imagesWay, $"image{i}.jpeg");
            images.Add(imagePath);
            images.Add(imagePath); 
        }

        Console.WriteLine("обычный список:");
        for (int i = 0; i < images.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {images[i]}");
        }

        Random photo = new Random();
        images = images.OrderBy(a => photo.Next()).ToList();

        Console.WriteLine("перемешанный список:");
        for (int i = 0; i < images.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {images[i]}");
        }
    }

    // 2. Написать метод для обхода графа в глубину или ширину - вывести на экран кратчайший путь.
    static void Task2()
    {
        Graph graf = new Graph();
        graf.AddEdge(1, 2);
        graf.AddEdge(1, 3);
        graf.AddEdge(2, 4);
        graf.AddEdge(3, 5);
        graf.AddEdge(4, 5);
        graf.AddEdge(5, 6);
        graf.AddEdge(2, 6);

        int start = 1;
        int end = 6;

        var shortWay = graf.BFS(start, end);
        if (shortWay != null)
        {
            Console.WriteLine($"короткий путь: {string.Join(" > ", shortWay)}"); 
        }
        else
        {
            Console.WriteLine("нет пути");
        }
    }
}
public class Graph
{
    private Dictionary<int, List<int>> aList;

    public Graph()
    {
        aList = new Dictionary<int, List<int>>();
    }

    public void AddEdge(int vay1, int vay2)
    {
        if (!aList.ContainsKey(vay1))
        {
            aList[vay1] = new List<int>();
        }
        if (!aList.ContainsKey(vay2))
        {
            aList[vay2] = new List<int>();
        }

        aList[vay1].Add(vay2);
        aList[vay2].Add(vay1); 
    }

    public List<int> BFS(int start, int end)
    {
        Queue<int> queue = new Queue<int>();
        Dictionary<int, int> theWays = new Dictionary<int, int>();
        HashSet<int> was = new HashSet<int>();

        queue.Enqueue(start);
        was.Add(start);

        while (queue.Count > 0)
        {
            int that = queue.Dequeue();

            if (that == end)
            {
                return GetPath(theWays, start, end);
            }

            foreach (int next in aList[that])
            {
                if (!was.Contains(next))
                {
                    was.Add(next);
                    theWays[next] = that;
                    queue.Enqueue(next);
                }
            }
        }

        return null; 
    }

    private List<int> GetPath(Dictionary<int, int> parents, int start, int end)
    {
        List<int> path = new List<int>();
        for (int at = end; at != start; at = parents[at])
        {
            path.Add(at);
        }
        path.Add(start);
        path.Reverse();
        return path;
    }
}