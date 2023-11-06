using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighter : InteractiveObjectBase
{
    [SerializeField]
    private ParticleSystem ps;
    [SerializeField]
    GameObject lighterTrigger;

    public override void OnInteractionStart(){
        if(!ps.isPlaying) ps.Play();
        lighterTrigger.SetActive(true);
    }

    public override void OnInteractionEnd(){
        if(ps.isPlaying) ps.Stop();
        lighterTrigger.SetActive(false);
    }

    protected override void Start(){
        base.Start();
        ps.Stop();
        lighterTrigger.SetActive(false);
    }

    protected override void Update()
    {
        base.Update();
    }
}
