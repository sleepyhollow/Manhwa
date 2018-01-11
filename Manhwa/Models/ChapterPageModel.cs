using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Humanizer;

namespace Manhwa.Models
{
    public class ChapterPageModel
    {
        public string Series { get; set; }
        public int Chapter { get; set; }

        public int GetChaptersCount()
        {
            var series = Series;

            return Utility.Api(series).Chapter.Count;
        }

        public bool HasPrologue()
        {
            var series = Series;

            return Utility.Api(series).Prologue.Count > 0;
        }

        public string GetSeries(string data)
        {
            var series = Series;

            return Utility.Api(series).Information.Series;
        }

        public string GetArtist()
        {
            var series = Series;

            return Utility.Api(series).Information.Artist;
        }

        public string GetAuthor()
        {
            var series = Series;

            return Utility.Api(series).Information.Author;
        }

        public string GetDescription()
        {
            var series = Series;

            return Utility.Api(series).Information.Description;
        }

        public List<string> GetTags()
        {
            var series = Series;

            return Utility.Api(series).Information.Tags;
        }

        public string GetDate(int chapterNumber)
        {
            var series = Series;
            try
            {
                return DateTime.Parse(Utility.Api(series).Dates[chapterNumber]).Humanize();
            }
            catch (Exception)
            {
                return "";
            }
        }

        public string SafeName()
        {
            var series = Series;
            var casing = new CultureInfo("en-US", false).TextInfo;
            var safeName = casing.ToTitleCase(Utility.Api(series).Information.Series.Replace("-", " "));

            return safeName;
        }
    }
}