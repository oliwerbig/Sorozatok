using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorozatok
{
    class Episode
    {
        public bool HasReleaseDate { get; set; } = false;
        public Date ReleaseDate { get; set; } = new();
        public string SeriesTitle { get; set; } = "";
        public int SeasonNumber { get; set; } = 0;
        public int EpisodeNumber { get; set; } = 0;
        public int LengthInMinutes { get; set; } = 0;
        public bool HasAlreadySeen { get; set; } = false;

        public Episode()
        {

        }

        public Episode(string payload) {
            ParsePayload(payload);
        }

        void ParsePayload(string payload)
        {
            char splitDelimiter = '\n';
            List<string> values = payload.Split(splitDelimiter).ToList();

            HasReleaseDate = values[0] != "NI";
            ReleaseDate = HasReleaseDate ? new(values[0]) : null;
            SeriesTitle = values[1];
            string[] SeasonAndEpisode = values[2].Split("x");
            SeasonNumber = int.Parse(SeasonAndEpisode[0]);
            EpisodeNumber = int.Parse(SeasonAndEpisode[1]);
            LengthInMinutes = int.Parse(values[3]);
            HasAlreadySeen = int.Parse(values[4]) != 0;
        }
    }
}
