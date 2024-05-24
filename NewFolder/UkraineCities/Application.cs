using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UkraineCities
{
    interface IShortestPath
    {
        public (List<string> path, decimal totalDistance) FindShortestPath(string start, string end);
    }

    internal class ShortestPath : IShortestPath
    {
        City[] cities;

        public ShortestPath()
        {
            cities = CityData.GetCities();
        }

        public (List<string> path, decimal totalDistance) FindShortestPath(string start, string end)
        {
            var shortestPaths = new Dictionary<string, (decimal distance, string previous)>();
            var priorityQueue = new SortedSet<(decimal distance, string city)>();

            foreach (var city in cities)
            {
                shortestPaths[city.Name] = (int.MaxValue, null);
            }

            shortestPaths[start] = (0, null);
            priorityQueue.Add((0, start));

            while (priorityQueue.Any())
            {
                var (currentDistance, currentCity) = priorityQueue.Min();
                priorityQueue.Remove(priorityQueue.Min());

                if (currentCity == end)
                {
                    break;
                }

                foreach (var neighbor in City.FindCity(currentCity).neighbors)
                {
                    var neighborName = neighbor.Key;
                    var neighborDistance = neighbor.Value;
                    var newDistance = currentDistance + neighborDistance;
                    if (newDistance < shortestPaths[neighborName].distance)
                    {
                        priorityQueue.Remove((shortestPaths[neighborName].distance, neighborName));
                        shortestPaths[neighborName] = (newDistance, currentCity);
                        priorityQueue.Add((newDistance, neighborName));
                    }
                }
            }

            var path = new List<string>();
            var step = end;
            decimal totalDistance = shortestPaths[end].distance;

            while (step != null)
            {
                path.Add(step);
                step = shortestPaths[step].previous;
            }

            path.Reverse();
            return (path, totalDistance);
        }
    }

    class InputData
    {
        public static string[] InputCities()
        {
            string startCity;
            string endCity;

            City.PrintCities();

            do
            {
                Console.Write("\nEnter the start city: ");
                startCity = Console.ReadLine();

                if (!City.ContainsCity(startCity))
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
            while (!City.ContainsCity(startCity));

            do
            {
                Console.Write("\nEnter the end city: ");
                endCity = Console.ReadLine();

                if (!City.ContainsCity(endCity))
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
            while (!City.ContainsCity(endCity));

            Console.Clear();

            return [startCity, endCity];
        }
    }
}
