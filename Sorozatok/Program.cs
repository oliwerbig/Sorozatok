using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sorozatok
{
    class Program
    {
        static List<Episode> Episodes = new();

        static void Main(string[] args)
        {
            // 1.
            ProcessFile("lista.txt");

            // 2.
            int NumOfEpisodesWithReleaseDate = Episodes.Aggregate(0, (x, y) => y.HasReleaseDate ? x + 1 : x);
            Console.WriteLine("2.feladat");
            Console.WriteLine("A listában {0} db vetítési dátummal rendelkező epizód van.", NumOfEpisodesWithReleaseDate);
            Console.WriteLine("");

            // 3.
            int NumOfSeen = Episodes.Aggregate(0, (x, y) => y.HasAlreadySeen ? x + 1 : x);
            double RateOfSeen = (double)NumOfSeen / (double)Episodes.Count;
            Console.WriteLine("3.feladat");
            Console.WriteLine("A listában lévő epizódok {0:P2} % -át látta.", RateOfSeen);
            Console.WriteLine("");

            // 4.
            int totalMinutesOfWatching = Episodes.Aggregate(0, (x, y) => x + y.LengthInMinutes);
            TimeSpan totalTimeSpanOfWatching = new(totalMinutesOfWatching);
            (int days, int hours, int minutes) = totalTimeSpanOfWatching.GetTimeSpan();
            Console.WriteLine("4.feladat");
            Console.WriteLine("Sorozatnézéssel {0} napot {1} órát és {2} percet töltött.", days, hours, minutes);
            Console.WriteLine("");

        }

        static void ProcessFile(string path)
        {
            string[] lines = File.ReadAllLines(path);

            int i = 0;
            while (i < lines.Length)
            {
                string payload = "";
                for (int j = 0; j < 5; j++) {
                    payload += lines[i + j];
                    payload += "\n";
                }
                
                Episode episode = new(payload);
                Episodes.Add(episode);

                i += 5;
            }
        }
    }
}
