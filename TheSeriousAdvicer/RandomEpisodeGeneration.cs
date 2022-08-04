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

        public string RandomEpisodeGenerator(int seriesNumber)
        {
            var watchedEpisodes = GetWatchedEpisodes();

            while (true)
            {
                if (watchedEpisodes.Count > 30) WatchedEpisodesCleaning();

                var seriesList = GetSeriesList(); // get list of availible series
                var chosenSeries = seriesList[seriesNumber]; // pick a series chosen by user
                chosenSeries.Seasons = GetSeasonList(rootPath + chosenSeries.PathToSeasonsList, chosenSeries); // fill series with its seasons
                var randomSeason = chosenSeries.Seasons[new Random().Next(0, chosenSeries.Seasons.Count)]; // pick random season of this series
                randomSeason.Episodes = GetEpisodesList(rootPath + randomSeason.PathToEpisodesList, chosenSeries, randomSeason); // fill season with its episodes
                var randomEpisode = randomSeason.Episodes[new Random().Next(0, randomSeason.Episodes.Count)];
                if (!IsWatched(randomEpisode, watchedEpisodes))
                {
                    var streamWriter = new StreamWriter(rootPath + @"\watched", true);
                    streamWriter.WriteLine($"{chosenSeries.Name}, {randomSeason.Number}, {randomEpisode.number}");
                    streamWriter.Close();
                    return $"Let's watch {chosenSeries.Name}: {randomSeason.Number} - {randomEpisode.number}.";
                }
            }
        }

        public void WatchedEpisodesCleaning()
        {
            var streamWriter = new StreamWriter(rootPath + @"\watched", false);
            streamWriter.Write("");
            streamWriter.Close();
        }

        private readonly string rootPath;
        private readonly string seriesListFilePath;
        
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

        private List<Series.Episode> GetEpisodesList(string path, Series series, Series.Season season)
        {
            var streamReader = new StreamReader(path, false);
            var episodesList = new List<Series.Episode>();
            while (!streamReader.EndOfStream)
            {
                var episode = new Series.Episode(streamReader.ReadLine(), series, season);
                episodesList.Add(episode);
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