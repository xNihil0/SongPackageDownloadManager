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
            List<SongDetail> songDetail = packageList.data;
            StringBuilder sb = new StringBuilder();
            foreach (SongDetail detail in songDetail)
            {
                SongAttributes songAttributes = detail.attributes;
                sb.AppendLine(string.Format("Pack Name: {0} Average Difficulty: {1}  Size: {2}", songAttributes.name, songAttributes.average, songAttributes.size));
            }
            textBox1.Text = sb.ToString();
        }
    }
}
