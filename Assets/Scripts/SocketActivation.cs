using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketActivation : MonoBehaviour
{
    public GameObject _socket;

    public void EnableSocket()
    {
        _socket.SetActive(true);
    }

    public void DisableSocket()
    {
        Invoke("deactivateSocket", 0.1f);
    }

    private void deactivateSocket()
    {
        _socket.SetActive(false);
    }

}
