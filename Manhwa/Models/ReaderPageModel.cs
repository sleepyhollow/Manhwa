using System;
using System.Collections.Generic;
using System.Globalization;

namespace Manhwa.Models
{
    public class ReaderPageModel
    {
        public string Series { get; set; }
        public int Chapter { get; set; }

        public List<string> GetImages()
        {
            var series = Series;
            var chapter = Chapter;
            try
            {
                return chapter == 0 ? Utility.Api(series).Prologue : Utility.Api(series).Chapter[chapter - 1];
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }

        public string SafeName()
        {
            var series = Series;
            var casing = new CultureInfo("en-US", false).TextInfo;
            var safeName = casing.ToTitleCase(Utility.Api(series).Information.Series.Replace("-", " "));

            return safeName;
        }

        public bool LastChapter()
        {
            var series = Series;
            var chapter = Chapter;
            var subList = Utility.Api(series).Chapter;

            return chapter != subList.Count;
        }

        public bool BadPage()
        {
            var series = Series;
            var chapter = Chapter;

            var hasPrologue = Utility.Api(series).Prologue;
            var chapterList = Utility.Api(series).Chapter;

            if (hasPrologue.Count == 0 && chapter == 0) return true;
            if (chapter < 0) return true;
            return chapterList.Count < chapter;
        }
    }
}