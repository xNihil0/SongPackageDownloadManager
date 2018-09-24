using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongPackageDownloadManager
{
    public class PackageAttributes
    {
        public string name { get; set; }
        public double average { get; set; }
        public string download { get; set; }
        public int size { get; set; }
    }

    public class PackageDetails
    {
        public string type { get; set; }
        public string id { get; set; }
        public PackageAttributes attributes { get; set; }
    }

    public class PackageList
    {
        public List<PackageDetails> data { get; set; }
    }
}
