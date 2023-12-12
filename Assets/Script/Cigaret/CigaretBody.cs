using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CigaretBody : MonoBehaviour
{
    private float startLength;
    private float endLength = 0.1f;

    [SerializeField]
    private Cigaret _cigaret;
    void Start()
    {
        startLength = this.transform.localScale.y;
        _cigaret = this.transform.parent.parent.parent.GetComponent<Cigaret>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_cigaret.time < _cigaret.BURNINGTIME){     
            float ratio = 1 - (_cigaret.time / _cigaret.BURNINGTIME);
            float newLength = startLength * ratio;
            if(newLength > endLength){
                this.transform.localScale = new Vector3(this.transform.localScale.x, newLength, this.transform.localScale.z);
            }
            else{
                this.transform.localScale = new Vector3(this.transform.localScale.x, endLength, this.transform.localScale.z);
            }
            
        }
    }
}
