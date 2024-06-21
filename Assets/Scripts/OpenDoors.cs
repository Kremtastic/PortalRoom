using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class OpenDoor : MonoBehaviour
{
    public GameObject door_left; // Assign the left door object in the Inspector
    public GameObject door_right; // Assign the right door object in the Inspector
    public Vector3 openPositionLeft; // The position to move the left door to when opened
    public Vector3 openPositionRight; // The position to move the right door to when opened
    public float openSpeed = 2f; // Speed at which the doors open

    private Vector3 closedPositionLeft; // The original position of the left door
    private Vector3 closedPositionRight; // The original position of the right door
    private bool isOpening = false;
    private bool hasOpened = false; // Flag to track if doors have already been opened

    private bool canOpen = false;

    void Start()
    {
        if (door_left != null && door_right != null)
        {
            closedPositionLeft = door_left.transform.position;
            closedPositionRight = door_right.transform.position;
        }
        else
        {
            Debug.LogError("One or both door objects are not assigned.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasOpened || other.gameObject.tag == "Player" || other.gameObject.tag == "MainCamera")
        {
            isOpening = true;
            hasOpened = true; // Set the flag to true to prevent re-triggering
        }

        Invoke("WaitBeforeOpening", 5);
    }

    private void WaitBeforeOpening()
    { 
        canOpen = true;
    }


    void Update()
    {
        if (isOpening && canOpen)
        {
            if (door_left != null)
            {
                door_left.transform.position = Vector3.MoveTowards(door_left.transform.position, openPositionLeft, openSpeed * Time.deltaTime);
            }

            if (door_right != null)
            {
                door_right.transform.position = Vector3.MoveTowards(door_right.transform.position, openPositionRight, openSpeed * Time.deltaTime);
            }

            // Stop opening once both doors have reached their open positions
            if (Vector3.Distance(door_left.transform.position, openPositionLeft) < 0.01f && Vector3.Distance(door_right.transform.position, openPositionRight) < 0.01f)
            {
                isOpening = false;
            }
        }
    }


}
