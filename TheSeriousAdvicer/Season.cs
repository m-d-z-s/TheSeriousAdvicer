using System.Collections.Generic;

namespace TheSeriousAdvicer
{
    public class Season
    {
        public string Number { get; }
        public string PathToEpisodesList { get; }

        public List<Episode> Episodes { get; set; }

        public Season(string number, string pathToEpisodesList)
        {
            Number = number;
            PathToEpisodesList = pathToEpisodesList;
        }
    }
}