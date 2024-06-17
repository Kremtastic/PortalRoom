using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCamera; // Main camera, typically the center eye anchor in XR rig
    public Transform portal;
    public Transform otherPortal;

    // Update is called once per frame
    void Update()
    {
        // Calculate the player offset from the other portal
        Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;

        // Position the portal camera based on the player's offset
        transform.position = portal.position + playerOffsetFromPortal;

        // Calculate the angular difference between the portal rotations
        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);

        // Create the rotational difference
        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);

        // Calculate the new camera direction
        Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }
}
