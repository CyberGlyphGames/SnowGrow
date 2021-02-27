using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    private Vector3 startOffset;
    private Vector3 startRotation;
    private float scaleMultiplyer = 1.5f;

    private void Awake()
    {
        startOffset = transform.position - target.position;
        startRotation = transform.localEulerAngles;
    }

    private void Update()
    {
        transform.position = target.position + startOffset + new Vector3(0,target.localScale.y,-target.localScale.z * scaleMultiplyer);
        transform.localEulerAngles = startRotation + new Vector3(target.localScale.x, 0, 0);
    }
}
