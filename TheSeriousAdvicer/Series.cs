using System.Collections.Generic;

namespace TheSeriousAdvicer
{
    public partial class Series
    {
        public Series(string name, string pathToSeasonsList, string pathToWatchedList)
        {
            Name = name;
            PathToSeasonsList = pathToSeasonsList;
            PathToWatchedList = pathToWatchedList;
        }

        public string Name { get; }
        public string PathToSeasonsList { get; }
        public string PathToWatchedList { get; }
        public List<Season> Seasons { get; set; }

        public void GetNotEmptySeasons()
        {
            Seasons = Seasons.FindAll(season => !season.IsEmpty());
        }
    }
}