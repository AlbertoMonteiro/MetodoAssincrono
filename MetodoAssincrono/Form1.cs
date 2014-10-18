using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
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

        private async void btnBaixar_Click(object sender, EventArgs e)
        {
            var tasks = new Task<byte[]>[] { BaixaImagem1(), BaixaImagem2()/*, BaixaImagem3()*/ };

            var foo = new Tuple<ProgressBar, PictureBox>[]
            {
                new Tuple<ProgressBar, PictureBox>(progressBar1, pbImagem),
                new Tuple<ProgressBar, PictureBox>(progressBar3, pbImagem2),
                new Tuple<ProgressBar, PictureBox>(progressBar2, pbImagem3)
            };

            var arrayArrayBytes = await Task.WhenAll(tasks);

            for (int i = 0; i < arrayArrayBytes.Length; i++)
            {
                var arrayArrayByte = arrayArrayBytes[i];

                foo[i].Item1.Visible = false;
                using (var memoryStream = new MemoryStream(arrayArrayByte))
                {
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    foo[i].Item2.Image = new Bitmap(memoryStream);
                    foo[i].Item2.Visible = true;
                }
            }
        }

        private Task<byte[]> BaixaImagem3()
        {
            var webClient2 = new WebClient();

            webClient2.DownloadProgressChanged += (o, args) => { progressBar2.Value = args.ProgressPercentage; };
            progressBar2.Visible = true;
            return webClient2.DownloadDataTaskAsync(new Uri(txtUrl2.Text));
            /*var data3 = await webClient2.DownloadDataTaskAsync(new Uri(txtUrl2.Text));
            progressBar2.Visible = false;
            pbImagem2.Visible = true;

            using (var memoryStream = new MemoryStream(data3))
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                pbImagem2.Image = new Bitmap(memoryStream);
            }*/
        }

        private Task<byte[]> BaixaImagem2()
        {
            var webClient3 = new WebClient();

            webClient3.DownloadProgressChanged += (o, args) => { progressBar3.Value = args.ProgressPercentage; };
            progressBar3.Visible = true;
            return webClient3.DownloadDataTaskAsync(new Uri(txtUrl3.Text));
            /*progressBar3.Visible = false;
            pbImagem3.Visible = true;

            using (var memoryStream = new MemoryStream(data2))
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                pbImagem3.Image = new Bitmap(memoryStream);
            }*/
        }

        private Task<byte[]> BaixaImagem1()
        {
            var webClient = new WebClient();

            progressBar1.Visible = true;

            webClient.DownloadProgressChanged += (o, args) => { progressBar1.Value = args.ProgressPercentage; };
            return webClient.DownloadDataTaskAsync(new Uri(txtUrl.Text));
            /*
                        progressBar1.Visible = false;
                        pbImagem.Visible = true;

                        using (var memoryStream = new MemoryStream(data))
                        {
                            memoryStream.Seek(0, SeekOrigin.Begin);
                            pbImagem.Image = new Bitmap(memoryStream);
                        }*/
        }
    }
}
