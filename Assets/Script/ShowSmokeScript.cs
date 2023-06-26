using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSmokeScript : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem ps;
    void Start()
    {
        ps.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ps.Play();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            ps.Stop();
        }
    }
}
