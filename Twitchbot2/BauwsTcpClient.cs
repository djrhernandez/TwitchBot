using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Twitchbot2
{
    public class BauwsTcpClient
    {
        private TcpClient tcpClient;
        private StreamReader inputStream;
        private StreamWriter outputStream;
        private int _minimumMsBetweenSends;
        private DateTime timeOfLastSend;
    
        public BauwsTcpClient(string ip, int port, int minimumMsBetweenSends)
        {
            tcpClient = new TcpClient(ip, port);
            inputStream = new StreamReader(tcpClient.GetStream());
            outputStream = new StreamWriter(tcpClient.GetStream());
            _minimumMsBetweenSends = minimumMsBetweenSends;
            timeOfLastSend = DateTime.MinValue;
        }

        public void WriteLine(string message)
        {
            //Can I use .TotalMilliseconds???
            //Look into for the future
            //Feel like .Milliseconds will cause an error when reading time
            //although this is just off hypothesis not from debug testing
            //run to ensure
            int timeSpan = (DateTime.Now - timeOfLastSend).Milliseconds;
            if(timeSpan < _minimumMsBetweenSends)
            {
                Thread.Sleep(_minimumMsBetweenSends - timeSpan);
            }
            timeOfLastSend = DateTime.Now;

            outputStream.WriteLine(message);
            outputStream.Flush();
        }

        public string ReadNextLine_BLOCKING()
        {
            return inputStream.ReadLine();
        }
    }
}
