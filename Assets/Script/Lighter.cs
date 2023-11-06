using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighter : InteractiveObjectBase
{
    [SerializeField]
    private ParticleSystem ps;
    [SerializeField]
    GameObject rightHand;
    [SerializeField]
    GameObject leftHand;

    public override void OnInteractionStart(){
        if(!ps.isPlaying) ps.Play();
    }

    public override void OnInteractionEnd(){
        if(ps.isPlaying) ps.Stop();
    }

    protected override void Start(){
        base.Start();
        ps.Stop();
    }

    protected override void Update()
    {
        base.Update();
    }
}
