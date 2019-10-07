using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace FondoEscritorioNasa
{
    public partial class Form1 : Form
    {
        static HttpClient client = new HttpClient();
        public Form1()
        {
            InitializeComponent();
        }

        [SuppressUnmanagedCodeSecurity, SecurityCritical,DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SystemParametersInfo(int nAction,int nParam, string value, int ignore);

        private void Form1_Load(object sender, EventArgs e)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://api.nasa.gov/planetary/apod?api_key=AytFla37ceqUfpdNgzH6szGYmiLeLWbGEh0n54Te");
            var respuesta = req.GetResponse();
            var dataStream = respuesta.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            JavaScriptSerializer j = new JavaScriptSerializer();
            Data model = j.Deserialize<Data>(responseFromServer);
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(new Uri(model.hdurl), @"c:\temp\wallpaper.jpg");
                SystemParametersInfo(20, 0, @"c:\temp\wallpaper.jpg", 0);
                this.Close();
                //Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("wallpaper", wallpaper);
            }
        }
    }
}
