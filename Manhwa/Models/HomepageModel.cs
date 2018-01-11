using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer;

namespace Manhwa.Models
{
    public class HomepageModel
    {
        public string GetLatestSeries(int x)
        {
            return Utility.Api().Latest.Series[x];
        }

        public string GetChapterNumbers(int x)
        {
            return Utility.Api().Latest.ChapterNumber[x].ToString();
        }

        public string GetDates(int x)
        {
            return DateTime.Parse(Utility.Api().Latest.Dates[x]).Humanize();
        }

        public string GetFeatured(int x)
        {
            return Utility.Api().Featured[x];
        }

        public string GetImages(int x)
        {
            return Utility.Api().Images[x];
        }

        public string GetColors(int x)
        {
            return Utility.Api().Colors[x];
        }
    }
}
