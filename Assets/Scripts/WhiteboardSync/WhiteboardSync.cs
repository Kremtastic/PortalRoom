using UnityEngine;
using Normal.Realtime;

public class WhiteboardSync : RealtimeComponent<WhiteboardSyncModel>
{
    private MeshRenderer _meshRenderer;
    private Texture2D _texture;
    public Vector2Int textureSize;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _texture = new Texture2D(textureSize.x, textureSize.y, TextureFormat.RGBA32, false);
        _meshRenderer.material.mainTexture = _texture;
    }

    protected override void OnRealtimeModelReplaced(WhiteboardSyncModel previousModel, WhiteboardSyncModel currentModel)
    {
        if (previousModel != null)
        {
            previousModel.textureDataDidChange -= TextureDataDidChange;
        }

        if (currentModel != null)
        {
            if (currentModel.isFreshModel)
            {
                // Initialize texture data if needed
                currentModel.textureData = new byte[textureSize.x * textureSize.y * 4];
            }

            currentModel.textureDataDidChange += TextureDataDidChange;
        }
    }

    private void TextureDataDidChange(WhiteboardSyncModel model, byte[] textureData)
    {
        if (_texture != null)
        {
            _texture.LoadImage(textureData);
            _texture.Apply();
        }
    }

    public void UpdateTexture(byte[] textureData)
    {
        model.textureData = textureData;
    }
}
