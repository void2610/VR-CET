using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighter : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem ps;

    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstick, OVRInput.Controller.LTouch) || OVRInput.Get(OVRInput.Button.PrimaryThumbstick, OVRInput.Controller.RTouch))
        {
            if(!ps.isPlaying){
                ps.Play();
            }
        }
        else{
            if(ps.isPlaying){
                ps.Stop();
            }
        }
    }
}
