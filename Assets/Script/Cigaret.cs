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


    public bool isSmoking{private set; get; } = false;
    public float time{private set; get; } = 0.0f;
    [SerializeField]
    public float exhaustRate{private set; get; } = 1.0f;
    public const float BURNINGTIME = 10.0f;

    public void StartSmoking(){
        if(!isSmoking){
            isSmoking = true;
            cigaretFire.GetComponent<Renderer>().material = fireMaterial;
            ps.Play();

            
        }
    }

    public void StopSmoking(){
        if(isSmoking){
            isSmoking = false;
            cigaretFire.GetComponent<Renderer>().material = unfireMaterial;
            ps.Stop();
        }
    }

    void Start()
    {
        StopSmoking();
    }

    // Update is called once per frame
    void Update()
    {
        if(isSmoking){
            ps.Play();
            time += Time.deltaTime; 
            Debug.Log(ps.emissionRate);
        }
        else{
            ps.Stop();
        }


        if(time >= BURNINGTIME){
            StopSmoking();
        }
    }
}
