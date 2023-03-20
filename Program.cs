using System.Net.Sockets;
using System.Threading.Tasks;
using System.IO;

namespace TwitchBot
{
    class Program
    {

        static async Task Main(string[] args)
        {
        string name = "jackdrazbot";
        int port = 6667;
        string password = "oauth:3qy8r2zyonixpazqcn1hnkrr7unh0o";
        string ip = "irc.chat.twitch.tv";

            Console.WriteLine(port);
            var tcpClient = new TcpClient();
            await tcpClient.ConnectAsync(ip, port);
            var streamReader = new StreamReader(tcpClient.GetStream());
            var streamWriter = new StreamWriter(tcpClient.GetStream()) { NewLine = "\r\n", AutoFlush = true};

            await streamWriter.WriteLineAsync($"PASS {password}");
            await streamWriter.WriteLineAsync($"NICK {name}");

            await streamWriter.WriteLineAsync("JOIN #");
            await streamWriter.WriteLineAsync("PRIVMSG #swishless :This is a test message");
        }
    }
}
