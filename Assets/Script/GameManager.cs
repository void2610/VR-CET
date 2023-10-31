using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction.HandGrab;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private HandGrabInteractor handGrabRight;
    [SerializeField]
    private HandGrabInteractor handGrabLeft;

    //シングルトン実装
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public GameObject[] GetGrabbings()
    {
        GameObject[] grabbings = new GameObject[2];

        grabbings[0] = handGrabRight.TargetInteractable != null? (handGrabRight.TargetInteractable as MonoBehaviour).gameObject.transform.parent.gameObject : null;
        grabbings[1] = handGrabLeft.TargetInteractable != null? (handGrabLeft.TargetInteractable as MonoBehaviour).gameObject.transform.parent.gameObject : null;

        return grabbings;
    }
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
