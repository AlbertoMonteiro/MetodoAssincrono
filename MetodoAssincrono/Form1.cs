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
            var data = webClient.DownloadData(new Uri(txtUrl.Text));

            progressBar1.Visible = false;
            pbImagem.Visible = true;

            using (var memoryStream = new MemoryStream(data))
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                pbImagem.Image = new Bitmap(memoryStream);
            }
            
            webClient = new WebClient();

            progressBar1.Visible = true;
            data = webClient.DownloadData(new Uri(txtUrl2.Text));

            progressBar1.Visible = false;
            pbImagem2.Visible = true;

            using (var memoryStream = new MemoryStream(data))
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                pbImagem2.Image = new Bitmap(memoryStream);
            }
            
            webClient = new WebClient();

            progressBar1.Visible = true;
            data = webClient.DownloadData(new Uri(txtUrl3.Text));

            progressBar1.Visible = false;
            pbImagem3.Visible = true;

            using (var memoryStream = new MemoryStream(data))
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                pbImagem3.Image = new Bitmap(memoryStream);
            }
        }
    }
}
