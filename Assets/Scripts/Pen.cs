using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Pen : MonoBehaviour
{
    [Header("Pen Properties")]
    public Transform tip;
    public Material drawingMaterial;
    public Material tipMaterial;
    [Range(0.01f, 0.1f)]
    public float penWidth = 0.01f;
    public Color[] penColors;

    [Header("XR Interaction")]
    public XRDirectInteractor rightHandInteractor;
    public XRDirectInteractor leftHandInteractor;
    public XRGrabInteractable grabbable;

    private LineRenderer currentDrawing;
    private int index;
    private int currentColorIndex;
    private bool isDrawing = false;

    private void Start()
    {
        currentColorIndex = 0;
        tipMaterial.color = penColors[currentColorIndex];

        // Subscribe to select events
        grabbable.selectEntered.AddListener(OnSelectEntered);
        grabbable.selectExited.AddListener(OnSelectExited);
    }

    private void OnDestroy()
    {
        // Unsubscribe from select events
        grabbable.selectEntered.RemoveListener(OnSelectEntered);
        grabbable.selectExited.RemoveListener(OnSelectExited);
    }

    private void Update()
    {
        // Check if the pen is being grabbed
        bool isGrabbed = grabbable.isSelected;

        // Check if the pen is grabbed by either hand and start drawing
        if (isGrabbed && !isDrawing)
        {
            Debug.Log("Starting drawing...");
            isDrawing = true;
            Draw();
        }
        else if (!isGrabbed && isDrawing)
        {
            Debug.Log("Stopping drawing...");
            isDrawing = false;
            currentDrawing = null;
        }

        // Continue drawing if the pen is being grabbed
        if (isDrawing)
        {
            Draw();
        }
    }

    private void Draw()
    {
        // Constrain the position to the X-Y plane
        Vector3 constrainedPosition = new Vector3(tip.position.x, tip.position.y, 0);

        if (currentDrawing == null)
        {
            Debug.Log("Creating new LineRenderer...");
            index = 0;
            GameObject drawingObject = new GameObject("Drawing");
            currentDrawing = drawingObject.AddComponent<LineRenderer>();
            currentDrawing.material = drawingMaterial;
            currentDrawing.startColor = currentDrawing.endColor = penColors[currentColorIndex];
            currentDrawing.startWidth = currentDrawing.endWidth = penWidth;
            currentDrawing.positionCount = 1;
            currentDrawing.SetPosition(0, constrainedPosition);
        }
        else
        {
            var currentPos = currentDrawing.GetPosition(index);
            if (Vector3.Distance(currentPos, constrainedPosition) > 0.01f)
            {
                index++;
                currentDrawing.positionCount = index + 1;
                currentDrawing.SetPosition(index, constrainedPosition);
            }
        }
    }

    private void SwitchColor()
    {
        Debug.Log("Switching color...");
        currentColorIndex = (currentColorIndex + 1) % penColors.Length;
        tipMaterial.color = penColors[currentColorIndex];
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        Debug.Log("Pen grabbed");
        isDrawing = true; // Start drawing when the pen is grabbed
    }

    private void OnSelectExited(SelectExitEventArgs args)
    {
        Debug.Log("Pen released");
        isDrawing = false; // Stop drawing when the pen is released
        currentDrawing = null;
    }
}
