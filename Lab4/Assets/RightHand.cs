using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHand : MonoBehaviour
{
    public Animator handAnimator1;

    void Update()
    { 
            if (Input.GetKeyDown(KeyCode.F))
        {
            handAnimator1.SetTrigger("Trigger");  
        }
    }
}