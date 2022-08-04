namespace TheSeriousAdvicer
{
    public partial class Series
    {
        public struct Episode
        {
            public Episode(string number, Series series, Season season)
            {
                this.number = number;
                this.series = series;
                this.season = season;
            }

            public string number;
            public Series series;
            public Season season;
        }
    }
}