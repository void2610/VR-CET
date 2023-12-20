using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System;

public class TCPServer : MonoBehaviour
{
    //シングルトン実装
    public static TCPServer instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private int co2 = -1;
    private TcpListener tcpListener = null;
    private TcpClient tcpClient = null;
    private NetworkStream networkStream = null;

    public bool IsConnected()
    {
        return co2 != -1;
    }

    public int GetCo2()
    {
        return co2;
    }

    private void Start()
    {
        Task.Run(() => OnProcess());
    }

    private void OnProcess()
    {
        var ipAddress = IPAddress.Parse("192.168.10.50");
        tcpListener = new TcpListener(ipAddress, 10001);

        tcpListener.Start();
        Debug.Log("接続待機中");
        tcpClient = tcpListener.AcceptTcpClient();
        Debug.Log("接続完了");
        networkStream = tcpClient.GetStream();

        while (true)
        {
            try
            {
                var buffer = new byte[512];
                var count = networkStream.Read(buffer, 0, buffer.Length);

                if (count == 0)
                {
                    Debug.Log("切断 再試行");
                    Task.Run(() => OnProcess());
                    break;
                }
                else
                {
                    var message = Encoding.UTF8.GetString(buffer, 0, count);
                    if (int.TryParse(message, out int result))
                    {
                        co2 = result;
                        //Debug.Log(co2);
                    }
                    else
                    {
                        co2 = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogError("エラー: " + ex.Message);
                if (ex is System.IO.IOException)
                {
                    Debug.Log("切断");
                    Destroy(this.gameObject);
                }
            }
        }
    }

    private void OnDestroy()
    {
        networkStream?.Dispose();
        tcpClient?.Dispose();
        tcpListener?.Stop();
    }
}