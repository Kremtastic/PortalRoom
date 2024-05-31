using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KyleWave : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Close enough");
        animator.SetTrigger("wave");
    }
}
