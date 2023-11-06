using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInteraction : MonoBehaviour
{
    [SerializeField]
    private bool isRightHand = true;

    private void StartInteraction(){
        GameObject[] nearestObjects = GameManager.instance.GetGrabbings();
        if(isRightHand && nearestObjects[0] == null) return; 
        if(!isRightHand && nearestObjects[1] == null) return; 

        if(isRightHand){
            nearestObjects[0].GetComponent<InteractiveObjectBase>().OnInteractionStart();
        }
        else{
            nearestObjects[1].GetComponent<InteractiveObjectBase>().OnInteractionStart();
        }
    }

    private void EndInteraction(){
        GameObject[] nearestObjects = GameManager.instance.GetGrabbings();
        if(isRightHand && nearestObjects[0] == null) return; 
        if(!isRightHand && nearestObjects[1] == null) return; 

        if(isRightHand){
            nearestObjects[0]?.GetComponent<InteractiveObjectBase>()?.OnInteractionEnd();
        }
        else{
            nearestObjects[1]?.GetComponent<InteractiveObjectBase>()?.OnInteractionEnd();
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(isRightHand){
            if (OVRInput.Get(OVRInput.Button.PrimaryThumbstick, OVRInput.Controller.RTouch))
            {
                StartInteraction();
            }
            else{
                EndInteraction();
            }
        }
        else{
            if (OVRInput.Get(OVRInput.Button.PrimaryThumbstick, OVRInput.Controller.LTouch))
            {
                StartInteraction();
            }
            else{
                EndInteraction();
            }
        }
    }
}
