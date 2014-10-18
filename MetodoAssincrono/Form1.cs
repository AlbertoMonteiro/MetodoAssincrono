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

            webClient.DownloadDataCompleted += WebClientOnDownloadDataCompleted;
            webClient.DownloadDataAsync(new Uri(txtUrl.Text));
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

            var webClient = new WebClient();

            progressBar1.Visible = true;
            webClient.DownloadDataCompleted += WebClientOnDownloadDataCompleted2;
            webClient.DownloadDataAsync(new Uri(txtUrl2.Text));
        }

        private void WebClientOnDownloadDataCompleted2(object sender, DownloadDataCompletedEventArgs e)
        {
            pbImagem2.Visible = true;

            using (var memoryStream = new MemoryStream(e.Result))
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                pbImagem2.Image = new Bitmap(memoryStream);
            }

            var webClient = new WebClient();

            progressBar1.Visible = true;
            webClient.DownloadDataCompleted += WebClientOnDownloadDataCompleted3;
            webClient.DownloadDataAsync(new Uri(txtUrl3.Text));
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
