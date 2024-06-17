using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;


[RealtimeModel]
public partial class WhiteboardSyncModel
{
    [RealtimeProperty(1, true, true)]
    private byte[] _textureData;
}
