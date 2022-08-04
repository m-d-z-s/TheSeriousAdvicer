namespace TheSeriousAdvicer
{
    public partial class Series
    {
        public struct Episode
        {
            public string number;
            public Series series;
            public Season season;

            public Episode(string number, Series series, Season season)
            {
                this.number = number;
                this.series = series;
                this.season = season;
            }
        }
    }
}