using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System;

public class TCPServerScript : MonoBehaviour
{
    public string m_ipAddress = "192.168.0.118";
    public int m_port = 10001;

    private TcpListener m_tcpListener;
    private TcpClient m_tcpClient;
    private NetworkStream m_networkStream;

    private string m_message = string.Empty; // クライアントから受信した文字列

    private void Awake()
    {
        //非同期
        Task.Run(() => OnProcess());
    }

    private void OnProcess()
    {
        byte[] TCP_Data = System.Text.Encoding.ASCII.GetBytes("Unity to SPRESENSE");

        var ipAddress = IPAddress.Parse(m_ipAddress);
        m_tcpListener = new TcpListener(ipAddress, m_port);
        m_tcpListener.Start();

        Debug.Log("待機中");

        // クライアントからの接続を待機
        m_tcpClient = m_tcpListener.AcceptTcpClient();

        Debug.Log("接続完了");

        // クライアントから文字列が送信されるのを待機
        m_networkStream = m_tcpClient.GetStream();

        while (true)
        {
            try
            {
                var buffer = new byte[256];
                var count = m_networkStream.Read(buffer, 0, buffer.Length);

                if (count == 0)
                {
                    Debug.Log("切断");
                    // 通信に使用したインスタンスを破棄
                    OnDestroy();
                    Task.Run(() => OnProcess());
                    break;
                }
                else
                {
                    // ログに出力
                    var message = Encoding.UTF8.GetString(buffer, 0, count);
                    Debug.LogFormat("受信成功：{0}", message);
                    // データ送信（応答）
                    m_networkStream.Write(TCP_Data, 0, TCP_Data.Length);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError("エラー: " + ex.Message);
                Debug.LogError("スタックトレース: " + ex.StackTrace);
                // エラーが発生しても処理を継続する場合は、ここに適切なコードを追加
            }
        }
    }

    private void OnDestroy()
    {
        m_networkStream?.Dispose();
        m_tcpClient?.Dispose();
        m_tcpListener?.Stop();
    }
}