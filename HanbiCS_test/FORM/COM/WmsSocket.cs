using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace COM
{
    public class WmsSocket
    {
        private string ETX = "\nend\n";

        Socket socket = null;

        public JObject Connect(int port, JObject requestJO)
        {
            try
            {
                string requestString = JsonConvert.SerializeObject(requestJO);

                byte[] recv = new byte[0];
                int ret = 0;

                byte[] etx = Encoding.UTF8.GetBytes(ETX);
                byte[] encSendByte;
                byte[] sendByte = null;
                byte[] recvByte = new byte[16 * 1024];
                string utf8String = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(requestString));
                encSendByte = Encoding.UTF8.GetBytes(utf8String);
                sendByte = AddBytes(encSendByte, etx);

                string ip = System.Configuration.ConfigurationSettings.AppSettings["WmsSocketIp"];
                IPAddress ipAddress = IPAddress.Parse(ip);
                IPEndPoint endPoint = new IPEndPoint(ipAddress, port);
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                if (!socket.Connected)
                {
                    IAsyncResult result = socket.BeginConnect(ip, port, null, null);
                    bool success = result.AsyncWaitHandle.WaitOne(3000, true);
                    if (success == false)
                    {
                        return null;
                    }
                }


                // 서버 접속
                if (socket.Connected)
                {
                    //socket.Send(sendByte);
                    // 전송
                    if (Send(sendByte) <= 0)
                    {
                        // 소켓 종료
                        socket.Close();
                        socket = null;
                        return null;
                    }

                    // 수신
                    ret = Recv(recvByte, ref recv);
                    //ret = socket.receive(recvbyte);
                    if (ret <= 0)
                    {
                        // 소켓 종료
                        return null;
                    }
                }
                else
                {
                    return null;
                }

                string recvString = Encoding.UTF8.GetString(recv, 0, recv.Length);
                string resultString = recvString.Replace(ETX, "");

                JObject jo = JsonConvert.DeserializeObject<JObject>(resultString);

                return jo;
            }
            catch
            {
                return null;
            }
            finally
            {
                if (socket != null)
                {
                    socket.Close();
                    socket = null;
                }
            }
        }

        private int Send(byte[] message)
        {
            try
            {
                // 보낸 Byte 수
                int total = 0;
                // 전체 Byte 수
                int size = message.Length;
                // 보내고 남은 Byte 수
                int leftSize = size;
                // 보낸 Byte 수
                int sendSize = 0;

                // 보낼 자료가 남아 있으면 보낸다.
                while (total < size)
                {
                    // 자료 전송
                    sendSize = socket.Send(message, total, leftSize, SocketFlags.None);
                    // 보낸 Byte 수
                    total += sendSize;
                    // 남은 Byte 수
                    leftSize -= sendSize;
                }

                // 보낸 Byte 수
                return total;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        private int Recv(byte[] receiveBytes, ref byte[] recv)
        {
            // 종료 문자 비교용
            byte[] endMarkBytes = new byte[5];
            byte[] recvEtxBytes = new byte[5];
            int endMarkLength = ETX.Length;
            endMarkBytes = Encoding.UTF8.GetBytes(ETX);

            try
            {
                int response = 0;
                using (MemoryStream ms = new MemoryStream())
                {
                    while (true)
                    {
                        response = socket.Receive(receiveBytes, receiveBytes.Length, SocketFlags.None);
                        if (response == 0)
                        {
                            return -1;
                        }

                        ms.Write(receiveBytes, 0, response);
                        ms.Seek(-endMarkLength, SeekOrigin.End);
                        ms.Read(recvEtxBytes, 0, endMarkLength);

                        if (recvEtxBytes.SequenceEqual(endMarkBytes))
                        {
                            ms.SetLength(ms.Length - endMarkLength);
                            break;
                        }
                    }

                    recv = ms.ToArray();
                    return recv.Length;
                }
            }
            catch (SocketException ex)
            {
                return -1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        private byte[] AddBytes(byte[] a, byte[] b)
        {
            byte[] c = new byte[a.Length + b.Length];
            a.CopyTo(c, 0);
            b.CopyTo(c, a.Length);
            return c;
        }


    }
}
