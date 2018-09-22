using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SongPackageDownloadManager
{
    public class SongAttributes
    {
        public string name { get; set; }
        public double average { get; set; }
        public string download { get; set; }
        public int size { get; set; }
    }

    public class SongDetail
    {
        public string type { get; set; }
        public string id { get; set; }
        public SongAttributes attributes { get; set; }
    }

    public class PackageList
    {
        public List<SongDetail> data { get; set; }
    }

    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
