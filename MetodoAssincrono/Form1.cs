using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetodoAssincrono
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBaixar_Click(object sender, EventArgs e)
        {
            var webClient = new WebClient();

            progressBar1.Visible = true;
            var data = webClient.DownloadData(new Uri(txtUrl.Text));
            progressBar1.Visible = false;
            pbImagem.Visible = true;

            using (var memoryStream = new MemoryStream(data))
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                pbImagem.Image = new Bitmap(memoryStream);
            }
        }
    }
}
