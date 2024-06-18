using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MoveObject : MonoBehaviour

{
    private bool _hasOccurred = false;
    private bool _canOccur = false;

    /*
     * Moving object variables
     */

    public Transform objectToMove; // The object to move
    public Transform target; // The target position to move towards
    public float speed = 1.0f; // The speed at which the object moves

    private bool isMoving = false;

    private void Start()
    {
        Invoke(nameof(canOccur), 2); // Wait for initial gaze interaction (bug?) to be finished on startup.
    }

    private void canOccur ()
    {
        _canOccur = true;
    }

    public void MoveCube()
    {
        if (!_hasOccurred && _canOccur)
        {
            print("Cube moved!");
            _hasOccurred = true;
            StartMoving();
        }
    }

    /*
     * Code for moving object
     */
    void Update()
    {
        if (isMoving && objectToMove != null)
        {
            // Move the object towards the target position
            objectToMove.position = Vector3.Lerp(objectToMove.position, target.position, speed * Time.deltaTime);

            // Check if the object is close enough to the target position
            if (Vector3.Distance(objectToMove.position, target.position) < 0.01f)
            {
                objectToMove.position = target.position;
                isMoving = false; // Stop moving once the target is reached
            }
        }
    }

    // Call this function to start moving the object
    public void StartMoving()
    {
        if (objectToMove != null && target != null)
        {
            isMoving = true;
        }
    }

}
