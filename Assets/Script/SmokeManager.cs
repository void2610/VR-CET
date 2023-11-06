using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeManager : MonoBehaviour
{
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

    private int smokeAmount = 0;
    public bool isSmoking = false;

    public void BreatheSmoke(){
        smokeAmount += 3;
    }

    void Start()
    {
        server = TCPServer.instance;
    }

    void Update()
    {
        if(smokeAmount >= 0 && !isSmoking){
            ps.Play();
            smokeAmount -= 3;
        }
        else{
            ps.Stop();
        }
        Debug.Log(smokeAmount);
    }
}
