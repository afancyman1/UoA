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
        //private TcpClient _client;
        private TcpClient _cacheClient;
        public client()
        {
            InitializeComponent();
            //ConnectToServer();
            ConnectToCache();
        }

        //private TcpClient ConnectToServer()
        //{
        //    try 
        //    {
        //        int serverport = 8081;
        //        IPAddress ipAddr = IPAddress.Loopback;
        //        _client = new TcpClient(ipAddr.ToString(), serverport);
        //        Console.WriteLine("connected to server");
        //        return _client;
        //    }
        //       catch(Exception ex) { MessageBox.Show($"连接服务器失败：{ex.Message}"); return null; }
        //}

        private TcpClient ConnectToCache()
        {
            try
            {
                int cacheport = 8082;
                IPAddress ipAddr = IPAddress.Loopback;
                _cacheClient = new TcpClient(ipAddr.ToString(), cacheport);
                Console.WriteLine("connected to cache");
                return _cacheClient;
            }
            catch (Exception ex) { MessageBox.Show($"连接缓存失败：{ex.Message}"); return null; }
        }

        private void client_Load(object sender, EventArgs e)
        {

        }

        private void showList_Click(object sender, EventArgs e)
        {
            available_files.Items.Clear();
            try
            {
                using (TcpClient cache = ConnectToCache())
                using (NetworkStream stream = cache.GetStream())
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
                    available_files.Items.Clear();
                    available_files.Items.AddRange(fileList.ToArray());
                    
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
            available_files.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (available_files.SelectedItem == null)
            {
                MessageBox.Show("请选择一个文件。");
                return;
            }

            string fileName = available_files.SelectedItem.ToString();

            try
            {
                using (TcpClient _cacheclient = ConnectToCache())
                using (NetworkStream stream = _cacheClient.GetStream())
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true })
                {
                    //将GET_CONTENT命令写入流中
                    writer.WriteLine($"GET_CONTENT {fileName}");
                    string fileContent = reader.ReadLine();
                    textBox1.Text = fileContent;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"连接服务器失败：{ex.Message}");
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}