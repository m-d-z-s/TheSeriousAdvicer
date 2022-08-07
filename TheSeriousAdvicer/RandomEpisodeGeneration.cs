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
            var series = GetNotEmptySeries(seriesNumber);
            
            if (series.Seasons.Count == 0) throw new Exception("Series overwatching!");/* $"You have watched '{series.Name}' series completely!";*/
            
            var randomEpisode = GetRandomEpisode(series);
            WriteWatched(randomEpisode);
            return $"Let's watch '{randomEpisode.series.Name}': {randomEpisode.season.Number} - {randomEpisode.number}.";
        }

/*        private string BuildOutputString(Series series)
        {
            
        }
*/        
        private Series GetNotEmptySeries(int seriesNumber)
        {
            var seriesList = GetSeriesList();
            var series = seriesList[seriesNumber];
            series.Seasons = GetSeasonList(rootPath + series.PathToSeasonsList, series);
            series.Seasons.ForEach(season => season.Episodes = GetEpisodesList(rootPath + season.PathToEpisodesList, series, season));
            series.GetNotEmptySeasons();
            return series;
        }

        private Series.Episode GetRandomEpisode(Series series)
        {
            var randomSeason = series.Seasons[new Random().Next(0, series.Seasons.Count)];
            return randomSeason.Episodes[new Random().Next(0, randomSeason.Episodes.Count)];
        }

        private void WriteWatched(Series.Episode episode)
        {
            var streamWriter = new StreamWriter(episode.series.PathToWatchedList, true);
            streamWriter.WriteLine($"{episode.series.Name}, {episode.season.Number}, {episode.number}");
            streamWriter.Close();
        }

        private List<string> GetWatchedEpisodes(Series.Episode episode)
        {
            var streamReader = new StreamReader(episode.series.PathToWatchedList, false);
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
                var series = new Series(seriesName, seriesSeasonsListPath, Form1.watchedListsPath + $@"\{Utility.NameFormater(seriesName)}_watched");
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

        private List<Series.Episode> GetEpisodesList(string path, Series series, Series.Season season/*, List<string> watchedEpisodes*/)
        {
            var streamReader = new StreamReader(path, false);
            var episodesList = new List<Series.Episode>();
            while (!streamReader.EndOfStream)
            {
                var episode = new Series.Episode(streamReader.ReadLine(), series, season);
                if (!IsWatched(episode, GetWatchedEpisodes(episode))) episodesList.Add(episode);
            }
            streamReader.Close();

            return episodesList;
        }

        private bool IsWatched(Series.Episode episode, List<string> watchedEpisodes)
        {
            return watchedEpisodes.Contains($"{ episode.series.Name}, {episode.season.Number}, {episode.number}");
        }
    }
}