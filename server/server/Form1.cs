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
                //获取当前应用的路径，并将其与data文件夹结合
                string currentFolderPath = Path.GetDirectoryName(Application.ExecutablePath);
                string folderPath = Path.Combine(currentFolderPath, "../../../available_files");
                if (command == "LIST")
                {
                    files.Clear();
                    
                    try
                    {
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
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        writer.WriteLine("Error: Could not read files from the directory");
                    }

                }
                else if (command.StartsWith("GET_CONTENT"))
                {
                    string fileName = command.Substring("GET_CONTENT".Length).Trim();
                    string filePath = Path.Combine(folderPath, fileName);

                    if (File.Exists(filePath))
                    {
                        try
                        {
                            string fileContent = File.ReadAllText(filePath);
                            writer.WriteLine(fileContent);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                            writer.WriteLine("Error: Could not send the file content");
                        }
                    }
                    else
                    {
                        writer.WriteLine("Error: File not found");
                    }
                }
                // 根据需求，可以在此处添加其他命令的处理逻辑
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string currentFolderPath = Path.GetDirectoryName(Application.ExecutablePath);
            string folderPath = Path.Combine(currentFolderPath, "../../../available_files");
            string[] allFiles = Directory.GetFiles(folderPath);
            List<string> fileNames = new List<string>();

            foreach (string file in allFiles)
            {
                string fileName = Path.GetFileName(file);
                fileNames.Add(fileName);
            }

            available_files.Items.Clear();
            available_files.Items.AddRange(fileNames.ToArray());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string currentFolderPath = Path.GetDirectoryName(Application.ExecutablePath);
            string folderPath = Path.Combine(currentFolderPath, "../../../all_files");
            string[] allFiles = Directory.GetFiles(folderPath);
            List<string> fileNames = new List<string>();

            foreach (string file in allFiles)
            {
                string fileName = Path.GetFileName(file);
                fileNames.Add(fileName);
            }

            all_files.Items.Clear();
            all_files.Items.AddRange(fileNames.ToArray());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (all_files.SelectedItem == null)
            {
                MessageBox.Show("请选择一个文件。");
                return;
            }

            string fileName = all_files.SelectedItem.ToString();
            string currentFolderPath = Path.GetDirectoryName(Application.ExecutablePath);
            string allFilesFolderPath = Path.Combine(currentFolderPath, "../../../all_files");
            string availableFilesFolderPath = Path.Combine(currentFolderPath, "../../../available_files");

            string sourceFilePath = Path.Combine(allFilesFolderPath, fileName);
            string destinationFilePath = Path.Combine(availableFilesFolderPath, fileName);
            if (File.Exists(destinationFilePath))
            {
                MessageBox.Show($"文件夹已经存在：{fileName}");
                return;
            }
            try
            {
                File.Copy(sourceFilePath, destinationFilePath, overwrite: true);
                available_files.Items.Add(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"无法复制文件：{ex.Message}");
            }
        }


        private void all_files_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}