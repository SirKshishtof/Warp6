using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Network
{
    public class Net
    {
        private static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static Socket hostSocet = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        private static bool ValidateIP(string IP) // 192.168.1.7.
        {
            Regex regexIP1 = new Regex(@"^((1\d\d|2([0-4]\d|5[0-5])|\d\d?)\.?){4}$");
            Regex regexIP2 = new Regex(@"^\d\d?\d?\.\d\d?\d?\.\d\d?\d?\.\d\d?\d?\z");

            if (regexIP1.IsMatch(IP) && regexIP2.IsMatch(IP)) return true;
            else return false;
        }
        private static bool ValidatePort(string port)
        {
            //1 до 65535
            Regex regexIP1 = new Regex(@"^([1-5]\d\d\d\d|6([0-4]\d\d\d|5([0-4]\d\d|5([0-2]\d|3[0-5])))|[1-9]\d?\d?\d?)\z");
            if (regexIP1.IsMatch(port)) return true;
            else return false;
        }
        private static async Task SendData(byte[] message) => await socket.SendAsync(message);
        public static void SocketClose() => hostSocet.Close();
        public static async Task<List<byte>> ReceiveData()
        {
            var buffer = new byte[1];
            var response = new List<byte>();
            try
            {
                do
                {
                    await socket.ReceiveAsync(buffer);
                    response.Add(buffer[0]);
                }
                while (socket.Available > 0);
            }
            catch
            {
                response.Clear();
                response.Add(255);
            }
            return response;
        }
        public static async Task CreateHostAsync()
        {
            string host = Dns.GetHostName();
            IPAddress addresses = Dns.GetHostAddresses(host)[1];
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Any, 55555);
            //IPEndPoint ipPoint = new IPEndPoint(addresses, 55555);

            hostSocet.Bind(ipPoint);
            hostSocet.Listen(10);
            socket = await hostSocet.AcceptAsync();// получаем подключение в виде NetClient

            await socket.SendAsync(Encoding.UTF8.GetBytes("5555\n"));
        }
        public static string GetSocetInfo()
        {
            return hostSocet.LocalEndPoint.ToString();
        }
        public static async Task<bool> ConnectToHostAsync(string IP, string port)
        {
            if (ValidateIP(IP) && ValidatePort(port))
            {
                int portInt = int.Parse(port);
                try
                {
                    await socket.ConnectAsync(IP, portInt);
                    return true;
                }
                catch (SocketException)
                {
                    return false;
                }
            }
            else return false;
        }
    }    
}

