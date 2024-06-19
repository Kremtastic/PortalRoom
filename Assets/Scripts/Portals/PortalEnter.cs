using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalEnter : MonoBehaviour
{
    public string _sceneName;

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(_sceneName);
    }
}
