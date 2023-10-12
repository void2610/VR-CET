using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject cigaret;
    private Cigaret _cigaret;
    void Start()
    {
        _cigaret = cigaret.GetComponent<Cigaret>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
                _cigaret.StartSmoking();
        }
    }
}
