using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Filtering;

public class BoxInteraction : MonoBehaviour, IXRSelectFilter
{
    private bool socketed = false;
    public GameObject boxLight;
    // Start is called before the first frame update
    
    public void LightUpBox(){
        if(!socketed) {
            boxLight.SetActive(true);
        }
    }

    public void OnBoxRemoved(SelectExitEventArgs arg0) {
        socketed = false;
    }

    public void OnBoxSocketed(SelectEnterEventArgs arg0) {
        socketed = true;
        boxLight.SetActive(false);
    }

    public bool canProcess => isActiveAndEnabled;

    public bool Process(IXRSelectInteractor interactor, IXRSelectInteractable interactable)
    {
        return boxLight.activeSelf;
    }
}
