using System.Collections.Generic;

namespace TheSeriousAdvicer
{
    public class Series
    {
        public string Name { get; }
        public string PathToSeasonsList { get; }
        public List<Season> Seasons { get; set; }

        public Series(string name, string pathToSeasonsList)
        {
            Name = name;
            PathToSeasonsList = pathToSeasonsList; 
        }
    }
}