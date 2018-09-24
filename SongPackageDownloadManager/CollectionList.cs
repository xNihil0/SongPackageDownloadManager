using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongPackageDownloadManager
{
    public class Pack
    {
        public int packid { get; set; }
        public string packname { get; set; }
        public double average { get; set; }
        public string date { get; set; }
        public string download { get; set; }
        public int size { get; set; }
    }

    public class CollectionAttributes
    {
        public List<Pack> packs { get; set; }
    }

    public class CollectionDetails
    {
        public string type { get; set; }
        public string id { get; set; }
        public CollectionAttributes attributes { get; set; }
    }

    public class CollectionList
    {
        public List<CollectionDetails> data { get; set; }
    }
}
