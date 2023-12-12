using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CigaretHead : MonoBehaviour
{
    private Cigaret cigaret;
    void Start()
    {
        cigaret = GetComponentInParent<Cigaret>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            cigaret.StartSmoking();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "LighterTrigger")
        {
            cigaret.StartSmoking();
        }
    }
}
