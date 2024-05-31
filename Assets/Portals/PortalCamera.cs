using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{

    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;

    // Update is called once per frame
    void Update()
    {
        Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
        transform.position = portal.position + playerOffsetFromPortal;

        float angularDifferenceBetweenPoratlRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);

        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPoratlRotations, Vector3.up);
        Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;



        transform.rotation = Quaternion.LookRotation(Quaternion.Euler(0, 180, 0) * newCameraDirection, Vector3.up);
    }
}
