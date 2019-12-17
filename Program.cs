using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlaylistAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("A playlist path and a report path must be provided.");
                Environment.Exit(1);
            }
            string DataPath = args[0];
            string ReportPath = args[1];

            List<MusicStats> musicStatList = null;
            try
            {
                musicStatList = MusicStatsLoader.Load(DataPath);
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(2);
            }
            var report = MusicStatsReport.GenerateText(musicStatList);
            try
            {
                System.IO.File.WriteAllText(ReportPath, report);
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(3);
            }
        }
    }
}
