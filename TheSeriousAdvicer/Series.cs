using System.Collections.Generic;

namespace TheSeriousAdvicer
{
    public partial class Series
    {
        public Series(string name, string pathToSeasonsList)
        {
            Name = name;
            PathToSeasonsList = pathToSeasonsList;
        }

        public string Name { get; }
        public string PathToSeasonsList { get; }
        public List<Season> Seasons { get; set; }

        public void GetNotEmptySeasons()
        {
            Seasons = Seasons.FindAll(season => !season.IsEmpty());
        }
    }
}