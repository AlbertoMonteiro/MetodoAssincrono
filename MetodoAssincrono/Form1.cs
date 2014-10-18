using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
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
            var data = await BaixaImage();
            progressBar3.Visible = false;
            pbImagem3.Visible = true;

            using (var memoryStream = new MemoryStream(data))
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                pbImagem3.Image = new Bitmap(memoryStream);
            }
        }

        public Task<byte[]> BaixaImage()
        {
            var task = new TaskCompletionSource<byte[]>();

            ThreadPool.QueueUserWorkItem(state =>
            {
                var webClient2 = new WebClient();
                Action a = () => progressBar3.Visible = true;
                Invoke(a);
                var downloadData = webClient2.DownloadData(new Uri(txtUrl3.Text));
                task.SetResult(downloadData);
            });
            return task.Task;
        }
    }
}
