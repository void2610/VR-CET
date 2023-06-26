using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cigaret : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem ps;

    public bool isSmoking{private set; get; } = false;

    public void StartSmoking(){
        isSmoking = true;
    }

    public void StopSmoking(){
        isSmoking = false;
    }

    void Start()
    {
        ps.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(isSmoking){
            ps.Play();
        }
        else{
            ps.Stop();
        }
    }
}
