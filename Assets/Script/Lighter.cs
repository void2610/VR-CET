using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighter : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem ps;

    private bool isEnabled = false;
    

    public void ChangeEnabled(){
        isEnabled = !isEnabled;
        ChangeParticleSystemPlaying();
    }

    private void ChangeParticleSystemPlaying(){
        if(ps.isPlaying){
            ps.Stop();
        }
        else{
            ps.Play();
        }
    }



    void Start()
    {
        isEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)){
            ChangeEnabled();
        }
    }
}
