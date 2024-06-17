using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameInteraction : MonoBehaviour
{
    public GameObject flame;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            print("Fire should be put out!");
            flame.SetActive(false);
        }
            
    }
}
