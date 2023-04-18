using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace server
{
    class Server
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server starting !");

            // IP Address to listen on. Loopback is the localhost
            IPAddress ipAddr = IPAddress.Loopback;

            // Port to listen on
            int port = 8081;

            // Create and start a listener for client connection
            TcpListener listener = new TcpListener(ipAddr, port);
            listener.Start();

            Console.WriteLine("Server listening on: {0}:{1}", ipAddr, port);

            // keep running
            while (true)
            {
                // 当有客户端连接进来时，它会返回一个 TcpClient 对象，该对象表示与连接到的客户端的网络连接。
                var client = listener.AcceptTcpClient();
                Console.WriteLine("clinet connected");

                // NetworkStream object is used for passing data between client and server
                NetworkStream stream = client.GetStream();

                // read the first byte that represents the command of the client 读取代表客户端命令的第一个字节
                // stream.ReadByte() 是一个 NetworkStream 类中的方法，用于从当前流中读取一个字节，并将流内的位置向前推进一个字节。
                byte command = (byte)stream.ReadByte();
                
                // 0 is for a greeting message
                if (command == 0)
                {
                    // Create a StreamWriter object to write the message to the stream using UTF-8 encoding
                    StreamWriter writer = new StreamWriter(stream, Encoding.UTF8);

                    // Write a string to the stream
                    string myString = "Hello, client!";
                    writer.Write(myString);

                    // Flush the StreamWriter to ensure that all data is written to the stream
                    writer.Flush();
                }
                else  // command for a text file
                {
                    // the four bytes following the command is the number of bytes storing the file name
                    // 命令后面的四个字节是存储文件名的字节数
                    byte[] data = new byte[4];
                    // 0到4是指读取的数据存在data的0到4索引中。
                    stream.Read(data, 0, 4); // read bytes from the stream into the buffer

                    // find out the length of the file name and read the bytes representing the file name
                    // 找出文件名的长度并读取代表文件名的字节
                    // 使用BitConverter将接收到的字节数组（即data数组）中的前4个字节转换成一个整数，该整数指示了接下来要接收的文件名的字节数。
                    int fileNameBytesLength = BitConverter.ToInt32(data, 0);
                    // 此时ileNameBytesLength的值为一个int类型，代表文件名的长度
                    // 创建一个新的数组，长度为文件名的长度
                    // 继续读取流中的数据，读取的数据为文件名，每一位都存在data数组中
                    data = new byte[fileNameBytesLength];
                    stream.Read(data, 0, fileNameBytesLength);

                    // get the path to the file
                    // 转换成字符串
                    string fileName = Encoding.UTF8.GetString(data);
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "../../../data");
                    string fileNamePath = Path.Combine(path, fileName);

                    // StreamWriter object is used to send data to the client
                    StreamWriter writer = new StreamWriter(stream);

                    // read the contents of the file and send them to the client
                    using (StreamReader reader = new StreamReader(fileNamePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            // Write the line of text to the network stream
                            writer.WriteLine(line);
                        }
                    }

                    writer.Flush(); // ask the system send the data now
                    writer.Close();
                    stream.Close();
                }
                client.Close();
            }
        }
    }
}