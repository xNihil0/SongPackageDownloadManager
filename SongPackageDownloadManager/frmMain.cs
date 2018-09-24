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
            WebRequest request = WebRequest.Create("https://etternaapi.xnihilo.live/v2/packs");
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
                //sb.AppendLine(packageAttributes.download);
                sb.AppendLine(string.Format("Pack Name: {0}\tAverage Difficulty: {1}\tSize: {2}", packageAttributes.name, packageAttributes.average, packageAttributes.size));
            }
            textBox1.Text = sb.ToString() + Environment.NewLine + "Total Size: " + (totalsize / 1024 / 1024 / 1024).ToString();
        }

        private void btnGetColLst_Click(object sender, EventArgs e)
        {
            WebRequest request = WebRequest.Create("https://etternaapi.xnihilo.live/v2/packs/collections");
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string rawjson = reader.ReadToEnd();
            reader.Close();
            response.Close();

            CollectionList collectionList = JsonConvert.DeserializeObject<CollectionList>(rawjson);
            List<CollectionDetails> collectionDetails = collectionList.data;
            StringBuilder sb = new StringBuilder();
            long totalsize = 0;
            foreach (CollectionDetails detail in collectionDetails)
            {
                CollectionAttributes collectionAttributes = detail.attributes;
                foreach (Pack pack in collectionAttributes.packs)
                {
                    totalsize += pack.size;
                    sb.AppendLine(pack.download);
                    //sb.AppendLine(string.Format("Pack Name: {0}\tAverage Difficulty: {1}\tSize: {2}", pack.packname, pack.average, pack.size));
                }
                textBox1.Text = sb.ToString() + Environment.NewLine + "Total Size: " + (totalsize / 1024 / 1024 / 1024).ToString();
            }
        }
    }
}
