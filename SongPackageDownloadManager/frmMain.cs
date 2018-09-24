using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace SongPackageDownloadManager
{
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnGetPkgLst_Click(object sender, EventArgs e)
        {
            string requestURL = "https://etternaapi.xnihilo.live/v2/packs";
            WebRequest request = WebRequest.Create(requestURL);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string rawjson = reader.ReadToEnd();
            reader.Close();
            response.Close();

            PackageList packageList = JsonConvert.DeserializeObject<PackageList>(rawjson);
            List<PackageDetails> packageDetails = packageList.data;
            StringBuilder sb = new StringBuilder();
            long totalsize=0;
            foreach (PackageDetails detail in packageDetails)
            {
                PackageAttributes packageAttributes = detail.attributes;
                totalsize += packageAttributes.size;
                //sb.AppendLine(WebUtility.UrlDecode(packageAttributes.download));
                sb.AppendLine(string.Format("Pack Name: {0}\tAverage Difficulty: {1}\tSize: {2}", packageAttributes.name, packageAttributes.average, packageAttributes.size));
            }
            textBox1.Text = sb.ToString() + Environment.NewLine + "Total Size: " + ((double)totalsize / 1024 / 1024 / 1024).ToString("0.000");
        }

        private void btnGetColLst_Click(object sender, EventArgs e)
        {
            //string requestURL = "https://etternaapi.xnihilo.live/v2/packs/collections";
            string requestURL = "https://api.etternaonline.com/v2/packs/collections";
            WebRequest request = WebRequest.Create(requestURL);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string rawjson = reader.ReadToEnd();
            reader.Close();
            response.Close();

            CollectionList collectionList = JsonConvert.DeserializeObject<CollectionList>(rawjson);
            List<CollectionDetails> collectionDetails = collectionList.data;
            StringBuilder sb = new StringBuilder();
            List<Pack> packs = new List<Pack>();
            long totalsize = 0;
            foreach (CollectionDetails detail in collectionDetails)
            {
                CollectionAttributes collectionAttributes = detail.attributes;
                List<Pack> pkgs = collectionAttributes.packs;
                foreach (Pack pkg in pkgs)
                {
                    packs.Add(pkg);
                    //sb.AppendLine(WebUtility.UrlDecode(pkg.download));
                    //sb.AppendLine(string.Format("Pack Name: {0}\tAverage Difficulty: {1}\tSize: {2}", pack.packname, pack.average, pack.size));
                }
            }
            List<Pack> uniquepacks = packs.Where((x, i) => packs.FindIndex(y => y.packid == x.packid) == i).ToList();
            foreach (Pack pkg in uniquepacks)
            {
                sb.AppendLine(WebUtility.UrlDecode(pkg.download));
                totalsize += pkg.size;
            }
            textBox1.Text = sb.ToString() + Environment.NewLine + "Total Size: " + (((double)totalsize / 1024 / 1024 / 1024)).ToString("0.000");
        }
    }
}
