using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    public Transform xrOrigin; // Reference to XR Origin (XR Rig)
    public Transform receiver;

    private bool playerIsOverlapping = false;

    // Update is called once per frame
    void Update()
    {
        if (playerIsOverlapping)
        {
            print("Player is overlapping");
            Vector3 portalToPlayer = xrOrigin.position - transform.position;
            float dotProduct = Vector3.Dot(transform.forward, portalToPlayer);

            // Draw debug rays
            Debug.DrawRay(transform.position, transform.forward * 2, Color.red); // Portal forward direction
            Debug.DrawRay(transform.position, portalToPlayer, Color.blue);       // Portal to player vector

            // If this is true: The player has moved across the portal
            if (dotProduct < 0f)
            //if (true)
            {

                // Teleport the XR Origin
                float rotationDiff = -Quaternion.Angle(transform.rotation, receiver.rotation);
                rotationDiff += 180;
                xrOrigin.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                xrOrigin.position = receiver.position + positionOffset;

                // Reset player overlapping state
                playerIsOverlapping = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            print("PLAYER: ENTER");
            playerIsOverlapping = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            print("PLAYER: EXIT");
            playerIsOverlapping = false;
        }
    }
}
