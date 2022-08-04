using System;
using System.Collections.Generic;
using System.IO;

namespace TheSeriousAdvicer
{
    public class RandomEpisodeGeneration
    {
        public RandomEpisodeGeneration(string rootPath, string seriesListFileName)
        {
            this.rootPath = rootPath;
            seriesListFilePath = rootPath + seriesListFileName;
        }

        public readonly string rootPath;
        public readonly string seriesListFilePath;

        public string RandomEpisodeGenerator(int seriesNumber)
        {
            string output;
            var watchedEpisodes = GetWatchedEpisodes();

            var seriesList = GetSeriesList(); // get list of availible series
            var chosenSeries = seriesList[seriesNumber]; // pick a series chosen by user
            chosenSeries.Seasons = GetSeasonList(rootPath + chosenSeries.PathToSeasonsList, chosenSeries); // fill series with its seasons
            chosenSeries.Seasons.ForEach(season => season.Episodes = GetEpisodesList(rootPath + season.PathToEpisodesList, chosenSeries, season, watchedEpisodes));
            chosenSeries.GetNotEmptySeasons();

            if (chosenSeries.Seasons.Count == 0) output = "You have watched this series completely!";
            else
            {
                var randomSeason = chosenSeries.Seasons[new Random().Next(0, chosenSeries.Seasons.Count)]; // pick random season of this series
                randomSeason.Episodes = GetEpisodesList(rootPath + randomSeason.PathToEpisodesList, chosenSeries, randomSeason, watchedEpisodes); // fill season with its episodes
                var randomEpisode = randomSeason.Episodes[new Random().Next(0, randomSeason.Episodes.Count)];

                WriteWatched(randomEpisode);

                output = $"Let's watch {randomEpisode.series.Name}: {randomEpisode.season.Number} - {randomEpisode.number}.";
            }

            return output;
        }

        public void WatchedEpisodesCleaning()
        {
            var streamWriter = new StreamWriter(rootPath + @"\watched", false);
            streamWriter.Write("");
            streamWriter.Close();
        }
        
        private void WriteWatched(Series.Episode episode)
        {
            var streamWriter = new StreamWriter(rootPath + @"\watched", true);
            streamWriter.WriteLine($"{episode.series.Name}, {episode.season.Number}, {episode.number}");
            streamWriter.Close();
        }
        
        private List<string> GetWatchedEpisodes()
        {
            var streamReader = new StreamReader(rootPath + @"\watched", false);
            var watchedEpisodes = new List<string>();
            while (!streamReader.EndOfStream)
            {
                watchedEpisodes.Add(streamReader.ReadLine());
            }
            streamReader.Close();
            
            return watchedEpisodes;
        }

        private List<Series> GetSeriesList()
        {
            var streamReader = new StreamReader(seriesListFilePath, false);
            var seriesList = new List<Series>();
            while (!streamReader.EndOfStream)
            {
                var seriesData = streamReader.ReadLine().Split(',');
                var seriesName = seriesData[0];
                var seriesSeasonsListPath = seriesData[1];
                var series = new Series(seriesName, seriesSeasonsListPath);
                seriesList.Add(series);
            }
            streamReader.Close();

            return seriesList;
        }

        private List<Series.Season> GetSeasonList(string path, Series series)
        {
            var streamReader = new StreamReader(path, false);
            var seasonList = new List<Series.Season>();
            while (!streamReader.EndOfStream)
            {
                var seasonData = streamReader.ReadLine().Split(',');
                var seasonNumber = seasonData[0];
                var seasonEpisodesListPath = seasonData[1];
                var season = new Series.Season(series, seasonNumber, seasonEpisodesListPath);
                seasonList.Add(season);
            }
            streamReader.Close();

            return seasonList;

        }

        private List<Series.Episode> GetEpisodesList(string path, Series series, Series.Season season, List<string> watchedEpisodes)
        {
            var streamReader = new StreamReader(path, false);
            var episodesList = new List<Series.Episode>();
            while (!streamReader.EndOfStream)
            {
                var episode = new Series.Episode(streamReader.ReadLine(), series, season);
                if (!IsWatched(episode, watchedEpisodes)) episodesList.Add(episode);
            }
            streamReader.Close();

            return episodesList;
        }

        private bool IsWatched(Series.Episode episode, List<string> watchedEpisodes)
        {
            return watchedEpisodes.Contains($"{episode.series.Name}, {episode.season.Number}, {episode.number}");
        }
    }
}