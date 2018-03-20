using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace OanTuXi_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 995);
            EndPoint remote = (EndPoint)ipe;

            for (int i = 0; i < 100000; i++)
            {
                Console.WriteLine("Moi ban chon KEO(0) BUA(1) BAO(2), vui long nhap so theo thu tu: ");
                int S = int.Parse(Console.ReadLine());
                
                if (S == 0)
                {

                    Console.WriteLine("Ban chon 'Keo'.");
                    byte[] sendData = Encoding.ASCII.GetBytes("0");

                    server.SendTo(sendData, remote);
                    byte[] receiveData = new byte[20];
                    server.ReceiveFrom(receiveData, ref remote);
                    Console.WriteLine("Ket qua la: {0}", Encoding.ASCII.GetString(receiveData));
                }
                if (S == 1)
                {

                    Console.WriteLine("Ban chon 'Bua'.");
                    byte[] sendData = Encoding.ASCII.GetBytes("1");

                    server.SendTo(sendData, remote);
                    byte[] receiveData = new byte[20];
                    server.ReceiveFrom(receiveData, ref remote);
                    Console.WriteLine("Ket qua la: {0}", Encoding.ASCII.GetString(receiveData));
                }
                if (S==2)
                {

                    Console.WriteLine("Ban chon 'Bao'.");
                    byte[] sendData = Encoding.ASCII.GetBytes("2");

                    server.SendTo(sendData, remote);
                    byte[] receiveData = new byte[20];
                    server.ReceiveFrom(receiveData, ref remote);
                    Console.WriteLine("Ket qua la: {0}", Encoding.ASCII.GetString(receiveData));
                }
            }
        }
    }
}
