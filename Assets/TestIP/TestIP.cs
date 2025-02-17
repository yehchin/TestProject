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
        int port = 3241;

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

        void Listen()
        {
            if (listener != null)
            {
                return;
            }

            string ip = "192.168.1.102";
            // string ip = "127.0.0.1";
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse(ip), port);
            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Blocking = false;
            listener.Bind(endpoint);
            listener.Listen(20);
        }

        bool connected = false;
        void Connect()
        {
            if (connected)
            {
            }
            else
            {
                try
                {
                    //輸出後可正常執行
                    string ip = "36.237.205.243";
                    // string ip = "192.168.1.102";
                    IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse(ip), port);
                    client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    client.Blocking = false;
                    client.NoDelay = true;
                    client.Connect(endpoint);
                    connected = true;
                    return;
                }
                catch (SocketException e)
                {
                    Debug.Log(e.ErrorCode);
                }
            }
        }
    }
}
