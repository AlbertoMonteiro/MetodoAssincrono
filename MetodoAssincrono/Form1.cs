using System;
using System.Drawing;
using System.IO;
using System.Net;
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
            webClient.DownloadDataCompleted += (o, args) =>
            {
                progressBar1.Visible = false;
                pbImagem.Visible = true;

                using (var memoryStream = new MemoryStream(args.Result))
                {
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    pbImagem.Image = new Bitmap(memoryStream);
                }
            };
            webClient.DownloadProgressChanged += (o, args) =>
            {
                progressBar1.Value = args.ProgressPercentage;
            };
            webClient.DownloadDataAsync(new Uri(txtUrl.Text));
        }
    }
}
