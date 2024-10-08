using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    public Animator animator; 
    public Transform target;  
    public float detectionRange = 0.2f; 

    private void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        if (target == null)
        {
            Debug.LogError("Target nesetat :(");
        }
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= detectionRange)
        {
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }
}

