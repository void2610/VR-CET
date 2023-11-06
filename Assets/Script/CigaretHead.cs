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

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            cigaret.StartSmoking();
            Debug.Log("aa");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "LighterTrigger")
        {
            cigaret.StartSmoking();
        }
    }
}
