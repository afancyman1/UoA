using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace client
{
    public class Client
    {
        static void Main(string[] args)
        {
            // IP Address to listen on. Loopback is the localhost
            // 要侦听的 IP 地址。 Loopback 是本地主机
            // ipAddr的值为127.0.0.1
            IPAddress ipAddr = IPAddress.Loopback;
            // Port to listen on
            int port = 8081;

            try
            {
                //输出一条信息start client
                Console.WriteLine("start client");
                //创建一个TcpClient对象，port为上面创建的8081
                //客户端连接127.0.0.1的8081端口
                TcpClient client = new TcpClient(ipAddr.ToString(), port); // Create a new connection  
                //输出一条信息connected to server
                Console.WriteLine("connected to server");                                                     
                
                // send 0 to the server
                byte command = 0;
                //client对象有GetStream方法，返回一个用于读写数据的NetworkStream对象，与client相关联
                //NetworkStream stream是一个流，通过TcpClient连接到服务器
                using (NetworkStream stream = client.GetStream())
                {
                    //将command的值写入stream中，Flush将数据立即发送到远程主机
                    stream.WriteByte(command);
                    stream.Flush();

                    // get greeting message from the server 从服务器获取问候消息
                    //这一行代码创建了一个 StreamReader 对象，用于从 NetworkStream 对象中读取数据并将其解码为 UTF-8 编码的文本。
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                    //从StreamReader对象中读取一行文本并将其存储在response字符串变量中。
                    string response = reader.ReadLine();

                    Console.WriteLine("Received string: " + response);
                }

                // send 1 to the server
                command = 1;

                // the name of the file that we ask the server to read
                // 我们要求服务器读取的文件的名称
                string fileName = "example.txt";

                // text need to be sent as binary number 文本需要作为二进制数发送
                // so, we store file name in a binary aray 因此，我们将文件名存储在二进制数组中
                // 将 fileName 这个字符串转换为一个字节数组 fileNameBytes，采用的编码方式为 UTF-8
                byte[] fileNameBytes = Encoding.UTF8.GetBytes(fileName);

                // store the number of bytes representing the file name as a byte array with 4 elements as int is 4 bytes long
                //将表示文件名的字节数存储为具有 4 个元素的字节数组，因为 int 的长度为 4 个字节
                //fileNameBytes.Length为int类型11，一个int对应4字节，所以用一个长度为4的数组来保存文件名的长度。
                byte[] fileNameLengthBytes = BitConverter.GetBytes(fileNameBytes.Length);

                // Create a new byte array for holding the data to be sent to the server 创建一个新的字节数组来保存要发送到服务器的数据
                // element 0 is the command
                // element 1 to 4 is the length of the bytes representing the file name 元素1到4是代表文件名的字节长度
                // the remaining elements represent the file name 其余元素代表文件名
                // data数组的长度将是5加上文件名字节数组的长度。
                byte[] data = new byte[5 + fileNameBytes.Length];

                // Copy the command, the length and the filename to the array to be sent to the server
                // 将命令、长度和文件名复制到要发送到服务器的数组中
                // 将命令放在data中的第一个元素中
                data[0] = command;
                //第一个参数为要复制的源数组，第二个参数0为从第几个元素开始复制，第三个参数表示要复制到的数组，第四个参数1表示从1开始复制过来，最后一个参数为要复制的元素数量，这里为4

                Array.Copy(fileNameLengthBytes, 0, data, 1, fileNameLengthBytes.Length);
                Array.Copy(fileNameBytes, 0, data, 5, fileNameBytes.Length);

                client = new TcpClient(ipAddr.ToString(), port); // Create a new connection  
                Console.WriteLine("connected to server");

                using (NetworkStream stream = client.GetStream())
                {
                    // Send the data to the server
                    // 将data写入流发送给服务器。 data是写入的数据，0是起始位置，第三个是数据的长度
                    stream.Write(data, 0, data.Length);
                    stream.Flush();

                    // the StreamReader object is used to receive reply from the server StreamReader 对象用于接收来自服务器的回复
                    StreamReader reader = new StreamReader(stream);
                    string line;

                    // print out the contents of the file received from the server
                    // 将服务器的回复逐行输出到控制台
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }

                    reader.Close();
                    stream.Close();
                    client.Close();

                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

        }
    }
}
