using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Security.Cryptography;
using System.Reflection;

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

            SplitAllFilesAndSaveBlocks();

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
                string hashFilePath = Path.Combine(currentFolderPath, "../../../hash.txt");
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
                    string fileFolderPath = Path.Combine(folderPath, fileName);
                    string[] blockFiles = Directory.GetFiles(fileFolderPath);

                    if (blockFiles.Length > 0)
                    {
                        Array.Sort(blockFiles, (a, b) => int.Parse(Path.GetFileNameWithoutExtension(a).Split('_')[1]).CompareTo(int.Parse(Path.GetFileNameWithoutExtension(b).Split('_')[1])));

                        foreach (string blockFile in blockFiles)
                        {
                            byte[] blockContent = File.ReadAllBytes(blockFile);
                            string blockHash = Calculate(blockContent);

                            if (File.Exists(hashFilePath) && File.ReadLines(hashFilePath).Any(line => line == blockHash))
                            {
                                // Send the operation code and the hash value
                                writer.WriteLine($"HASH_VALUE {blockHash}");
                            }
                            else
                            {
                                // Send the block content
                                writer.WriteLine("BLOCK_CONTENT");
                                writer.WriteLine(Convert.ToBase64String(blockContent));
                                Calculate(blockContent); // This will add the hash to the hash.txt file
                            }
                        }
                        writer.WriteLine("END_OF_BLOCKS");
                    }
                    else
                    {
                        writer.WriteLine("Error: No blocks found for the given file");
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

        private static int CalculateHash(byte[] data)
        {
            int hash = 0;
            if (data.Length >= 4)
            {
                hash = BitConverter.ToInt32(data, 0);
            }
            else
            {
                byte[] temp = new byte[4];
                Array.Copy(data, 0, temp, 0, data.Length);
                hash = BitConverter.ToInt32(temp, 0);
            }

            return Math.Abs(hash) % 200;
        }

        private string Calculate(byte[] data)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(data);
                string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();

                string currentFolderPath = Path.GetDirectoryName(Application.ExecutablePath);
                string hashFilePath = Path.Combine(currentFolderPath, "../../../hash.txt");

                // If the hash.txt file doesn't exist, create it
                if (!File.Exists(hashFilePath))
                {
                    File.Create(hashFilePath).Dispose();
                }

                // Append the hash value to the file
                using (StreamWriter writer = File.AppendText(hashFilePath))
                {
                    writer.WriteLine(hashString);
                }

                return hashString;
            }
        }



        private void SplitFileAndSaveBlocks(string inputFilePath)
        {
            string blockBaseFolderPath = "../../../block";
            int fixedHashValue = 0;

            // Create a new folder named after the input file
            string fileName = Path.GetFileNameWithoutExtension(inputFilePath);
            string blockFolderPath = Path.Combine(blockBaseFolderPath, fileName);
            Directory.CreateDirectory(blockFolderPath);

            List<byte[]> blocks = SplitFileIntoBlocks(inputFilePath, blockFolderPath, fixedHashValue);

            Console.WriteLine($"File {fileName} has been successfully split into blocks.");
        }

        private void SplitAllFilesAndSaveBlocks()
        {
            string currentFolderPath = Path.GetDirectoryName(Application.ExecutablePath);
            string allFilesFolderPath = Path.Combine(currentFolderPath, "../../../all_files");
            string[] allFiles = Directory.GetFiles(allFilesFolderPath);

            foreach (string file in allFiles)
            {
                SplitFileAndSaveBlocks(file);
            }
        }



        public static List<byte[]> SplitFileIntoBlocks(string filePath, string blockFolderPath, int fixedHashValue)
        {
            byte[] fileContent = File.ReadAllBytes(filePath);
            List<byte[]> blocks = new List<byte[]>();

            int blockStart = 0;
            int blockNumber = 1;
            byte[] currentData = new byte[3];
            string folderName = Path.GetFileName(blockFolderPath);

            for (int i = 0; i < fileContent.Length - 2; i += 3)
            {
                Array.Copy(fileContent, i, currentData, 0, 3);
                int hashValue = CalculateHash(currentData);

                if (hashValue == fixedHashValue)
                {
                    byte[] block = new byte[i - blockStart + 3];
                    Array.Copy(fileContent, blockStart, block, 0, block.Length);
                    blocks.Add(block);

                    // Save block to file
                    string blockFileName = $"{folderName}_{blockNumber}.txt"; // Update the file name format with blockNumber
                    string blockFilePath = Path.Combine(blockFolderPath, blockFileName);
                    File.WriteAllBytes(blockFilePath, block);

                    blockStart = i + 3;
                    blockNumber++;
                }
            }

            if (blockStart < fileContent.Length)
            {
                byte[] block = new byte[fileContent.Length - blockStart];
                Array.Copy(fileContent, blockStart, block, 0, block.Length);
                blocks.Add(block);

                // Save block to file
                string blockFileName = $"{folderName}_{blockNumber}.txt"; // Update the file name format with blockNumber
                string blockFilePath = Path.Combine(blockFolderPath, blockFileName);
                File.WriteAllBytes(blockFilePath, block);
            }

            return blocks;
        }




    }
}