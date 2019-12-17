using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MusicPlaylistAnalyzer
{
    public static class MusicStatsReport
    {
        public static string GenerateText(List<MusicStats> musicStatList)
        {
            string report = "Music Playlist Report";
            if (musicStatList.Count() < 1)
            {
                report += "No data is available.\n";
                return report;
            }
            var songsWith200 = from song in musicStatList where song.Plays >= 200 orderby song.Year descending select song;
            report += "Songs that received 200 or more plays:\n";
            foreach (var song in songsWith200)
            {
                report += $"Name: {song.Name}, Artist {song.Artist}, Album {song.Album}, Genre: {song.Genre}, Size: {song.Size}, Time: {song.Time}, Year: {song.Year}, Plays: {song.Plays}\n";
            }
            var songsWithAlt = from song in musicStatList where song.Genre == "Alternative" orderby song.Year descending select song;
            int total = 0;
            foreach (var song in songsWithAlt)
            {
                total += 1;
            }
            report += $"Number of Alternative songs: {total}\n";
            var songsWithHipRap = from song in musicStatList where song.Genre == "Hip-Hop/Rap" orderby song.Year descending select song;
            int total2 = 0;
            foreach (var song in songsWithHipRap)
            {
                total2 += 1;
            }
            report += $"Number of Hip-Hop/Rap songs: {total2}\n";
            var songsWithFish = from song in musicStatList where song.Album == "Welcome to the Fishbowl" orderby song.Plays descending select song;
            foreach (var song in songsWithFish)
            {
                report += $"Name: {song.Name}, Artist {song.Artist}, Album {song.Album}, Genre: {song.Genre}, Size: {song.Size}, Time: {song.Time}, Year: {song.Year}, Plays: {song.Plays}\n";
            }
            var songs1970 = from song in musicStatList where song.Year < 1970 orderby song.Year descending select song;
            foreach (var song in songs1970)
            {
                report += $"Name: {song.Name}, Artist {song.Artist}, Album {song.Album}, Genre: {song.Genre}, Size: {song.Size}, Time: {song.Time}, Year: {song.Year}, Plays: {song.Plays}\n";
            }
            var songs85 = from song in musicStatList where song.Name.Length > 85 orderby song.Year descending select song;
            foreach (var song in songs85)
            {
                report += $"Name: {song.Name}, Artist {song.Artist}, Album {song.Album}, Genre: {song.Genre}, Size: {song.Size}, Time: {song.Time}, Year: {song.Year}, Plays: {song.Plays}\n";
            }
            var songLongest = from song in musicStatList where song.Time == ((from stats in musicStatList select stats.Time).Max()) select song.Time;
            if (songLongest.Count() > 0)
            {
                report += $"Longest song: {songLongest.First()}\n";
            }
            else
            {
                report += "Not Available\n";
            }
            return report;
        }
    }
}
