using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private Vector3 initDistance;
    public Vector2 minBounds;
    public Vector2 maxBounds;

    void Start()
    {
        initDistance = transform.position - target.position;
    }

    void Update()
    {
        Vector3 TracePosition = target.position + initDistance;   

        TracePosition.x = Mathf.Clamp(TracePosition.x, minBounds.x, maxBounds.x);
        TracePosition.y = Mathf.Clamp(TracePosition.y, minBounds.y, maxBounds.y);

        transform.position = TracePosition;
    }
}
