using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using TMPro;
using UnityEngine;

namespace Demo
{
    public class TestIP : MonoBehaviour
    {
        public TextMeshProUGUI text;
        StringBuilder stringBuilder = new StringBuilder();

        List<Socket> connecter = new();
        Socket listener;
        Socket client;
        string hostIp = "";
        int port = 8888;

        void UpdadteUI()
        {
            stringBuilder.Clear();
            if (listener != null)
            {
                stringBuilder.Append("listener");
                stringBuilder.AppendLine();
                stringBuilder.Append(((IPEndPoint)listener.LocalEndPoint).Address.ToString());
                stringBuilder.AppendLine();
                stringBuilder.Append(connecter.Count);
                stringBuilder.AppendLine();
                stringBuilder.Append("------------");
                stringBuilder.AppendLine();
            }

            foreach (var item in connecter)
            {
                stringBuilder.Append(item.RemoteEndPoint);
                stringBuilder.AppendLine();
            }

            text.text = stringBuilder.ToString();
        }

        // Update is called once per frame
        void Update()
        {
            UpdadteUI();
            if (Input.GetKeyDown(KeyCode.A))
            {
                Connect();
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                Listen();
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                ServerShutDown();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                ClientShutDown();
            }

            // for (int i = 0; i < connecter.Count; i++)
            // {
            //     if (connecter[i].Receive(new byte[1]) == 0)
            //     {
            //         connecter.RemoveAt(i);
            //         i--;
            //     }
            // }
            // Debug.Log("1");
            ClientReciveData();
            ServerCheckConnect();
            // Debug.Log("2");

            while (true)
            {
                try
                {
                    Socket socket = listener.Accept();

                    if (socket != null)
                    {
                        connecter.Add(socket);
                    }
                    else
                    {
                        return;
                    }
                }
                catch
                {
                    return;
                }
            }

        }

        public static string GetFirstBindIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            return null;
        }

        void ServerShutDown()
        {
            for (int i = 0; i < connecter.Count; i++)
            {
                if (connecter[i].Poll(1, SelectMode.SelectWrite))
                {
                    connecter[i].Shutdown(SocketShutdown.Both);
                    connecter[i].Close();
                    connecter.RemoveAt(i);
                    i--;
                    Debug.Log("shutdown");
                }
            }
        }

        void ClientShutDown()
        {
            if (client == null)
            {
                return;
            }

            if (client.Poll(1, SelectMode.SelectWrite))
            {
                client.Shutdown(SocketShutdown.Both);
                client.Close();
                client = null;
            }
        }

        void Listen()
        {
            if (listener != null)
            {
                return;
            }

            try
            {
                // string ip = "192.168.1.102";
                string ip = hostIp = GetFirstBindIPAddress();
                IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse(ip), port);
                listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                listener.Blocking = false;
                listener.Bind(endpoint);
                listener.Listen(1);
            }
            catch
            {
                Debug.Log("listen error");
            }
        }

        void ClientReciveData()
        {
            if (client != null)
            {
                Debug.Log(client.Poll(1, SelectMode.SelectRead));
                Debug.Log(client.Poll(1, SelectMode.SelectWrite));
                if (client.Poll(1, SelectMode.SelectRead) && client.Available == 0)
                {
                    client.Shutdown(SocketShutdown.Both);
                    client.Close();
                    client = null;
                }
            }
        }
        void ServerCheckConnect()
        {
            for (int i = 0; i < connecter.Count; i++)
            {
                if (connecter[i].Poll(1, SelectMode.SelectRead) && connecter[i].Available == 0)
                {
                    connecter[i].Shutdown(SocketShutdown.Both);
                    connecter[i].Close();
                    connecter.RemoveAt(i);
                    i--;
                    Debug.Log("shutdown");
                }
            }
        }

        void Connect()
        {
            if (client != null)
            {
            }
            else
            {
                try
                {
                    //輸出後可正常執行
                    // string ip = "36.237.205.243";
                    string ip = hostIp;
                    IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse(ip), port);
                    client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    client.Blocking = false;
                    client.NoDelay = true;

                    // SocketAsyncEventArgs receiveArgs = new SocketAsyncEventArgs();
                    // receiveArgs.Completed += ClientSocketEvnet;
                    // client.ReceiveAsync(receiveArgs);
                    client.Connect(endpoint);
                    return;
                }
                catch (SocketException e)
                {
                }
            }
        }

        void ClientSocketEvnet(object sender, SocketAsyncEventArgs e)
        {
            Debug.Log(e.SocketError);
        }
    }
}
