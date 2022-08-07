using System.IO;

namespace TheSeriousAdvicer
{
    public static class Utility
    {
        public static string NameFormater(string unfromatedName) => RemoveSpaces(unfromatedName).ToLowerInvariant();

        public static void WatchedEpisodesCleaning(string path)
        {
            var streamWriter = new StreamWriter(path, false);
            streamWriter.Write("");
            streamWriter.Close();
        }


        private static string RemoveSpaces(string unformatedLine)
        {
            var formatedLine = "";
            for (var i = 0; i < unformatedLine.Length; i++)
            {
                if (!(unformatedLine[i] == ' ')) formatedLine += unformatedLine[i];
            }

            return formatedLine;
        }
    }
}
