using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NASAAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class JsonReading
        {
            [JsonProperty("hdurl")]
            public string hdurl { get; set; }

            [JsonProperty("explanation")]
            public string explanation { get; set; }

            [JsonProperty("date")]
            public string date { get; set; }

            [JsonProperty("title")]
            public string title { get; set; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string url = "https://api.nasa.gov/planetary/apod?api_key=YOUR_NASAAPI";
            var parsed = JsonConvert.DeserializeObject<JsonReading>(new WebClient().DownloadString(url));
            label1.Text = parsed.explanation;
            label2.Text = parsed.date;
            label3.Text = parsed.title;
            pictureBox1.Load(parsed.hdurl);
        }
    }
}
