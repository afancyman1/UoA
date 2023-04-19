using System.Net;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows;
namespace client
{
    public partial class client : Form
    {
        private TcpClient _client;
        public client()
        {
            InitializeComponent();
            ConnectToServer();
        }

        private TcpClient ConnectToServer()
        {
            try 
            {
                int port = 8081;
                IPAddress ipAddr = IPAddress.Loopback;
                _client = new TcpClient(ipAddr.ToString(), port);
                Console.WriteLine("connected to server");
                return _client;
            }
               catch(Exception ex) { MessageBox.Show($"连接服务器失败：{ex.Message}"); return null; }
        }

        private void client_Load(object sender, EventArgs e)
        {

        }

        private void showList_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            try
            {
                using (TcpClient client = ConnectToServer())
                using (NetworkStream stream = client.GetStream())
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true })
                {
                    //将LIST命令写入流中
                    writer.WriteLine("LIST");
                    string fileListString;
                    List<string> fileList = new List<string>();
                    while ((fileListString = reader.ReadLine()) != null)
                    {
                        fileList = fileListString.Split(',').ToList();
                    }
                    //更新listbox1的信息
                    //将fileList中的所有项添加到ListBox中
                    listBox1.Items.Clear();
                    listBox1.Items.AddRange(fileList.ToArray());

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"连接服务器失败：{ex.Message}");
            }
            
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}