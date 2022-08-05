using System.Collections.Generic;

namespace TheSeriousAdvicer
{
    public partial class Series
    {
        public class Season
        {
            public Season(Series series, string number, string pathToEpisodesList)
            {
                this.series = series;
                Number = number;
                PathToEpisodesList = pathToEpisodesList;
            }

            public Series series;
            public string Number { get; }
            public string PathToEpisodesList { get; }

            public List<Episode> Episodes { get; set; }

            public bool IsEmpty()
            {
                return Episodes.Count == 0;
            }
        }
    }
}