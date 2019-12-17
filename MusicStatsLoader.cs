using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MusicPlaylistAnalyzer
{
    public static class MusicStatsLoader
    {
        //private static int NumItemsInRow = 978;

        public static List<MusicStats> Load(string DataPath)
        {
            List<MusicStats> musicStatList = new List<MusicStats>();

            try
            {
                using (var reader = new StreamReader(DataPath))
                {
                    int lineNumber = 0;
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        lineNumber++;
                        if (lineNumber == 1) continue;

                        var values = line.Split('\t');

                        //if (values.Length != NumItemsInRow)
                        //{
                          //  throw new Exception($"Row {lineNumber} contains {values.Length} values. It should contain {NumItemsInRow}.");
                        //}
                        try
                        {
                            string name = values[0];
                            string artist = values[1];
                            string album = values[2];
                            string genre = values[3];
                            int size = Int32.Parse(values[4]);
                            int time = Int32.Parse(values[5]);
                            int year = Int32.Parse(values[6]);
                            int plays = Int32.Parse(values[7]);
                            MusicStats musicStats = new MusicStats(name, artist, album, genre, size, time, year, plays);
                            musicStatList.Add(musicStats);
                        }
                        catch (FormatException e)
                        {
                            throw new Exception($"Row {lineNumber} contains invaild data. ({e.Message})");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to open {DataPath} ({e.Message})");
            }
            return musicStatList;
        }
    }
}
