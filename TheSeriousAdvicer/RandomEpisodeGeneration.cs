using System;
using System.Collections.Generic;
using System.IO;

namespace TheSeriousAdvicer
{
    internal class RandomEpisodeGeneration
    {
        internal readonly string rootPath;
        private readonly string seriesListFilePath;
        internal List<Series> GetSeriesList()
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

        private List<Season> GetSeasonList(string path)
        {
            var streamReader = new StreamReader(path, false);
            var seasonList = new List<Season>();
            while (!streamReader.EndOfStream)
            {
                var seasonData = streamReader.ReadLine().Split(',');
                var seasonNumber = seasonData[0];
                var seasonEpisodesListPath = seasonData[1];
                var season = new Season(seasonNumber, seasonEpisodesListPath);
                seasonList.Add(season);
            }
            streamReader.Close();

            return seasonList;

        }

        private List<Episode> GetEpisodesList(string path)
        {
            var streamReader = new StreamReader(path, false);
            var episodesList = new List<Episode>();
            while (!streamReader.EndOfStream)
            {
                var episode = new Episode
                {
                    Number = streamReader.ReadLine()
                };
                episodesList.Add(episode);
            }
            streamReader.Close();

            return episodesList;

        }

        private bool CheckForWatched(Series series, Season season, Episode episode, List<string> watchedEpisodes)
        {
            var coinsideces = 0;
            watchedEpisodes.ForEach(it =>
            {
                if (it == $"{series.Name}, {season.Number}, {episode.Number}") coinsideces++;
            });
            return coinsideces == 0 ? true : false;

        }

        internal void WatchedEpisodesCleaning()
        {
            var streamWriter = new StreamWriter(rootPath + @"\watched", false);
            streamWriter.Write("");
            streamWriter.Close();
        }

        internal string RandomEpisodeGenerator(int seriesNumber)
        {

            while (true)
            {
                var streamReader = new StreamReader(rootPath + @"\watched", false);
                var watchedEpisodes = new List<string>();
                while (!streamReader.EndOfStream)
                {
                    watchedEpisodes.Add(streamReader.ReadLine());
                }
                streamReader.Close();

                if (watchedEpisodes.Count > 30) WatchedEpisodesCleaning();

                var seriesList = GetSeriesList(); // get list of availible series
                var chosenSeries = seriesList[seriesNumber]; // pick a series chosen by user
                chosenSeries.Seasons = GetSeasonList(rootPath + chosenSeries.PathToSeasonsList); // fill series with its seasons
                var randomSeason = chosenSeries.Seasons[new Random().Next(0, chosenSeries.Seasons.Count)]; // pick random season of this series
                randomSeason.Episodes = GetEpisodesList(rootPath + randomSeason.PathToEpisodesList); // fill season with its episodes
                var randomEpisode = randomSeason.Episodes[new Random().Next(0, randomSeason.Episodes.Count)];
                if (CheckForWatched(chosenSeries, randomSeason, randomEpisode, watchedEpisodes))
                {
                    var streamWriter = new StreamWriter(rootPath + @"\watched", true);
                    streamWriter.WriteLine($"{chosenSeries.Name}, {randomSeason.Number}, {randomEpisode.Number}");
                    streamWriter.Close();
                    return $"Let's watch {chosenSeries.Name}: {randomSeason.Number} - {randomEpisode.Number}.";
                }
            }
        }

        internal RandomEpisodeGeneration(string rootPath, string seriesListFileName)
        {
            this.rootPath = rootPath;
            seriesListFilePath = rootPath + seriesListFileName;
        }
    }
}