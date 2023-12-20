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

    private float exhaustRate = 0;

    public bool isSmoking = false;

    public void BreatheSmoke()
    {
        smokeAmount += 150;
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
        var em = ps.emission;
        if (server.IsConnected())
        {
            float normalizedCo2 = Map((int)(server.GetCo2()), 0, 3200, 0, 400);
            Debug.Log(normalizedCo2);

            if (normalizedCo2 > 100)
            {
                exhaustRate = normalizedCo2;
            }
            else
            {
                exhaustRate = 0;
            }

            em.rateOverTime = exhaustRate;
        }
        else
        {
            em.rateOverTime = 0;
        }


        if (smokeAmount > 0 && !isSmoking)
        {
            ps.Play();
            smokeAmount -= exhaustRate;
        }
        else if (smokeAmount <= 0 || isSmoking)
        {
            ps.Stop();
        }
        //Debug.Log(smokeAmount);
    }
}
