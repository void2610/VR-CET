using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeManager : MonoBehaviour
{
    //シングルトン実装
    public static SmokeManager instance;

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

    [SerializeField]
    private ParticleSystem ps;

    private TCPServer server;

    public bool isSmoking = false;

    void Start()
    {
        server = TCPServer.instance;
    }

    void Update()
    {
        if(isSmoking){
            ps.Play();
        }
    }
}
