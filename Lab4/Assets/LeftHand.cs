using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHand : MonoBehaviour
{
    public Animator handAnimator2;

    void Update()
    { 
            if (Input.GetKeyDown(KeyCode.G))
        {
            handAnimator2.SetTrigger("Trigger");  
        }
    }
}