using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SophieWave : MonoBehaviour
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
