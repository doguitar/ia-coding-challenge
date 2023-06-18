using iACodingChallenge.Library;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace iACodingChallenge.Console;


class Program
{
    static readonly ushort QuadrantSize = 10;
    static readonly uint FacilityCount = (uint)(QuadrantSize * 2 + 1) ^ 2 / 10;
    static readonly byte MedicationCount = 3;

    static readonly char CapitalA = 'A';

    static void Main(string[] args)
    {
        #region generate data

        var map = new Map(QuadrantSize);

        Random rand = new Random();
        var coordinates = new HashSet<Coordinate>();

        while (coordinates.Count < FacilityCount)
        {
            coordinates.Add(
                new Coordinate(
                    (short)rand.Next(-QuadrantSize, QuadrantSize),
                    (short)rand.Next(-QuadrantSize, QuadrantSize)));
        }
        var count = (uint)coordinates.Count;
        foreach (var c in coordinates)
        {
            var facility = new Facility(
                    count--,
                    $"Medication {(char)(CapitalA + rand.Next(0, MedicationCount - 1))}", //Randomly generate A, B or C
                    rand.Next(0, 9999) / 100m);                                           //Randomly generate decimal between 0 and $99.99

            map.AddLocation(facility, c);

            System.Console.WriteLine($"{facility} added at {c}");
        }

        #endregion

        #region display map
        for (var y = -QuadrantSize; y <= QuadrantSize; y++)
        {
            for (var x = -QuadrantSize; x <= QuadrantSize; x++)
            {
                var c = new Coordinate((short)x, (short)y);
                if (coordinates.Contains(c))
                {
                    System.Console.Write("F ");
                }
                else if(x==0 && y == 0)
                {
                    System.Console.Write("o ");

                }
                else
                {
                    System.Console.Write("x ");
                }
            }
            System.Console.Write("\r\n");
        }
        #endregion

        Coordinate? coordinate = null;
        ConsoleKeyInfo? key;
        do
        {
            while (coordinate == null)
            {
                System.Console.WriteLine("Please Input Coordinates:");
                var input = System.Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    var match = Regex.Match(input, @"^[^\d\-]*(?<x>[\d\-]+)[^\d\-]+(?<y>[\d-]+)");
                    if (match.Success && short.TryParse(match.Groups["x"].Value, out var x) && short.TryParse(match.Groups["y"].Value, out var y))
                    {
                        coordinate = new Coordinate(x, y);
                        break;
                    }
                }
                System.Console.WriteLine($"Failed to convert '{input}' to x,y coordinates");

            }
            System.Console.WriteLine($"Closest Central Fills to {coordinate}:");
            var facilities = map.GetNearestFacilites(coordinate.Value, 3);

            foreach (var facility in facilities)
            {
                System.Console.WriteLine($"{facility.Item2}, Distance {facility.Item1}");
            }

            System.Console.WriteLine("Press any esc to exit or any other key to try again");
            coordinate = null;
            key = System.Console.ReadKey();

        } while (key?.Key != ConsoleKey.Escape);
    }
}
