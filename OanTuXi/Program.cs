using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace OanTuXi
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint ipserver = new IPEndPoint(IPAddress.Any, 995);
            server.Bind(ipserver);
            EndPoint remote = ipserver;
            
            

            
            while (true)
            {
                byte[] receiveData = new byte[20];
                server.ReceiveFrom(receiveData, ref remote);
                int clientResult = Convert.ToInt32(Encoding.ASCII.GetString(receiveData));
                Random rd = new Random();
                int serverResult = rd.Next(0, 3);
                switch (serverResult)
                {
                    case 0:
                        Console.WriteLine("Server chon: Keo");
                        break;
                    case 1:
                        Console.WriteLine("Server chon: Bua");
                        break;
                    case 2:
                        Console.WriteLine("Server chon: Bao");
                        break;

                }
                
                    if ((serverResult == 0 && clientResult == 0) || (serverResult == 1 && clientResult == 1) || (serverResult == 2 && clientResult == 2))
                    {
                        byte[] sendData = Encoding.ASCII.GetBytes("Draw");
                        
                        server.SendTo(sendData, remote);
                    }
                    if ((serverResult == 0 && clientResult == 2) || (serverResult == 1 && clientResult == 0) || (serverResult == 2 && clientResult == 1))
                    {
                        byte[] sendData = Encoding.ASCII.GetBytes("Lose");
                        server.SendTo(sendData, remote);
                    }
                    if ((serverResult == 2 && clientResult == 0) || (serverResult == 0 && clientResult == 1) || (serverResult == 1 && clientResult == 2))
                    {
                        byte[] sendData = Encoding.ASCII.GetBytes("Win");
                        server.SendTo(sendData, remote);
                    }
                }
            }
        }
    }

