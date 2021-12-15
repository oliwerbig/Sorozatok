using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sorozatok
{
    class Program
    {
        static List<Episode> Episodes = new();
        static List<string> SeriesTitles = new();

        static void Main(string[] args)
        {
            // 1.
            ProcessFile("lista.txt");

            // 2.
            Console.WriteLine("2. feladat");
            int NumOfEpisodesWithReleaseDate = Episodes.Aggregate(0, (x, y) => y.HasReleaseDate ? x + 1 : x);
            Console.WriteLine("A listában {0} db vetítési dátummal rendelkező epizód van.", NumOfEpisodesWithReleaseDate);
            Console.WriteLine("");

            // 3.
            Console.WriteLine("3. feladat");
            int NumOfSeen = Episodes.Aggregate(0, (x, y) => y.HasAlreadySeen ? x + 1 : x);
            double RateOfSeen = (double)NumOfSeen / (double)Episodes.Count;
            Console.WriteLine("A listában lévő epizódok {0:P2}-át látta.", RateOfSeen);
            Console.WriteLine("");

            // 4.
            Console.WriteLine("4. feladat");
            int totalMinutesOfWatching = Episodes.Aggregate(0, (x, y) => x + y.LengthInMinutes);
            TimeSpan totalTimeSpanOfWatching = new(totalMinutesOfWatching);
            (int days, int hours, int minutes) = totalTimeSpanOfWatching.GetTimeSpan();
            Console.WriteLine("Sorozatnézéssel {0} napot {1} órát és {2} percet töltött.", days, hours, minutes);
            Console.WriteLine("");

            // 5.
            Console.WriteLine("5. feladat");
            Console.Write("Adjon meg egy dátumot! Dátum= ");
            Date inputDate = new(Console.ReadLine());
            List<Episode> episodesNotSeenUntilInputDate = Episodes.Where(x => x.HasReleaseDate && x.ReleaseDate.GetDateAsInt() <= inputDate.GetDateAsInt()).ToList();
            foreach(Episode episode in episodesNotSeenUntilInputDate)
            {
                Console.WriteLine("{0}x{1}  {2}", episode.SeasonNumber, episode.EpisodeNumber.ToString("00"), episode.SeriesTitle);
            }
            Console.WriteLine("");

            // 6.
            string Hetnapja(int ev, int ho, int nap)
            {
                string[] napok = { "v", "h", "k", "sze", "cs", "p", "szo" };
                int[] honapok = { 0, 3, 2, 5, 0, 3, 5, 1, 4, 6, 2, 4 };

                if(ho < 3)
                {
                    ev -= 1;
                }

                return napok[(ev + ev / 4 - ev / 100 + ev / 400 + honapok[ho - 1] + nap) % 7];
            }

            // 7.
            Console.WriteLine("7. feladat");
            Console.Write("Adja meg a hét egy napját (például cs)! Nap= ");
            string inputNap = Console.ReadLine();
            List<string> seriesTitlesWithEpisodesWithoutReleaseDate = new();
            foreach(Episode episode in Episodes)
            {
                if(episode.HasReleaseDate)
                {
                    if(inputNap == Hetnapja(episode.ReleaseDate.Year, episode.ReleaseDate.Month, episode.ReleaseDate.Day))
                    {
                        if(!seriesTitlesWithEpisodesWithoutReleaseDate.Contains(episode.SeriesTitle))
                        {
                            seriesTitlesWithEpisodesWithoutReleaseDate.Add(episode.SeriesTitle);
                            Console.WriteLine(episode.SeriesTitle);
                        }
                    }
                } else
                {
                    Console.WriteLine("Az adott napon nem kerül adásba sorozat.");
                }
            }

            // 8.
            List<string> lines = new();
            foreach(string seriesTitle in SeriesTitles)
            {
                int numOfEpisodes = Episodes.Aggregate(0, (x, y) => y.SeriesTitle == seriesTitle ? x + 1 : x);
                int sumOfEpisodesLengthsInMinutes = Episodes.Aggregate(0, (x, y) => y.SeriesTitle == seriesTitle ? x + y.LengthInMinutes : x);

                string line = "";
                line += seriesTitle;
                line += " ";
                line += sumOfEpisodesLengthsInMinutes;
                line += " ";
                line += numOfEpisodes;

                lines.Add(line);

            }
            File.WriteAllLinesAsync("summa.txt", lines);
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

                if(!SeriesTitles.Contains(episode.SeriesTitle))
                {
                    SeriesTitles.Add(episode.SeriesTitle);
                }

                i += 5;
            }
        }
    }
}
