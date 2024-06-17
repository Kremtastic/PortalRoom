using UnityEngine;

public class WhiteboardSyncTest : MonoBehaviour
{
    public WhiteboardSync whiteboardSync;
    public Color fillColor = Color.red;

    private void Start()
    {
        if (whiteboardSync != null)
        {
            // Create a new texture and fill it with a color
            Texture2D newTexture = new Texture2D(whiteboardSync.textureSize.x, whiteboardSync.textureSize.y);
            Color[] fillPixels = new Color[whiteboardSync.textureSize.x * whiteboardSync.textureSize.y];

            for (int i = 0; i < fillPixels.Length; i++)
            {
                fillPixels[i] = fillColor;
            }

            newTexture.SetPixels(fillPixels);
            newTexture.Apply();

            // Convert the texture to a byte array
            byte[] textureData = newTexture.EncodeToPNG();

            // Update the whiteboard texture to sync with other players
            whiteboardSync.UpdateTexture(textureData);
        }
    }
}
