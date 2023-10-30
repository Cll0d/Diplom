using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectableObject : MonoBehaviour
{
    public Vector3 SpawnPositionOffset;
    public Vector3 SpawnRotationOffset;
    public Vector2 MinMaxZoom = new Vector2(0.5f, 2);
    public float DefaultZoomValue = 1f;
}
