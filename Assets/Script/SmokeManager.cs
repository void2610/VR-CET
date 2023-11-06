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

    private float smokeAmount = 0;

    private float exhaustRate = 1.0f;

    public bool isSmoking = false;

    public void BreatheSmoke(){
        smokeAmount += 100;
    }

    void Start()
    {
        server = TCPServer.instance;
    }

    float Map(float value, float start1, float stop1, float start2, float stop2)
    {
        return start2 + (stop2 - start2) * ((value - start1) / (stop1 - start1));
    }

    void Update()
    {
        if (server.IsConnected())
        {
            float normalizedCo2 = Map((float)(server.GetCo2()), 400, 5000, 0, 400);

            exhaustRate = normalizedCo2;  
            var em = ps.emission; 
            em.rateOverTime = exhaustRate;
        }
        else
        {
            exhaustRate = 0.0f;
            var em = ps.emission;
            em.rateOverTime = exhaustRate;
        }


        if(smokeAmount > 0 && !isSmoking){
            ps.Play();
            smokeAmount -= exhaustRate;
        }
        else if(smokeAmount <= 0 || isSmoking){
            ps.Stop();
        }
        Debug.Log(smokeAmount);
    }
}
