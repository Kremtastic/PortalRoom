using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalEnter : MonoBehaviour
{
    public string _sceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "MainCamera")
            SceneManager.LoadScene(_sceneName);
    }
}
