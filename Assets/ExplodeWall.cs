using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ExplodeWall : MonoBehaviour
{
    [SerializeField] List<Rigidbody> bricks = new List<Rigidbody>();

    public void OnExplosiveAdded(SelectEnterEventArgs arg0)
    {
        foreach (Rigidbody brick in bricks)
        {
            brick.isKinematic = false;
            brick.constraints = RigidbodyConstraints.None;

            int power = 200;
            brick.AddRelativeForce(Random.onUnitSphere * power);
        }
    }
}
