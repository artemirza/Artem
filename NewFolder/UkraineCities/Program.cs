using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UkraineCities;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("-------First route-------");
        string[] StartAndEndCities1 = InputData.InputCities(); 

        Console.WriteLine("-------Second route-------");
        string[] StartAndEndCities2 = InputData.InputCities();

        ShortestPath sp = new ShortestPath();

        var thread1 = new Thread(() =>
        {
            var (shortestPath, totalDistance) = sp.FindShortestPath(StartAndEndCities1[0], StartAndEndCities1[1]);
            Console.WriteLine($"Tread {Thread.CurrentThread.ManagedThreadId} is working on {StartAndEndCities1[0]} to {StartAndEndCities1[1]}");
            Console.WriteLine("\nShortest route from {0} to {1}: {2}", StartAndEndCities1[0], StartAndEndCities1[1], string.Join(" -> ", shortestPath));
            Console.WriteLine($"\nTotal shortest distance is {totalDistance} KM");
        });

        var thread2 = new Thread(() =>
        {
            var (shortestPath, totalDistance) = sp.FindShortestPath(StartAndEndCities2[0], StartAndEndCities2[1]);
            Console.WriteLine($"Tread {Thread.CurrentThread.ManagedThreadId} is working on {StartAndEndCities2[0]} to {StartAndEndCities2[1]}");
            Console.WriteLine("\nShortest route from {0} to {1}: {2}", StartAndEndCities2[0], StartAndEndCities2[1], string.Join(" -> ", shortestPath));
            Console.WriteLine($"\nTotal shortest distance is {totalDistance} KM");
        });

        thread1.Start();
        thread2.Start();

        thread1.Join(); 
        thread2.Join(); 


    }
}   