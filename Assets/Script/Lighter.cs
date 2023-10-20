using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighter : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem ps;
    [SerializeField]
    GameObject rightHand;
    [SerializeField]
    GameObject leftHand;    

    private float distanceToRightHand = 999;
    private float distanceToLeftHand = 999;

    void Start(){
        ps.Stop();
    }

    void Update()
    {
        
            if (OVRInput.Get(OVRInput.Button.PrimaryThumbstick, OVRInput.Controller.LTouch))
            {
                if(distanceToLeftHand < 0.08f){
                    if(!ps.isPlaying){
                        ps.Play();
                    }
                }
            }
            else{
                if(ps.isPlaying){
                    ps.Stop();
                }
            }
        
            if (OVRInput.Get(OVRInput.Button.PrimaryThumbstick, OVRInput.Controller.RTouch))
            {
                if(distanceToRightHand < 1.1f){
                    if(!ps.isPlaying){
                        ps.Play();
                    }
                }
            }
            else{
                if(ps.isPlaying){
                    ps.Stop();
                }
            }

    }

    void FixedUpdate() {
        distanceToLeftHand = Vector3.Distance(this.transform.position, leftHand.transform.position);
        distanceToRightHand = Vector3.Distance(this.transform.position, rightHand.transform.position);
        Debug.Log(distanceToRightHand);
    }
}
