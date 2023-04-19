using System.Net;
using System.Net.Sockets;
using System.Text;

namespace server
{
    public partial class Form1 : Form
    {
        private const int port = 8081;
        private TcpListener listener;
        private Thread serverThread;
        private List<string> files = new List<string>();
        public Form1()
        {
            InitializeComponent();
            StartServer();
        }

        private void StartServer()
        {
            Console.WriteLine("Server starting !");
            IPAddress ipAddr = IPAddress.Loopback;
            TcpListener listener = new TcpListener(ipAddr, port);
            listener.Start();
            Console.WriteLine($"Server started on port {port}");
            serverThread = new Thread(() =>
            {
                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    Console.WriteLine("clinet connected");
                    Thread clientThread= new Thread(() => HandleClient(client));
                    clientThread.Start();
                };
            });
            serverThread.IsBackground = true;
            serverThread.Start();
        }

        private void HandleClient(TcpClient client)
        {
            using (client)
            using (NetworkStream stream = client.GetStream())
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true })
            {
                string command = reader.ReadLine();

                if (command == "LIST")
                {
                    files.Clear();
                    string folderPath = @"C:\serverfiles";
                    string[] allFiles = Directory.GetFiles(folderPath);
                    // 提取文件名列表
                    foreach (string file in allFiles)
                    {
                        string fileName = Path.GetFileName(file);
                        files.Add(fileName);
                    }
                    // 将文件名列表转换为逗号分隔的字符串
                    string fileListString = string.Join(",", files);
                    writer.WriteLine(fileListString);
                    //writer.WriteLine("hello henry,hello mick");
                }
                // 根据需求，可以在此处添加其他命令的处理逻辑
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string folderPath = @"C:\serverfiles";
            string[] allFiles = Directory.GetFiles(folderPath);
            List<string> fileNames = new List<string>();

            foreach (string file in allFiles)
            {
                string fileName = Path.GetFileName(file);
                fileNames.Add(fileName);
            }

            listBox1.Items.Clear();
            listBox1.Items.AddRange(fileNames.ToArray());
        }
    }
}