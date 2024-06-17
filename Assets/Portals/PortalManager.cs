using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public GameObject portalCamera;
    public Renderer portalSurfaceRenderer;
    public Material portalMaterial; // Reference to the portal's material

    public void EnablePortals()
    {
        portalCamera.SetActive(true);
        portalSurfaceRenderer.material = portalMaterial; // Ensure the portal material is set
        Debug.Log("Portals Enabled");
    }

    public void DisablePortals()
    {
        portalCamera.SetActive(false);
        portalSurfaceRenderer.material = null; // Optionally set to null or a non-portal material
        Debug.Log("Portals Disabled");
    }
}
