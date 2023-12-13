using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cigaret : MonoBehaviour
{
    [SerializeField]
    private GameObject cigaretFire;
    [SerializeField]
    private ParticleSystem ps;
    [SerializeField]
    private Material fireMaterial;
    [SerializeField]
    private Material unfireMaterial;

    public bool canSmoke { private set; get; } = true;
    public bool isSmoking { private set; get; } = false;
    public float time { private set; get; } = 0.0f;
    public float BURNINGTIME { private set; get; } = 100.0f;

    public void StartSmoking()
    {
        if (!isSmoking && canSmoke)
        {
            isSmoking = true;
            cigaretFire.GetComponent<Renderer>().material = fireMaterial;
            ps.Play();
            time = 0;

        }
    }

    public void StopSmoking()
    {
        if (isSmoking)
        {
            isSmoking = false;
            canSmoke = false;
            cigaretFire.GetComponent<Renderer>().material = unfireMaterial;
            ps.Stop();
        }
    }

    void Start()
    {
        StopSmoking();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isSmoking)
        {
            StartSmoking();
        }

        if (isSmoking)
        {
            ps.Play();
            time += Time.deltaTime;
        }
        else
        {
            ps.Stop();
        }


        if (time >= BURNINGTIME)
        {
            StopSmoking();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SmokeManager" && isSmoking)
        {
            other.gameObject.GetComponent<SmokeManager>().isSmoking = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "SmokeManager" && isSmoking)
        {
            other.gameObject.GetComponent<SmokeManager>()?.BreatheSmoke();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "SmokeManager")
        {
            other.gameObject.GetComponent<SmokeManager>().isSmoking = false;
        }
    }
}
