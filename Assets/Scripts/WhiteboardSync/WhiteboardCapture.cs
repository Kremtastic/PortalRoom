using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;


public class WhiteboardCapture : MonoBehaviour
{
    public Whiteboard whiteboard; // Reference to your Whiteboard component

    private bool hasSaved = false; // Flag to track if texture has been saved

    void Start()
    {
        // Start the delayed capture
        Invoke("CaptureAndSaveTexture", 10f); // Delay of 5 seconds
    }

    // Function to capture and save the current texture
    private void CaptureAndSaveTexture()
    {
        if (!hasSaved && whiteboard != null && whiteboard.texture != null)
        {
            // Create a new Texture2D and copy the current texture data into it
            Texture2D currentTexture = new Texture2D(whiteboard.texture.width, whiteboard.texture.height);
            currentTexture.SetPixels(whiteboard.texture.GetPixels());
            currentTexture.Apply();

            // Optionally save the texture to a file (e.g., PNG format)
            byte[] bytes = currentTexture.EncodeToPNG();
            string filePath = Application.persistentDataPath + "/whiteboard_capture.png";
            System.IO.File.WriteAllBytes(filePath, bytes);

            Debug.Log("Texture captured and saved to: " + filePath);

            // Set the flag to true to prevent further saving
            hasSaved = true;
        }
        else if (hasSaved)
        {
            Debug.LogWarning("Texture has already been saved. Cannot save again.");
        }
        else
        {
            Debug.LogWarning("Cannot capture texture. Make sure whiteboard and capture conditions are met.");
        }
    }
}
