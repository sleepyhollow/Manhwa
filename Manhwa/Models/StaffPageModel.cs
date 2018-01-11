using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manhwa.Models
{
    public class StaffPageModel
    {
        public string GetBanner()
        {
            return Utility.Staff().Banner;
        }

        public string GetName(int x)
        {
            return Utility.Staff().Staff[x][0];
        }

        public string GetAvatar(int x)
        {
            return Utility.Staff().Staff[x][2];
        }

        public string GetTitle(int x)
        {
            return Utility.Staff().Staff[x][1];
        }

        public string GetColor(int x)
        {
            return Utility.Staff().Staff[x][3];
        }
    }
}
