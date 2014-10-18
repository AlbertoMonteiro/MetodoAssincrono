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
            progressBar2.Visible = true;
            progressBar3.Visible = true;

            webClient.DownloadProgressChanged += (o, args) => { progressBar1.Value = args.ProgressPercentage; };
            webClient.DownloadDataCompleted += WebClientOnDownloadDataCompleted;
            webClient.DownloadDataAsync(new Uri(txtUrl.Text));
            
            var webClient2 = new WebClient();

            webClient2.DownloadProgressChanged += (o, args) => { progressBar2.Value = args.ProgressPercentage; };
            webClient2.DownloadDataCompleted += WebClientOnDownloadDataCompleted2;
            webClient2.DownloadDataAsync(new Uri(txtUrl2.Text));

            var webClient3 = new WebClient();

            webClient3.DownloadProgressChanged += (o, args) => { progressBar3.Value = args.ProgressPercentage; };
            webClient3.DownloadDataCompleted += WebClientOnDownloadDataCompleted3;
            webClient3.DownloadDataAsync(new Uri(txtUrl3.Text));
        }

        private void WebClientOnDownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            progressBar1.Visible = false;
            pbImagem.Visible = true;

            using (var memoryStream = new MemoryStream(e.Result))
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                pbImagem.Image = new Bitmap(memoryStream);
            }
        }

        private void WebClientOnDownloadDataCompleted2(object sender, DownloadDataCompletedEventArgs e)
        {
            pbImagem2.Visible = true;

            using (var memoryStream = new MemoryStream(e.Result))
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                pbImagem2.Image = new Bitmap(memoryStream);
            }
        }

        private void WebClientOnDownloadDataCompleted3(object sender, DownloadDataCompletedEventArgs e)
        {
            pbImagem3.Visible = true;

            using (var memoryStream = new MemoryStream(e.Result))
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                pbImagem3.Image = new Bitmap(memoryStream);
            }
        }
    }
}
