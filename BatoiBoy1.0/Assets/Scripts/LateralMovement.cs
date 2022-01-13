using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateralMovement : MonoBehaviour
{
    public Vector3 destination;
    public float time;

    void Start ()
    {
        iTween.MoveTo (gameObject, iTween.Hash ("position", destination,
            "time", time,
            "easetype", iTween.EaseType.easeInOutSine,
            "looptype", iTween.LoopType.pingPong));
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
