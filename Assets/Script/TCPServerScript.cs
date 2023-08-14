using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

public class TCPServerScript : MonoBehaviour
{
    //================================================================================
    // 変数
    //================================================================================
    // この IP アドレスとポート番号はクライアント側と統一すること
    public string m_ipAddress = "192.168.0.118";
    public int m_port = 10001;

    private TcpListener m_tcpListener;
    private TcpClient m_tcpClient;
    private NetworkStream m_networkStream;

    private string m_message = string.Empty; // クライアントから受信した文字列

    //================================================================================
    // 関数
    //================================================================================
    /// <summary>
    /// 初期化する時に呼び出されます
    /// </summary>
    private void Awake()
    {
        // クライアントから文字列を受信する処理を非同期で実行します
        // 非同期で実行しないと接続が終了するまで受信した文字列を UI に表示できません
        Task.Run(() => OnProcess());
    }

    /// <summary>
    /// クライアント側から通信を監視し続けます
    /// </summary>
    private void OnProcess()
    {
        byte[] TCP_Data = System.Text.Encoding.ASCII.GetBytes("Unity to SPRESENSE");

        var ipAddress = IPAddress.Parse(m_ipAddress);
        m_tcpListener = new TcpListener(ipAddress, m_port);
        m_tcpListener.Start();

        Debug.Log("待機中");

        // クライアントからの接続を待機します
        m_tcpClient = m_tcpListener.AcceptTcpClient();

        Debug.Log("接続完了");

        // クライアントからの接続が完了したので
        // クライアントから文字列が送信されるのを待機します
        m_networkStream = m_tcpClient.GetStream();

        while (true)
        {
            var buffer = new byte[256];
            var count = m_networkStream.Read(buffer, 0, buffer.Length);

            // クライアントからの接続が切断された場合は
            if (count == 0)
            {
                Debug.Log("切断");

                // 通信に使用したインスタンスを破棄して
                OnDestroy();

                // 再度クライアントからの接続を待機します
                Task.Run(() => OnProcess());

                break;
            }
            else
            {

                // クライアントから文字列を受信した場合はログに出力します
                var message = Encoding.UTF8.GetString(buffer, 0, count);
                Debug.LogFormat("受信成功：{0}", message);

                // データ送信（応答）
                m_networkStream.Write(TCP_Data, 0, TCP_Data.Length);
            }
        }
    }

    /// <summary>
    /// 破棄する時に呼び出されます
    /// </summary>
    private void OnDestroy()
    {
        // 通信に使用したインスタンスを破棄します
        m_networkStream?.Dispose();
        m_tcpClient?.Dispose();
        m_tcpListener?.Stop();
    }
}